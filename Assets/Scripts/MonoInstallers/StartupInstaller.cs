using Leopotam.EcsLite;
using Zenject;

public class StartupInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());
        Container.Bind<InputSystem>().AsSingle();
        Container.Bind<MovementSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<GameInitializationZenject>()
            .AsSingle()
            .NonLazy();
    }
}
