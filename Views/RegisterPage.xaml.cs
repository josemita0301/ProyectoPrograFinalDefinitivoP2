using static Android.Content.ClipData;

namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class RegisterPage : ContentPage
{


    public RegisterPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.users.txt";


        LoadUser(Path.Combine(appDataPath, randomFileName));
    }

    private void Register_Clicker(object sender, EventArgs e)
    {


        string filename = userNameInput.Text + passwordInput.Text;

        if (BindingContext is Models.User usuario)
            File.WriteAllText(filename, userNameInput.Text + passwordInput.Text);

    }

    private async void ResgiterClick(object sender, EventArgs e)
    {

        if (BindingContext is Models.User user)
        {
            string datos = userNameInput.Text + "\n" + passwordInput;
            File.WriteAllText(user.Filename,datos);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadUser(string fileName)
    {
        Models.User UserModel = new Models.User();
        UserModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            int cont = 0;
            foreach (string line in File.ReadLines(fileName))
            {
                if (cont == 0)
                {
                    UserModel.UserName = line;
                }
                if (cont == 1)
                {
                    UserModel.Password = line;
                }
                cont++;
            }
        }

        BindingContext = UserModel;
    }
}