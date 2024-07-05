using System.Collections;
using UnityEngine;

namespace CoreGame
{
    public class Dummy : Actor
    {
        public override Enum_TeamType TeamType => Enum_TeamType.Dummy;

        [Header(" HpBar ")] 
        [SerializeField] private HpBar hpBar;

        #region Actor

        public override void Init()
        {
            statsHandler.Init(new InitStat()
            {
                maxHP = 100,
                statPercent = 1
            });
            hpBar.Init();
        }

        public override void OnTakeDamage(float damage,float currentHpPercent)
        {
            ShowDamageVisual(damage);
            animationHandler.PlayHitAnimation();
            hpBar.SetHpBar(currentHpPercent);
        }

        public override void OnDeath()
        {
            StartCoroutine(DeathRoutine());
        }

        #endregion

        #region DeathRoutine

        private IEnumerator DeathRoutine()
        {
            yield return new WaitForSeconds(5f);
            MoveToGroundOnDeath();
        }

        private void ReSpawn()
        {
            gfxHandler.HandleGFX(false);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Init();
            gfxHandler.HandleGFX(true);
        }

        #endregion

    }
}