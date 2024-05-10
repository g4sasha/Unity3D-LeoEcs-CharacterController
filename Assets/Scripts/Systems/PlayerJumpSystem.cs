using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, GravityComponent, JumpEvent> _jumpFilter = null;

        public void Run()
        {
            foreach (var i in _jumpFilter)
            {
                ref var groundCheck = ref _jumpFilter.Get2(i);
                ref var jumpComponent = ref _jumpFilter.Get3(i);
                ref var gravity = ref _jumpFilter.Get4(i);
                ref var velocity = ref gravity.Velocity;
                if (!groundCheck.IsGrounded) continue;
                velocity.y = Mathf.Sqrt(jumpComponent.Force * -2f * gravity.Gravity);
            }
        }
    }
}