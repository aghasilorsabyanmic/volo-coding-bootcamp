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
using System.Diagnostics;

namespace HtmlSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch watch = new Stopwatch();

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
                    var task = client.GetStringAsync(textBoxUrl.Text);
                    textBoxHtml.Text = "Please wait...";
                    watch.Start();
                    Debug.WriteLine("Before await");
                    var text = await task;
                    Debug.WriteLine("After await");
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
                finally
                {
                    watch.Stop();
                    MessageBox.Show(watch.ElapsedMilliseconds.ToString());
                }
            }
        }

        private void textBoxUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("Text changed");

            if(Uri.IsWellFormedUriString(textBoxUrl.Text, UriKind.Absolute))
            {
                btnGrabHtml.IsEnabled = true;
            }
        }
    }
}
