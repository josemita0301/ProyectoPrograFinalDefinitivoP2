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
        if (BindingContext is Models.Dog dog)
        {
            string[] datos = new string[7];
            datos[0] = nameInput.Text;
            datos[1] = ageInput.Text;
            datos[2] = addressInput.Text;
            datos[3] = descriptionInput.Text;
            datos[4] = colorInput.Text;
            datos[5] = sizeInput.Text;
            datos[6] = emailInput.Text;

            File.WriteAllLines(dog.Filename, datos);
        }

        await Shell.Current.GoToAsync("..");
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