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

        //Validation complete information
        if (motivInput.Text != null)
            //&& (moreDogsY.IsChecked | moreDogsN.IsChecked) && (prevDogsY.IsChecked | prevDogsN.IsChecked))
        {
            //Validation motive
            if (motivInput.Text.Length <= 3)
            {
                await DisplayAlert("Alert", "Please enter a valid motivation", "OK");
                return;
            }

            if (prevDogsY.IsChecked == true)
            {
                //Validation prev dogs
                if (prevDogsInput.Text.Length <= 3)
                {
                    await DisplayAlert("Alert", "Please provide information about your previous dog(s)", "OK");
                    return;
                }
            }
            else
            {
                prevDogsInput.Text = "";
            }

            //Validation more dogs radio button
            if (prevDogsY.IsChecked == false && prevDogsN.IsChecked == false)
            {
                await DisplayAlert("Alert", "Please select an option in Previous Dogs", "OK");
                return;
            }
            //Validation prev dogs radio button
            if (moreDogsY.IsChecked == false && moreDogsN.IsChecked == false)
            {
                await DisplayAlert("Alert", "Please select an option in More Dogs", "OK");
                return;
            }

            // enviar mensaje de confirmación
            
            string number = "+593 " + "987629927"; // LEER DE ARCHIVO
            SendWhatsapp(number, "Hi! The adoption process has started!");
        }
        else
        {
            await DisplayAlert("Alert", "Please, complete the information needed", "OK");
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
