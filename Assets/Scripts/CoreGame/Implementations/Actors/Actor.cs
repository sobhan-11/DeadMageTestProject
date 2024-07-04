using System;
using DG.Tweening;
using UnityEngine;

namespace CoreGame
{
    public abstract class Actor : MonoBehaviour
    {
        [Header("Components"), Space]
        [SerializeField] protected StatsHandler statsHandler;
        [SerializeField] protected GFXHandler gfxHandler;    
        protected AnimationHandler _animationHandler;

        private void Awake()
        {
            _animationHandler = new AnimationHandler(GetComponentInChildren<Animator>());
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
        public abstract void OnTakeDamage(float damage,float currentHp);
        public virtual void OnDeath()
        {
            
        }
        protected void ShowDamageVisual(float damage)
        {
            gfxHandler.PlayDamageVFX(damage);
        }

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
}