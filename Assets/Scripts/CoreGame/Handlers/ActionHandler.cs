using System;
using Unity.Mathematics;
using UnityEngine;

namespace CoreGame
{
    public class ActionHandler : MonoBehaviour
    {
        [Header(" Components "), Space(5)]
        [SerializeField] private CharacterController body;
        private AnimationHandler animationHandler;

        [Header(" Move "), Space(5)]
        [SerializeField, Range(0f, 100f)] private float moveSpeed = 4f;
        [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;

        Vector2 currentDir = Vector2.zero;
        Vector2 currentDirVelocity = Vector2.zero;
        Vector3 velocity;

        [Header(" Look ")] 
        [SerializeField, Range(4f, 8f)] private float lookRotationSpeed = 4;
        internal Vector3 lookDirection;
        private bool lockLook = false;
        [HideInInspector] public Quaternion targetRotation;

        
        public void Init(AnimationHandler _animationHandler)
        {
            animationHandler = _animationHandler;
            velocity=Vector3.zero;
        }

        #region Move
        
        public void ApplyMove(Vector2 moveInput)
        {
            // TODO Check For Ability isUsing and if true return
            GatherMoveData(moveInput);
            body.Move(velocity * Time.fixedDeltaTime);
            HandleLook(moveInput);
            HandleWalkVisual(moveInput);
        }

        private void GatherMoveData(Vector2 moveInput)
        {
            Vector2 targetDir = new Vector2(moveInput.x, moveInput.y);
            targetDir.Normalize();

            currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

            velocity = (Vector3.forward * currentDir.y + Vector3.right * currentDir.x) * moveSpeed;
        }

        private void HandleWalkVisual(Vector2 moveInput)
        {
            if (moveInput.magnitude == 0)
            {
                animationHandler.StopWalk();
                //TODO SFX on start walk
            }
            else
            {
                animationHandler.PlayWalkAnimation(moveInput);
                //TODO SFX on stop walk
            }
        }
        
        #endregion

        #region Look

        private void HandleLook(Vector2 direction)
        {
            // if(lockLook)
            //     return;

            // Vector2 targetLook = new Vector2(direction.x, direction.y);
            //
            // currentLookDelta = Vector2.SmoothDamp(currentLookDelta, targetLook, ref currentLookDeltaVelocity, lookSmoothTime);
            //
            // transform.Rotate(Vector3.up * (currentLookDelta.x * lookRotationSpeed));
            
            UpdateTargetRotation();
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, targetRotation, (lookRotationSpeed*100) * Time.fixedDeltaTime);
        }

        void UpdateTargetRotation()
        {
            if (lookDirection != Vector3.zero) 
            { 
                targetRotation = Quaternion.LookRotation(lookDirection);
                return;
            }
            
            if (body.velocity == Vector3.zero)
            {
                return;
            }

            targetRotation = Quaternion.LookRotation(body.velocity.normalized);
        }
        
        #endregion

        #region Utils

        public AnimationHandler GetAnimationHandler() => this.animationHandler;
        
        #endregion
    }
}