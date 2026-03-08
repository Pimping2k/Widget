using System;
using Cysharp.Threading.Tasks;
using MyPackage.Runtime.ServiceLocator_Core;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class PixelArtContainer : MonoBehaviour
    {
        [SerializeField] private PixelArtHandler _pixelArtHandler; 
        [SerializeField] private Material _blackAndWhiteMaterial;
        [SerializeField] private Image _imageContainer;

        private ImageParser _imageParser;
        
        public Image CurrentSelectedSprite => _imageContainer;

        private void Awake()
        {
            _imageParser = ServiceLocator.Resolve<ImageParser>();
            
            _pixelArtHandler.ImageFinished += OnImageFinished;
            
            var materialInstance = Instantiate(_blackAndWhiteMaterial);
            _imageContainer.material = materialInstance;
        }

        private void OnDestroy()
        {
            _pixelArtHandler.ImageFinished -= OnImageFinished;
        }

        private void OnImageFinished()
        {
            SetupNewImage();
        }

        private async void SetupNewImage()
        {
            await _imageParser.GetParsedImage();
            var parsedTexture = _imageParser.ParsedTexture;
            var newSprite = Sprite.Create(parsedTexture, new Rect(0, 0, parsedTexture.width, parsedTexture.height), new Vector2(0.5f, 0.5f));
            _imageContainer.sprite = newSprite;
            var materialInstance = Instantiate(_blackAndWhiteMaterial);
            _imageContainer.material = materialInstance;
        }
    }
}