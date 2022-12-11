namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void Register_Clicker(object sender, EventArgs e)
    {
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