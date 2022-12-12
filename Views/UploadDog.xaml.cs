using System.Text.RegularExpressions;

namespace ProyectoPrograFinalDefinitivoP2.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class UploadDog : ContentPage
{
    public string ItemId
    {
        set { LoadDog(value); }
    }

    public UploadDog()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.dogs.txt";

        LoadDog(Path.Combine(appDataPath, randomFileName));
    }

	private async void UploadDogClicked(object sender, EventArgs e)
	{
        //Validation complete information
        if (nameInput.Text != null && ageInput.Text != null && addressInput.Text != null &&
            descriptionInput.Text != null && colorInput.Text != null && sizeInput.Text != null &&
            emailInput.Text != null)
        {
            //Validation Name
            for (int i = 0; i < nameInput.Text.Length; i++)
            {
                if (Char.IsDigit(nameInput.Text[i]))
                {
                    await DisplayAlert("Alert", "The Name should not have numbers", "OK");
                    break;
                }
            }
            //Validation AproxAge
            for (int i = 0; i < ageInput.Text.Length; i++)
            {
                if (!Char.IsDigit(ageInput.Text[i]))
                {
                    await DisplayAlert("Alert", "The aprox. age should not have words", "OK");
                    break;
                }
            }
            try
            {
                if (Int32.Parse(ageInput.Text) <= 0 || Int32.Parse(ageInput.Text) > 25)
                {
                
                    await DisplayAlert("Alert", "Please, enter a real aprox. age", "OK");
                    return;
                
                }
            }
            catch (FormatException) { }
            //Validation Address
            if (addressInput.Text.Length < 8)
            {
                await DisplayAlert("Alert", "The length of the address should be longer", "OK");
                return;
            }
            //Validation Description
            if (descriptionInput.Text.Length < 5)
            {
                await DisplayAlert("Alert", "The length of the description should be longer", "OK");
                return;
            }
            //Validation ContactMail
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(emailInput.Text, expresion))
            {
                await DisplayAlert("Alert", "Please, enter a valid mail", "OK");
                return;
            }
            if (BindingContext is Models.Dog dog)
            {
                string[] datos = new string[8];
                datos[0] = nameInput.Text;
                datos[1] = ageInput.Text;
                datos[2] = addressInput.Text;
                datos[3] = descriptionInput.Text;
                datos[4] = colorInput.Text;
                datos[5] = sizeInput.Text;
                datos[6] = emailInput.Text;

                if (rb1.IsChecked)
                {
                    datos[7] = "dog1.webp";
                }
                if (rb2.IsChecked)
                {
                    datos[7] = "dog2.webp";
                }
                if (rb3.IsChecked)
                {
                    datos[7] = "dog3.webp";
                }
                if (rb4.IsChecked)
                {
                    datos[7] = "dog4.webp";
                }
                if (rb5.IsChecked)
                {
                    datos[7] = "dog5.webp";
                }
                if (rb6.IsChecked)
                {
                    datos[7] = "dog6.webp";
                }
               
                File.WriteAllLines(dog.Filename, datos);


            }
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await DisplayAlert("Alert", "Please, complete all the information", "OK");
        }
    }

    private void LoadDog(string fileName)
    {
        Models.Dog dogModel = new Models.Dog();
        dogModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            int cont = 0;
            foreach (string line in File.ReadLines(fileName))
            {
                if (cont == 0)
                {
                    dogModel.Name = line;
                }
                if (cont == 1)
                {
                    dogModel.Age = line;
                }
                if (cont == 2)
                {
                    dogModel.Address = line;
                }
                if (cont == 3)
                {
                    dogModel.Description = line;
                }
                if (cont == 4)
                {
                    dogModel.Color = line;
                }
                if (cont == 5)
                {
                    dogModel.Size = line;
                }
                if (cont == 6)
                {
                    dogModel.Email = line;
                }
                if (cont == 7)
                {
                    dogModel.imageRoute = line;
                }
                cont++;
            }
        }

        BindingContext = dogModel;
    }

    private async void DeleteDogClicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Dog dog)
        {
            // Delete the file.
            if (File.Exists(dog.Filename))
                File.Delete(dog.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}