using UnityEngine;

namespace CoreGame
{
    public class AnimationHandler
    {
        private Animator animator;

        [Header("Const - Walk")] 
        private const string WALK = "Walk";
        private const string DASH = "Dash";


        public AnimationHandler(Animator _animator)
        {
            animator = _animator;
        }
        
        
        #region Walk
        
        public void PlayWalkAnimation(Vector2 dir)
        {
            animator.SetBool(WALK, true);
        }

        public void StopWalk() => animator.SetBool(WALK, false);
        
        #endregion

        #region Dash

        public void SetDashState(bool isCrouching) => animator.SetBool(DASH, isCrouching);

        #endregion

    }
}