namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class FormPage : ContentPage
{
    public FormPage()
    {
        InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (agree.IsChecked == true)
        {
            submit.IsEnabled = true;
        }
    }
}
