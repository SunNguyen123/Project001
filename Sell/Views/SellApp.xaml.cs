using System;
using System.Windows;
using System.Windows.Input;


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
            this.Close();
        }
    }
}
