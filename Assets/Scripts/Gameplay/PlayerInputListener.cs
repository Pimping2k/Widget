using System;
using MyPackage.Runtime.ServiceLocator_Core;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PlayerInputListener : MonoBehaviour
    {
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = ServiceLocator.Resolve<IInputService>();
        }

        private void ToggleSubscriptions()
        {
        }
    }
}