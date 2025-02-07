using Game.Components.Characters;
using Game.Components.Shared;
using Leopotam.EcsLite;

namespace Game.Systems.Characters
{
    public class CharacterViewSyncSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var positionPool = world.GetPool<PositionComponent>();
            var characterViewPool = world.GetPool<CharacterViewComponent>();

            var entities = world.Filter<PositionComponent>().Inc<CharacterViewComponent>().End();

            foreach (int entity in entities)
            {
                ref PositionComponent positionComponent = ref positionPool.Get(entity);
                ref CharacterViewComponent characerViewComponent = ref characterViewPool.Get(entity);

                characerViewComponent.View.SetPosition(positionComponent.Position);
            }
        }
    }
}