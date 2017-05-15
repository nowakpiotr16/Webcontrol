using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Webcontrol
{
    /// <summary>
    /// Interaction logic for ActiveWindow.xaml
    /// </summary>
    public partial class ActiveWindow : Window
    {
        public List<string> urls;
        public Random rnd;
        public int currentURL;

        public ActiveWindow(List<string> urls)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            this.Deactivated += Window_Deactivated;

            urls.RemoveAll(o => string.IsNullOrWhiteSpace(o));

            for (int i = 0; i < urls.Count; i++)
            {
                bool isValid = UrlUtilities.TryMakeURLValid(urls[i]);
                if (!isValid)
                    urls.Remove(urls[i]);
            }

            this.urls = urls;
            rnd = new Random();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void OpenBrowserWithURL(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url.Trim());
            }
            catch
            {
                return;
            }
        }

        private void CheckAndOpenURL(string url)
        {
            OpenBrowserWithURL(url);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentURL == urls.Count)
                currentURL = 0;

            CheckAndOpenURL(urls[currentURL]);

            currentURL++;
        }

        private void randomButton_Click(object sender, RoutedEventArgs e)
        {
            CheckAndOpenURL(urls[rnd.Next(urls.Count)]);
        }
    }
}
