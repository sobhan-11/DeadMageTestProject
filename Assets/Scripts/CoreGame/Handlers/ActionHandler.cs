using System;
using System.Linq;
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
        private bool canMove;

        [Header(" Look ")] 
        [SerializeField, Range(4f, 8f)] private float lookRotationSpeed = 4;
        internal Vector3 lookDirection;
        private bool lockLook = false;
        [HideInInspector] public Quaternion targetRotation;

        [Header(" CastHandlers ")] 
        [SerializeField] private CastHandler[] castHandlers;

        
        public void Init(AnimationHandler _animationHandler)
        {
            animationHandler = _animationHandler;
            velocity=Vector3.zero;
            InitCastHandlers();
            OnEndAbilities();
        }

        #region Move
        
        public void ApplyMove(Vector2 moveInput)
        {
            // TODO Check For Ability isUsing and if true return
            if(!canMove)
                return;
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
                animationHandler.PlayWalkAnimation(moveInput , moveSpeed);
                //TODO SFX on stop walk
            }
        }

        public void DisableMove() => canMove = false;
        public void EnableMove() => canMove = true;
        
        #endregion

        #region Look

        private void HandleLook(Vector2 direction)
        {
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

        #region Dash

        public void HandleDash(bool isDashPressed)
        {
            if(!isDashPressed)
                return;
            var caster0 = castHandlers[0]; // Dash as a passive ability should always be index 0 in casthandlers list.
            var abilityDash = (caster0.abilities[0] as AbilityDash);
            if (caster0.isUsing)
                return;
            if(!CanUse()) // Check For Ability intruption
                return;
            DisableMove();
            animationHandler.SetDashState(true);
            abilityDash.ApplyDash(()=>
            {
                animationHandler.SetDashState(false);
                OnEndAbilities();
            });
        }

        #endregion

        #region Abilities

        private void InitCastHandlers()
        {
            for (int i = 0; i < castHandlers.Length; i++)
            {
                castHandlers[i].Init();
            }
        }

        private void OnEndAbilities()
        {
            EnableMove();
        }

        #endregion
        
        #region Utils

        public AnimationHandler GetAnimationHandler() => this.animationHandler;

        private bool CanUse()=> !castHandlers.Any(x => x.isUsing);

        #endregion
    }
}