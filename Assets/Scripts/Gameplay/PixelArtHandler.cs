using System;
using UnityEngine;

namespace Gameplay
{
    public class PixelArtHandler : MonoBehaviour
    {
        [SerializeField] private PixelArtContainer _pixelArtContainer;
        
        private void Awake()
        {
            Debug.Log(_pixelArtContainer.CurrentSelectedSprite.texture.width + "x" + _pixelArtContainer.CurrentSelectedSprite.texture.height + "y");
        }
    }
}