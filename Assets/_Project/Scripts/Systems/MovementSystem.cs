using Game.Components.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Systems.Shared
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var positionPool = world.GetPool<PositionComponent>();
            var velocityPool = world.GetPool<VelocityComponent>();

            var entities = world.Filter<PositionComponent>().Inc<VelocityComponent>().End();

            foreach (int entity in entities)
            {
                ref PositionComponent positionComponent = ref positionPool.Get(entity);
                ref VelocityComponent velocityComponent = ref velocityPool.Get(entity);

                positionComponent.Position += velocityComponent.Velocity * Time.deltaTime;
            }
        }
    }
}