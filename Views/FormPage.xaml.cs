namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class FormPage : ContentPage
{
    public FormPage()
    {
        InitializeComponent();
    }

    private async void SendWhatsapp(string phoneNumber, string message)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");
        if (supportsUri)
            await Launcher.Default.OpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");

        else
            await App.Current.MainPage.DisplayAlert("Error", "Unable to open WhatsApp.", "OK");

    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // enviar mensaje de confirmación
        {
            string number = "+593 " + "987629927"; // LEER DE ARCHIVO
            SendWhatsapp(number, "Hi! The adoption process has started!");
        }

    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (agree.IsChecked == true)
        {
            submit.IsEnabled = true;
        }
    }
}
