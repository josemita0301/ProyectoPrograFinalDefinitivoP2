using static Android.Content.ClipData;

namespace ProyectoPrograFinalDefinitivoP2.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Login : ContentPage
{
    public string ItemId
    {
        set {Loaduser(value); }
    }

    public Login()
	{
		InitializeComponent();
	}

    private void LoginButton(object sender, EventArgs e)
    {
        string userAndPassword = UsernameField.Text + PasswordField.Text;

        Models.User UserModel = new Models.User();
        UserModel.Filename = userAndPassword;

        if (File.Exists(userAndPassword))
        {

        }

        BindingContext = UserModel;
    }

    private void Loaduser(string fileName)
    {
       
    }
}