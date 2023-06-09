using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class GameInitalizationEsc : MonoBehaviour
{
    private DiContainer container;
    private EcsWorld world;
    private IEcsSystems initSystems;
    private IEcsSystems updateSystems;
    private IEcsSystems fixedUpdateSystems;

    [Inject]
    private void Construct(DiContainer container)
    {
        this.container = container;
    }

    private void Start()
    {
        PlayerInitSystem playerInitSys = container.TryResolve<PlayerInitSystem>();

        world = new EcsWorld();
        initSystems = new EcsSystems(world)
                .Add(playerInitSys);

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
