using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class ObjectGravityAppliedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GravityComponent, MovableComponent, GroundCheckSphereComponent> _gravityFilter = null;

        public void Run()
        {
            foreach (var i in _gravityFilter)
            {
                ref var gravity = ref _gravityFilter.Get1(i);
                ref var movable = ref _gravityFilter.Get2(i);
                ref var groundCheck = ref _gravityFilter.Get3(i);
                movable.CharacterController.Move(gravity.Velocity * Time.deltaTime);
            }
        }
    }
}