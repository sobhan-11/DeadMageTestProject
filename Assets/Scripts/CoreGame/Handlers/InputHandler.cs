using UnityEngine;
using UnityEngine.InputSystem;

namespace CoreGame
{
    public class InputHandler
    {
        private PlayerInput playerInput;
        private InputAction moveInputAction;
        private InputAction dashInputAction;
        private InputAction cast1InputAction;
        
        
        
        public InputHandler(PlayerInput _playerInput)
        {
            playerInput = _playerInput;

            SubscribeToInput();
        }

        private void SubscribeToInput()
        {
            moveInputAction=playerInput.actions.FindAction("Movement");
            dashInputAction=playerInput.actions.FindAction("Dash");
            cast1InputAction=playerInput.actions.FindAction("Cast1");
        }

        #region GatherInput

        public bool GatherJumpInput() => dashInputAction.IsPressed();
        
        public bool GatherCrouchInput() => cast1InputAction.IsPressed();

        public Vector2 GatherMoveInput() => moveInputAction.ReadValue<Vector2>();
        
        #endregion
    }
}