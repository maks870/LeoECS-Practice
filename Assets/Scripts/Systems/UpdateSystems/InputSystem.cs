using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    public void Run(IEcsSystems systems)
    {
        var filter = systems.GetWorld().Filter<InputComponent>().Inc<PlayerComponent>().End();
        var inputPool = systems.GetWorld().GetPool<InputComponent>();

        foreach (var entity in filter)
        {
            ref var playerInputComponent = ref inputPool.Get(entity);

            playerInputComponent.direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
}
