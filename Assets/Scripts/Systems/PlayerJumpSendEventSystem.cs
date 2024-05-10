using Leopotam.Ecs;
using UnityEngine;

namespace Gyach.Source.Code.Ecs
{
    sealed class PlayerJumpSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> _jumpFilter = null;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
    }
}