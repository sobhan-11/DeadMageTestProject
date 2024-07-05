using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CoreGame
{
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;

        [Header("Const - Walk")] 
        private const string WALK = "Walk";
        private const string WALK_SPEEED = "MovementSpeed";
        private const string DASH = "Dash";
        private const string CAST_1_1 = "Cast1_1";
        private const string CAST_1_2 = "Cast1_2";
        private const string CAST_1_3 = "Cast1_3";
        private const string HIT_1 = "Hit_1";
        private const string HIT_2 = "Hit_2";

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

        #region Cast-1

        public void SetTriggerCast1_1()
        {
            _animator.SetTrigger(CAST_1_1);
        }       
        public void SetTriggerCast1_2()
        {
            _animator.SetTrigger(CAST_1_2);
        }      
        public void SetTriggerCast1_3()
        {
            _animator.SetTrigger(CAST_1_3);
        }

        #endregion

        #region Hit

        public void PlayHitAnimation()
        {
            var random = Random.Range(0, 2);
            if(random/2==0)
                _animator.SetTrigger(HIT_1);
            else
                _animator.SetTrigger(HIT_2);    
        }

        #endregion
    }
}