using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Threading;
using AlphaChiTech.Virtualization;
namespace Sell.Views
{
    /// <summary>
    /// Interaction logic for SellApp.xaml
    /// </summary>
    public partial class SellApp : Window
    {
        public SellApp()
        {
            InitializeComponent();
            if (!VirtualizationManager.IsInitialized)
            {
                //set the VirtualizationManager’s UIThreadExcecuteAction. In this case
                //we’re using Dispatcher.Invoke to give the VirtualizationManager access
                //to the dispatcher thread, and using a DispatcherTimer to run the background
                //operations the VirtualizationManager needs to run to reclaim pages and manage memory.
                VirtualizationManager.Instance.UIThreadExcecuteAction = a => Application.Current.Dispatcher.Invoke(a);
                new DispatcherTimer(TimeSpan.FromMilliseconds(10),
                    DispatcherPriority.Background,
                    delegate { VirtualizationManager.Instance.ProcessActions(); },
                    this.Dispatcher).Start();
            }

          
        }



        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton== MouseButton.Left) 
            {
                this.DragMove();
            }
            if (e.ClickCount==2 & e.ChangedButton==MouseButton.Left) 
            {
                if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
                else this.WindowState = WindowState.Normal;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //FocusManager.SetFocusedElement(this, null);
            //Keyboard.ClearFocus();
        }

        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState==WindowState.Normal) 
            {
                this.WindowState = WindowState.Maximized;
            }
            else 
            { 
                this.WindowState = WindowState.Normal;

            }
        }

        private void Button2_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            shell.OpacityMask = new SolidColorBrush() { Color =Colors.Blue, Opacity = 1 };
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            shell.OpacityMask = new SolidColorBrush() {Color= Colors.Blue };

        }
    }
}
