using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation.Provider;

namespace Webcontrol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            urlTextBox.Focus();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(urlTextBox.Text) == false)
            {
                ActiveWindow activeW = new ActiveWindow(urlTextBox.Text.Split(new char[] { '\n', '\r' }).ToList());
                App.Current.MainWindow = activeW;
                this.Close();
                activeW.Show();
                ButtonAutomationPeer peer = new ButtonAutomationPeer(activeW.nextButton);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }
    }
}
