using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class PixelArtContainer : MonoBehaviour
    {
        [SerializeField] private Material _blackAndWhiteMaterial;
        [SerializeField] private Image _imageContainer;

        public Image CurrentSelectedSprite => _imageContainer;

        private void Awake()
        {
            var materialInstance = Instantiate(_blackAndWhiteMaterial);
            _imageContainer.material = materialInstance;
        }
    }
}