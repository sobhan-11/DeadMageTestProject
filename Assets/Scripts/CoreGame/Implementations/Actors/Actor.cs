using System;
using DG.Tweening;
using UnityEngine;

namespace CoreGame
{
    public abstract class Actor : MonoBehaviour , ITargetable
    {
        [Header("Components"), Space]
        [SerializeField] public StatsHandler statsHandler;
        [SerializeField] protected GFXHandler gfxHandler;    
        [SerializeField] protected AnimationHandler animationHandler;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            statsHandler.onTakeDamage += OnTakeDamage;
        }

        private void OnDisable()
        {
            statsHandler.onTakeDamage -= OnTakeDamage;
        }

        public abstract Enum_TeamType TeamType { get; }
        public virtual void Init(){}
        public abstract void OnTakeDamage(float damage,float currentHpPercent);
        public virtual void OnDeath(StatsHandler statsHandler)
        {
            
        }
        protected void ShowDamageVisual(float damage)
        {
            gfxHandler.PlayDamageVFX(damage);
        }

        #region ITargetable

        public Enum_TeamType ID() => TeamType;

        #endregion
        
        #region Utils

        protected void MoveToGroundOnDeath(Action onComplete = null)
        {
            Vector3 targetPosition = transform.position - (Vector3.up * 3);
            transform.DOMove(targetPosition, 2f).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
        }

        #endregion
    }
    
    public interface ITargetable
    {
        public Enum_TeamType ID();
    }
}