using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class PlayerMouseInputSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<HideCursorComponent> _cursorFilter = null;
        private readonly EcsFilter<PlayerTag, MouseLookDirectionComponent> _playerFilter = null;
        private float _axisX, _axisY;

        public void Init()
        {
            foreach (var i in _cursorFilter)
            {
                ref var hideComponent = ref _cursorFilter.Get1(i);
                hideComponent.OnChanged += ChangeCursorState;
                hideComponent.IsVisible = hideComponent.IsVisible; // Чтобы обновить вызвать событие
            }
        }

        public void Destroy()
        {
            foreach (var i in _cursorFilter)
            {
                ref var hideComponent = ref _cursorFilter.Get1(i);
                hideComponent.OnChanged -= ChangeCursorState;
            }
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                GetAxis();
                ClampAxis(i);
                ref var lookComponent = ref _playerFilter.Get2(i);
                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
            }
        }

        private void ChangeCursorState(bool state)
        {
            Cursor.visible = state;

            if (state)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void GetAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY -= Input.GetAxis("Mouse Y");
        }

        private void ClampAxis(int i)
        {
            var maxAngle = _playerFilter.Get2(i).MaxAngle / 5f;
            _axisY = Mathf.Clamp(_axisY, -maxAngle, maxAngle);
        }
    }
}