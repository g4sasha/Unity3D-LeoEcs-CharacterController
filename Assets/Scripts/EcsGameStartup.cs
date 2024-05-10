using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Gyach.Source.Code.Ecs
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems.ConvertScene();
            AddInjections();
            AddOneFrames();
            AddSystems();
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }

        private void AddInjections()
        {

        }

        private void AddSystems()
        {
            _systems
            .Add(new PlayerInputSystem())
            .Add(new MovementSystem())

            .Add(new GroundCheckSystem())

            .Add(new GravitySystem())
            .Add(new ObjectGravityAppliedSystem())

            .Add(new PlayerJumpSendEventSystem())
            .Add(new PlayerJumpSystem())

            .Add(new PlayerMouseInputSystem())
            .Add(new PlayerMouseLookSystem())
            ;
        }

        private void AddOneFrames()
        {
            _systems
            .OneFrame<JumpEvent>()
            ;
        }
    }
}