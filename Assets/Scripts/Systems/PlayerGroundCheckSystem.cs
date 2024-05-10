using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent> _groundFilter = null;

        public void Run()
        {
            foreach (var i in _groundFilter)
            {
                ref var groundCheck = ref _groundFilter.Get2(i);
                groundCheck.IsGrounded = Physics.CheckSphere(groundCheck.GroundCheckSphere.position, groundCheck.GroundDistance, groundCheck.GroundMask);
            }
        }
    }
}