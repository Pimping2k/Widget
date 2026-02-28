using System;
using MyPackage.Runtime.ServiceLocator_Core;
using Services;
using UnityEngine;

namespace Gameplay
{
    public class PixelArtHandler : MonoBehaviour
    {
        private const string MATERIAL_PROGRESS = "_Progress";
        
        [SerializeField] private PixelArtContainer _pixelArtContainer;

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

        private void OnCounterChanged(int clickAmount)
        {
            float totalBlocks = 32f * 32f; 
            float currentProgress = clickAmount / totalBlocks;
            var material = _pixelArtContainer.CurrentSelectedSprite.material;
            currentProgress = Mathf.Clamp01(currentProgress);
            material.SetFloat(MATERIAL_PROGRESS, currentProgress);
        }
    }
}