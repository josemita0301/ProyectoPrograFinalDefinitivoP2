using System.Text.RegularExpressions;
using System.Linq.Expressions;
using static Android.Provider.MediaStore.Audio;

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

    private async void RegisterClick(object sender, EventArgs e)
    {
        //Validation complete information
        if (userNameInput.Text != null && nameInput.Text != null && surnameInput.Text != null &&
            mailInput.Text != null && passwordInput.Text != null && areaInput.Text != null &&
            phoneInput.Text != null)
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
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(mailInput.Text, expresion))
            {
                await DisplayAlert("Alert", "Please, enter a valid mail", "OK");
                return;
            }
            //Validation Password
            if (passwordInput.Text.Length < 8)
            {
                await DisplayAlert("Alert", "The length of the password should be longer", "OK");
                return;
            }
            //Validation Area 
            if (areaInput.Text.Length < 5)
            {
                await DisplayAlert("Alert", "The length of the area should be longer", "OK");
                return;
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
            if (BindingContext is Models.User user)
            {
                string[] datos = new string[8];
                datos[0] = userNameInput.Text;
                datos[1] = passwordInput.Text;
                datos[2] = nameInput.Text;
                datos[3] = surnameInput.Text;
                datos[4] = mailInput.Text;
                datos[5] = areaInput.Text;
                datos[6] = phoneInput.Text;
                if (rb1.IsChecked)
                {
                    datos[7] = "user1.png";
                }
                if (rb2.IsChecked)
                {
                    datos[7] = "user2.png";
                }
                if (rb3.IsChecked)
                {
                    datos[7] = "user3.png";
                }
                if (rb4.IsChecked)
                {
                    datos[7] = "user4.png";
                }
                if (rb5.IsChecked)
                {
                    datos[7] = "user5.png";
                }
                if (rb6.IsChecked)
                {
                    datos[7] = "user6.png";
                }


                File.WriteAllLines(user.Filename, datos);
            }

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await DisplayAlert("Alert", "Please, complete all the information", "OK");
        }


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