using Microsoft.Maui.ApplicationModel.Communication;
using ProyectoPrograFinalDefinitivoP2.Models;

namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
    }

    private async void LoginButton(object sender, EventArgs e)
    {
        string appDataPath = FileSystem.AppDataDirectory;
        await Navigation.PushModalAsync(new DogPage());

    }

    async void RegisterButton(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }
}