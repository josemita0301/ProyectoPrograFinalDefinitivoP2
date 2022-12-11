using Microsoft.Maui.ApplicationModel.Communication;
using ProyectoPrograFinalDefinitivoP2.Models;
using System.IO.IsolatedStorage;

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

        string[] archivos = Directory.GetFiles(appDataPath);
        for (int i = 0; i < archivos.Length; i++)
        {
            bool uservalid = false;
            int cont = 0;
            string nombreArchivo = archivos[i];
            foreach (string line in File.ReadLines(nombreArchivo))
            {
                if (cont == 0)
                {
                    if (UsernameField.Text == line)
                    {
                        uservalid= true;
                    }
                }

                if (cont == 1)
                {
                    if (PasswordField.Text == line)
                    {
                        if (uservalid)
                        {
                            await Shell.Current.GoToAsync(nameof(DogPage));
                        }
                    }
                }
                cont++;
            }
        }
            
    }

    async void RegisterButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}