using UnityEngine;
using Zenject;
using App.Services;
using Domain.Services;
using Domain.UseCases;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISenceLoad>().To<UnityScenceLoad>().AsSingle().NonLazy();
        Container.Bind<AppInitializer>().AsSingle().NonLazy();
    }
}