using ProyectoPrograFinalDefinitivoP2.Models;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoPrograFinalDefinitivoP2.Views;

public partial class FormPage : ContentPage
{
    public FormPage()
    {
        InitializeComponent();
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

            /**
            // enviar mensaje de confirmación Whatsapp
            
            string number = "+593 " + "987629927"; // LEER DE ARCHIVO
            SendWhatsapp(number, "Hi! The adoption process has started!");**/

            SendMailNewOwner();
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

    public void SendMailNewOwner()
    {
        MailMessage correo = new MailMessage();
        correo.From = new MailAddress("betterhomesender@gmail.com", "Better Home", System.Text.Encoding.UTF8);//Correo de salida
        correo.To.Add("antocortesl27@gmail.com"); //Correo destino? amelycordova49@gmail.com
        correo.Subject = "Correo de adopcion"; //Asunto
        correo.Body = "Your request has been processed! The current owner will get in contact with you soon."; //Mensaje del correo
        correo.IsBodyHtml = true;
        correo.Priority = MailPriority.Normal;
        SmtpClient smtp = new SmtpClient();
        smtp.UseDefaultCredentials = false;
        smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
        smtp.Port = 587; //Puerto de salida
        smtp.Credentials = new System.Net.NetworkCredential("betterhomesender@gmail.com", "pzxmsztrhenlvjcu");//Cuenta de correo
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        smtp.EnableSsl = true;//True si el servidor de correo permite ssl
        smtp.Send(correo);
    }
    private async void SendWhatsapp(string phoneNumber, string message)
    {
        bool supportsUri = await Launcher.Default.CanOpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");
        if (supportsUri)
            await Launcher.Default.OpenAsync($"whatsapp://send?phone=+{phoneNumber}&text={message}");

        else
            await App.Current.MainPage.DisplayAlert("Error", "Unable to open WhatsApp.", "OK");

    }
}
