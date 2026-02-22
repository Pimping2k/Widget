using System;
using MyPackage.Runtime.ServiceLocator_Core;
using Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class CounterService : MonoBehaviour, IService
    {
        private IInputService _inputService;
        
        public int Counter { get; private set; }

        public event Action<int> CounterChanged;
        
        private void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();
        }

        private void Start()
        {
            ToggleSubscriptions(true);
        }

        private void OnDestroy()
        {
            ToggleSubscriptions(false);
        }

        private void ToggleSubscriptions(bool toggle)
        {
            if (toggle)
            {
                _inputService.UI.AnyClick.performed += OnAnyClickPerformed;
            }
            else
            {
                _inputService.UI.AnyClick.performed -= OnAnyClickPerformed;
            }
        }

        private void OnAnyClickPerformed(InputAction.CallbackContext ctx)
        {
            PerformMainAction();
        }

        private void PerformMainAction()
        {
            Counter++;
            CounterChanged?.Invoke(Counter);
        }
    }
}