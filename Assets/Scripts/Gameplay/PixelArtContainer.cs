using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class PixelArtContainer : MonoBehaviour
    {
        [SerializeField] private Material _blackAndWhiteMaterial;
        [SerializeField] private Image _container;

        public Sprite CurrentSelectedSprite => _container.sprite;
    }
}