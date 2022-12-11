namespace ProyectoPrograFinalDefinitivoP2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.RegisterPage), typeof(Views.RegisterPage));
        Routing.RegisterRoute(nameof(Views.DogPage), typeof(Views.DogPage));
    }
}
