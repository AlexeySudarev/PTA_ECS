using Game.Components.Shared;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Systems.Characters
{
    public class InputMoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var velocityPool = world.GetPool<VelocityComponent>();

            var entities = world.Filter<VelocityComponent>().End();

            foreach (int entity in entities)
            {
                ref VelocityComponent velocityComponent = ref velocityPool.Get(entity);

                float vertical = Input.GetAxisRaw("Vertical");
                float horizontal = Input.GetAxisRaw("Horizontal");

                velocityComponent.Velocity = new Vector3(horizontal, velocityComponent.Velocity.y, vertical).normalized;
            }
        }
    }
}