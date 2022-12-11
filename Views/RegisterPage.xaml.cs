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
        //Validation complete information
        if(userNameInput.Text !=null && nameInput.Text!=null && surnameInput.Text != null && 
            mailInput.Text != null && passwordInput.Text != null && areaInput.Text != null && 
            phoneInput.Text != null )
        {
            //Validation UserName
            for (int i = 0; i < userNameInput.Text.Length; i++)
            {
                if (Char.IsWhiteSpace(userNameInput.Text[i]))
                {
                    await DisplayAlert("Alert", "The User Name should not have white spaces", "OK");
                    break;
                }
            }
            //Validation Name
            for (int i = 0; i < nameInput.Text.Length; i++)
            {
                if (Char.IsDigit(nameInput.Text[i]))
                {
                    await DisplayAlert("Alert", "The Name should not have numbers", "OK");
                    break;
                }
            }
            //Validation Surname
            for (int i = 0; i < surnameInput.Text.Length; i++)
            {
                if (Char.IsDigit(surnameInput.Text[i]))
                {
                    await DisplayAlert("Alert", "The Surname should not have numbers", "OK");
                    break;
                }
            }
            //Validation Mail
            for (int i = 0; i < mailInput.Text.Length; i++)
            {
                if (Char.IsWhiteSpace(mailInput.Text[i]))
                {
                    await DisplayAlert("Alert", "Please, enter a valid mail", "OK");
                    break;
                }
            }
            //Validation Password
            if (passwordInput.Text.Length < 8)
            {
                await DisplayAlert("Alert", "The length of the password should be longer", "OK");
            }
            //Validation Area 
            if (areaInput.Text.Length < 8)
            {
                await DisplayAlert("Alert", "The length of the password should be longer", "OK");
            }
            //Validation PhoneNumber
            if (phoneInput.Text.Length < 10 || phoneInput.Text.Length > 10)
            {
                await DisplayAlert("Alert", "The phone number should have 10 numbers", "OK");
            }
            else
            {
                for (int i = 0; i < phoneInput.Text.Length; i++)
                {
                    if (!Char.IsDigit(phoneInput.Text[i]))
                    {
                        await DisplayAlert("Alert", "The phone number should not have words", "OK");
                        break;
                    }
                }
            }
        }
        else
        {
            await DisplayAlert("Alert", "Please, complete all the information", "OK");
        }
    }
}