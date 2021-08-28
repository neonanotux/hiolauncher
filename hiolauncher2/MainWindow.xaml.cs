using Microsoft.Web.WebView2.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hiolauncher2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ww2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {

            ww2.CoreWebView2.Settings.UserAgent = "hiolauncher2";
            ww2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            ww2.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;

            Topmost = false;
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            ww2.Focus();

        }

        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            e.RequestHeaders.SetHeader("X-Authorization", "My Auth");
        }

        private void ww2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {

                if (MessageBox.Show("Close Application?", "HIO Launcher", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    // do no stuff
                }
                else
                {
                    // close app
                    System.Windows.Application.Current.Shutdown();
                }

            }

            if (e.Key == Key.F10)
            {

                if (MessageBox.Show("Remove all settings?", "HIO Launcher", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    // do no stuff
                }
                else
                {
                    // remove all settings
                    ww2.CoreWebView2.CookieManager.DeleteAllCookies();
                    MessageBox.Show("App reset done!");
                    ww2.Reload();
                }

            }

            if (e.Key == Key.F11)
            {
                if (this.Topmost == false)
                {
                    Visibility = Visibility.Collapsed;
                    Topmost = true;
                    WindowStyle = WindowStyle.None;
                    ResizeMode = ResizeMode.NoResize;
                    Visibility = Visibility.Visible;
                    WindowState = WindowState.Maximized;
                    ww2.Focus();
                }
                else
                {
                    Topmost = false;
                    //this.Visibility = Visibility.Collapsed;
                    //this.Visibility = Visibility.Visible;
                    //this.WindowStyle = WindowStyle.None;
                    //this.WindowStyle = WindowStyle.SingleBorderWindow;
                    //this.WindowState = WindowState.Normal;
                    //this.WindowStyle = WindowStyle.None;
                    //this.WindowState = WindowState.Maximized;
                    ResizeMode = System.Windows.ResizeMode.CanResize;
                    WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
                    WindowState = System.Windows.WindowState.Normal;
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                    ww2.Focus();

                }

            }
        }
    }
}
