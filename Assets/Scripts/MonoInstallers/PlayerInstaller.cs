using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private int hp;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody playerRigibody;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInitSystem>().AsSingle().WithArguments(hp, moveSpeed, playerRigibody);
    }
}
