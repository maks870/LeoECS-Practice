using Leopotam.EcsLite;
using System;
using Zenject;

public class GameInitializationZenject : ITickable, IFixedTickable, IDisposable
{
    private EcsWorld world;
    private IEcsSystems initSystems;
    private IEcsSystems updateSystems;
    private IEcsSystems fixedUpdateSystems;

    public GameInitializationZenject(EcsWorld world, PlayerInitSystem playerSys, InputSystem inputSys, MovementSystem movementSys)
    {
        this.world = world;
        initSystems = new EcsSystems(world)
                .Add(playerSys);

        initSystems.Init();

        updateSystems = new EcsSystems(world)
            .Add(inputSys);

        updateSystems.Init();

        fixedUpdateSystems = new EcsSystems(world)
            .Add(movementSys);

        fixedUpdateSystems.Init();
    }

    public void Dispose()
    {
        initSystems.Destroy();
        updateSystems.Destroy();
        fixedUpdateSystems.Destroy();
        world.Destroy();
    }

    public void FixedTick()
    {
        fixedUpdateSystems?.Run();
    }

    public void Tick()
    {
        updateSystems?.Run();
    }
}

