using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class AbilityObject : MonoBehaviour , ICreatable , IDestructible
    {
        [Header("-- SETUP --")]
        public float lifeTime;
        public float radius;
        public int effectValue;
        private int applyEffectsNum;
        
        [Header("UnityEvents"),Space(5)]
        public UnityEvent onDestroy;

        ICreator _maker;
        private Enum_TeamType _teamType;
        public ActionInfo currentSetupInfo;
        
        [HideInInspector] public List<Mover> movers;
        [HideInInspector] public List<Hitter> hitters;
        [HideInInspector] public Mover mover;

        protected virtual void Start()
        {
        }      
        
        protected virtual void Update()
        {
        }
        
        public virtual void Shoot()
        {
        }
        
        public bool Hit(GameObject target, HitInfo[] hitEffects, ActionInfo info = null)
        {
            Actor actorTarget = target.GetComponentInChildren<Actor>();
            if (!actorTarget) return false;

            applyEffectsNum = 0;

            foreach (var hit in hitEffects)
            {
                if (!target.CompareTag(hit.targetTag))
                {
                    continue;
                }

                switch (hit.team)
                {
                    case TeamRelation.ally:

                        if (actorTarget.TeamType == TeamID())
                        {
                            // TODO Apply Effects On Ally?
                        }

                        break;

                    case TeamRelation.enemy:

                        if (actorTarget.TeamType != TeamID())
                        {
                            actorTarget.statsHandler.TakeDamage(effectValue);
                            applyEffectsNum++;
                        }
                        break;

                    default:

                        break;
                }
            }

            if (applyEffectsNum > 0)
            {
                return true;
            }
            
            return false;
        }
        
        
        #region ICreatable

        public virtual void SetupSelf(ICreator maker, ActionInfo creationInfo)
        {
            _maker = maker;
            _teamType = creationInfo.teamId;
            currentSetupInfo = creationInfo;

            SetupHitters();
            SetupMovers();
        }
        
        public Enum_TeamType TeamID()
        {
            return currentSetupInfo.teamId;
        }

        #endregion

        #region Hitter

        private void SetupHitters()
        {
            hitters = new List<Hitter>();
      

            var hits = GetComponents<Hitter>();

            foreach (Hitter h in hits)
            {
                hitters.Add(h);
                h.Init(currentSetupInfo);
            }
        }

        #endregion

        #region Mover

        private void SetupMovers()
        {
            movers = new List<Mover>();
            var moves = GetComponentsInChildren<Mover>();

            foreach (var m in moves)
            {
                movers.Add(m);  
                mover = m;
            }
        }

        #endregion

        #region Utils

        public void Destroy()
        {
            onDestroy?.Invoke();
            Destroy(gameObject);
        }

        #endregion

    }
    
    [Serializable]
    public class HitInfo
    {
        public TeamRelation team;
        public string targetTag;
    }
    
    [Serializable]
    public class TargetInfo
    {
        public TeamRelation team;
        public string targetTag;
    }
    
    public enum TeamRelation
    {
        ally,
        enemy,
        all,
        self,
    }

}