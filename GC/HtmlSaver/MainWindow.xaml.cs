using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HtmlSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnGrabHtml.IsEnabled = false;
        }

        private async void btnGrabHtml_Click(object sender, RoutedEventArgs e)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var text = await client.GetStringAsync(textBoxUrl.Text);
                    textBoxHtml.Text = text;
                    var dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var path = System.IO.Path.Combine(dir, "index.html");
                    File.WriteAllText(path, text);
                }
                catch(HttpRequestException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                catch(Exception exception)
                {
                    MessageBox.Show($"Unknown exception: {exception.Message}");
                }
            }
        }

        private void textBoxUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Uri.IsWellFormedUriString(textBoxUrl.Text, UriKind.Absolute))
            {
                btnGrabHtml.IsEnabled = true;
            }
        }
    }
}
