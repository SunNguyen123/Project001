using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
