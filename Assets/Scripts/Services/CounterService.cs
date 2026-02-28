using System;
using MyPackage.Runtime.ServiceLocator_Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services
{
    public class CounterService : MonoBehaviour, IService
    {
        [SerializeField] private float _inputCooldown = 0.05f;
        
        private IInputService _inputService;
        private float _lastClickTime;
        
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
            if(!ctx.ReadValueAsButton())
                return;

            if (Time.time - _lastClickTime < _inputCooldown) 
                return;
            
            PerformMainAction();
            _lastClickTime = Time.time;
        }

        private void PerformMainAction()
        {
            Counter++;
            CounterChanged?.Invoke(Counter);
        }
    }
}