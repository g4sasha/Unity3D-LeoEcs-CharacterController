using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;
        private float _moveX, _moveZ;

        public void Run()
        {
            SetDirection();

            foreach (var i in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;
                direction.x = _moveX;
                direction.z = _moveZ;
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
    }
}