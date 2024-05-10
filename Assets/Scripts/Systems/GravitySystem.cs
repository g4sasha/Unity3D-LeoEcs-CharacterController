using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<GravityComponent, GroundCheckSphereComponent> _gravityFilter = null;

        public void Run()
        {
            foreach (var i in _gravityFilter)
            {
                ref var gravity = ref _gravityFilter.Get1(i);
                ref var velocity = ref gravity.Velocity;
                ref var groundCheck = ref _gravityFilter.Get2(i);

                if (groundCheck.IsGrounded) 
                {
                    if (velocity.y < 0f) velocity = Vector3.zero;
                    continue;
                }

                velocity.y += gravity.Gravity * Time.deltaTime;
            }
        }
    }
}