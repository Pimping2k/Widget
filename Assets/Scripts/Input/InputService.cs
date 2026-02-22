using Services;
using UnityEngine;

namespace Input
{
    public class InputService : MonoBehaviour, IInputService
    {
        public InputSystem_Actions.PlayerActions Player { get; private set; }
        public InputSystem_Actions.UIActions UI { get; private set; }
        public InputSystem_Actions InputActions { get; private set; }

        private void Awake()
        {
            InputActions = new InputSystem_Actions();
            InputActions.Enable();
            
            Player = InputActions.Player;
            UI = InputActions.UI;
        }
    }
}
