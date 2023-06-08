using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    public void Init(IEcsSystems systems)
    {
        var ecsWorld = systems.GetWorld();

        var playerEntity = ecsWorld.NewEntity();

        var characterPool = ecsWorld.GetPool<CharacterComponent>();
        var playerPool = ecsWorld.GetPool<PlayerComponent>();
        var inputPool = ecsWorld.GetPool<InputComponent>();
        var movablePool = ecsWorld.GetPool<MovableComponent>();


        characterPool.Add(playerEntity);
        playerPool.Add(playerEntity);
        inputPool.Add(playerEntity);
        movablePool.Add(playerEntity);


        ref var characterComponent = ref characterPool.Get(playerEntity);
        ref var inputComponent = ref inputPool.Get(playerEntity);
        ref var movableComponent = ref movablePool.Get(playerEntity);

        var playerGO = GameObject.FindGameObjectWithTag("Player");

        characterComponent.hp = 3;
        movableComponent.moveSpeed = 100;
        movableComponent.rb = playerGO.GetComponent<Rigidbody>();
    }
}
