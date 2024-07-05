using System;
using UnityEngine;

namespace CoreGame
{
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;

        [Header("Const - Walk")] 
        private const string WALK = "Walk";
        private const string WALK_SPEEED = "MovementSpeed";
        private const string DASH = "Dash";
        private const string HIT = "Hit";

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        #region Walk
        
        public void PlayWalkAnimation(Vector2 dir , float moveSpeed = 1f)
        {
            _animator.SetBool(WALK, true);
            _animator.SetFloat(WALK_SPEEED,moveSpeed);
        }

        public void StopWalk() => _animator.SetBool(WALK, false);
        
        #endregion

        #region Dash

        public void SetDashState(bool isDash) => _animator.SetBool(DASH, isDash);

        #endregion

        #region Hit

        public void PlayHitAnimation()
        {
            _animator.SetTrigger(HIT);
        }

        #endregion
    }
}