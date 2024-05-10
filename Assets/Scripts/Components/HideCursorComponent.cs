using System;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    [Serializable]
    public struct HideCursorComponent
    {
        public event Action<bool> OnChanged;
        public bool IsVisible 
        { 
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnChanged?.Invoke(_isVisible);
            }
        }

        [SerializeField] private bool _isVisible;
    }
}