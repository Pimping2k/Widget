using System;
using Gameplay;
using MyPackage.Runtime.ServiceLocator_Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIClickCounterController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private CounterService _counterService;

        private void Awake()
        {
            _counterService = ServiceLocator.Resolve<CounterService>();

            _counterService.CounterChanged += OnCounterChanged;
        }

        private void OnDestroy()
        {
            _counterService.CounterChanged -= OnCounterChanged;
        }

        private void OnCounterChanged(int counter)
        {
            _text.text = $"I am counter : {counter}";
        }
    }
}