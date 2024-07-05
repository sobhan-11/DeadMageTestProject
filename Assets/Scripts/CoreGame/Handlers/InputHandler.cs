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
        private InputAction click;
        private InputAction switchUp;
        private InputAction switchDown;
        
        
        public InputHandler(PlayerInput _playerInput)
        {
            playerInput = _playerInput;

            SubscribeToInput();
        }

        private void SubscribeToInput()
        {
            moveInputAction = playerInput.actions.FindAction("Movement");
            dashInputAction = playerInput.actions.FindAction("Dash");
            cast1InputAction = playerInput.actions.FindAction("Cast1");
            switchUp = playerInput.actions.FindAction("SwitchUp");
            switchDown = playerInput.actions.FindAction("SwitchDown");
            click = playerInput.actions.FindAction("Click");
        }

        #region GatherInput

        public bool GatherDashInput() => dashInputAction.IsPressed();
        
        public bool GatherCast1Input() => cast1InputAction.IsPressed();

        public Vector2 GatherMoveInput() => moveInputAction.ReadValue<Vector2>();

        public bool GatherClickInput() => click.IsPressed();
        public bool GatherSwitchUpInput() => switchUp.IsPressed();
        public bool GatherSwitchdownInput() => switchDown.IsPressed();
        
        #endregion
    }
}