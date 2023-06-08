using Leopotam.EcsLite;
using UnityEngine;

public class MovementSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var filter = systems.GetWorld().Filter<CharacterComponent>().Inc<InputComponent>().Inc<MovableComponent>().End();
        var movablePool = systems.GetWorld().GetPool<MovableComponent>();
        var inputPool = systems.GetWorld().GetPool<InputComponent>();

        foreach (var entity in filter)
        {
            ref var movableComponent = ref movablePool.Get(entity);
            ref var inputComponent = ref inputPool.Get(entity);

            movableComponent.rb.AddForce(inputComponent.direction * movableComponent.moveSpeed * Time.fixedDeltaTime, UnityEngine.ForceMode.Acceleration);
        }
    }

}
