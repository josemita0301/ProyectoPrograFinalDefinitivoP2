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

    /**
            if (Email.Default.IsComposeSupported)
            {
                var message = new EmailMessage
                {
                    Subject = "Hello!",
                    Body = "Your adoption process has started! The current owner will get in touch soon.",
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(new[] { "antocortesl27@gmail.com", "anto.27.cortes@gmail.com"})
                };
                message.Attachments.Add(new EmailAttachment(Path.Combine(FileSystem.CacheDirectory, "dotnet_bot.svg")));

             await Email.Default.ComposeAsync(message);
            }
    **/
        


    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (agree.IsChecked == true)
        {
            submit.IsEnabled = true;
        }
    }
}
