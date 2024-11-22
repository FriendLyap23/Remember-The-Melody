using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRecordStepStorage>().To<RecordStepStorage>().AsSingle();

        Container.Bind<SequenceClicks>().FromComponentInHierarchy().AsTransient();

        Container.Bind<BlockInterations>().FromComponentInHierarchy().AsTransient();

        Container.Bind<Score>().FromComponentInHierarchy().AsTransient();
        Container.Bind<Tiles>().FromComponentInHierarchy().AsTransient();
    }
}
