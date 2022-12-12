

namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class DogPage : ContentPage
{
	public DogPage()
	{
		InitializeComponent();

        BindingContext = new Models.AllDogs();
    }

    protected override void OnAppearing()
    {
        ((Models.AllDogs)BindingContext).LoadDogs();

    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UploadDog));
    }

    private async void dogsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var dog = (Models.Dog)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(UploadDog)}?{nameof(UploadDog.ItemId)}={dog.Filename}");

            // Unselect the UI
            dogsCollection.SelectedItem = null;
        }
    }
}