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
        SendMailNewOwner();

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
        correo.To.Add("amelycordova49@gmail.com"); //Correo destino?
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
}
