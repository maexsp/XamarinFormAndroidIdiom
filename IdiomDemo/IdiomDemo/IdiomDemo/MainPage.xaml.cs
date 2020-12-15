using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace IdiomDemo
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonA_OnClicked(object sender, EventArgs e)
        {
            entry.Text = count++.ToString();
        }

        private void ButtonB_OnClicked(object sender, EventArgs e)
        {
            entry.Text = count--.ToString();
        }

        private async void ButtonComposeEmail(object sender, EventArgs e)
        {
            try
            {
                var message = new EmailMessage()
                {
                    To = { "email@gmail.com" },
                    Subject = "Testmail with attachment",
                    Body = "Test",
                };

                var logFile = "AppLogfile.bad";  //Xamarin.Essentials crash! (also on some iOS devices if using .log -> workaround would be to use .txt as a file extension)

                var file = Path.Combine(FileSystem.CacheDirectory, logFile);
                File.WriteAllText(file, "log file data");
                message.Attachments = new List<EmailAttachment>(new []{ new EmailAttachment(file) });
                
                await Email.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
