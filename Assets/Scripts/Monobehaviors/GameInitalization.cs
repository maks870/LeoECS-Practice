using Leopotam.EcsLite;
using UnityEngine;

public class GameInitalization : MonoBehaviour
{
    private EcsWorld world;
    private IEcsSystems initSystems;
    private IEcsSystems updateSystems;
    private IEcsSystems fixedUpdateSystems;

    private void Start()
    {
        world = new EcsWorld();
        initSystems = new EcsSystems(world)
                .Add(new PlayerInitSystem());

        initSystems.Init();

        updateSystems = new EcsSystems(world)
            .Add(new InputSystem());

        updateSystems.Init();

        fixedUpdateSystems = new EcsSystems(world)
            .Add(new MovementSystem());

        fixedUpdateSystems.Init();
    }

    private void Update()
    {
        updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        initSystems.Destroy();
        updateSystems.Destroy();
        fixedUpdateSystems.Destroy();
        world.Destroy();
    }
}
