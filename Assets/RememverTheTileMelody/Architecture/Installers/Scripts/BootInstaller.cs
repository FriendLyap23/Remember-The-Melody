using Zenject;

public class BootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInitialization>().To<SequenceClicks>().FromComponentInHierarchy().AsSingle();
    }
}
