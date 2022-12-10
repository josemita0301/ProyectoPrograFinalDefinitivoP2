namespace ProyectoPrograFinalDefinitivoP2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Login), typeof(Views.Login));
    }
}
