using Zenject;

public class Installers : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SetupWorld>().AsSingle();
    }
}
