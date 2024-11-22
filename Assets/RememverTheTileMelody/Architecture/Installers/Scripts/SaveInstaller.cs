using Zenject;

public class SaveInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UIPurchases>().FromComponentInChildren().AsTransient();
        Container.Bind<Purchases>().FromComponentInChildren().AsTransient();

        Container.Bind<LoadSkins>().FromComponentInHierarchy().AsSingle();

        Container.Bind<IStoragePurchases>().To<PurchasesStorage>().AsSingle();
    }
}
