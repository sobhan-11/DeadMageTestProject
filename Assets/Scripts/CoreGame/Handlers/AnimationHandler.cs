using UnityEngine;

namespace CoreGame
{
    public class AnimationHandler
    {
        private Animator animator;

        [Header("Const - Walk")] 
        private const string WALK = "Walk";
        private const string WALK_SPEEED = "MovementSpeed";
        private const string DASH = "Dash";
        private const string HIT = "Hit";


        public AnimationHandler(Animator _animator)
        {
            animator = _animator;
        }
        
        
        #region Walk
        
        public void PlayWalkAnimation(Vector2 dir , float moveSpeed = 1f)
        {
            animator.SetBool(WALK, true);
            animator.SetFloat(WALK_SPEEED,moveSpeed);
        }

        public void StopWalk() => animator.SetBool(WALK, false);
        
        #endregion

        #region Dash

        public void SetDashState(bool isDash) => animator.SetBool(DASH, isDash);

        #endregion

        #region Hit

        public void PlayHitAnimation()
        {
            animator.SetTrigger(HIT);
        }

        #endregion
    }
}