using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame
{
    public class StatsHandler : MonoBehaviour
    {
        [Header("Stats")]
        private Dictionary<Enum_StatsType,Stat> stats;
        private bool isDead;

        public Action<float> onTakeDamage;
        public Action<StatsHandler> onDeath;

        #region Initial

        public void Init(InitStat initStats)
        {
            CreateStats(initStats);

            onDeath = null;
            isDead = false;
        }

        private void CreateStats(InitStat initStats)
        {
            //Create Stats With Their Max Values
            stats = new Dictionary<Enum_StatsType, Stat>();
            
            stats.Add(Enum_StatsType.HP, new StatHP(initStats.maxHP, (int)(initStats.maxHP * initStats.statPercent)));
        }
        
        #endregion
    
        #region Damage
    
        public void TakeDamage(int damage)
        {
            StatHP hp = stats[Enum_StatsType.HP] as StatHP;
            hp.UseStat(damage,Death);
            
            // TODO Play Damage VFX in visual handler
            onTakeDamage?.Invoke(hp.GetCurrentValuePercent());
        }
        
        #endregion
    
        #region Death

        public bool IsDead() => isDead;
        public void Death()
        {
            isDead = true;
            onDeath?.Invoke(this);
            //TODO Play VFX and SFX
        } 
        
        #endregion

        #region Utils

        public Stat GetStatByType(Enum_StatsType type) => stats[type];
        
        #endregion

    }
    
    public enum Enum_StatsType
    {
        None=0,
        HP=1,
        Damage=2,
        MoveSpeed=3,
    }

    public struct InitStat
    {
        public float statPercent;
        public int maxHP;
        public int maxMoveSpeed;
    }
}


