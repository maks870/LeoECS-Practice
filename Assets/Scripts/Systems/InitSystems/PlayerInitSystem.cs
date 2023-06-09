using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerInitSystem : IEcsInitSystem
{
    private int hp;
    private float moveSpeed;
    private Rigidbody rb;

    public PlayerInitSystem(int hp, float moveSpeed, Rigidbody playerRigibody)
    {
        this.hp = hp;
        this.moveSpeed = moveSpeed;
        rb = playerRigibody;
    }

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

        characterComponent.hp = hp;
        movableComponent.moveSpeed = moveSpeed;
        movableComponent.rb = rb;
    }
}
