using Game.Characters;
using Game.Components.Characters;
using Game.Components.Shared;
using Game.Systems.Characters;
using Game.Systems.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Startup
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private CharacterView _player;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            AddPlayerEntity();
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            _systems
                .Add(new InputMoveSystem())
                .Add(new MovementSystem())
                .Add(new CharacterViewSyncSystem())
                .Init();
        }

        private void AddPlayerEntity()
        {
            var playerEntity = _world.NewEntity();
            var characterViewPool = _world.GetPool<CharacterViewComponent>();
            var positionPool = _world.GetPool<PositionComponent>();
            var velocityPool = _world.GetPool<VelocityComponent>();

            characterViewPool.Add(playerEntity).View = _player;
            positionPool.Add(playerEntity).Position = _player.transform.position;
            velocityPool.Add(playerEntity);
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _world.Destroy();
            _systems.Destroy();
        }
    }
}