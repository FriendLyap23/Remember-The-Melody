using Zenject;

public class ShopInstallers : MonoInstaller
{
    public Shop shop;

    public override void InstallBindings()
    {
        Container.Bind<Shop>().FromInstance(shop).AsSingle().NonLazy();
    }
}
