using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using LoginModule.Model;
using Prism.Events;
namespace Sell.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private IEventAggregator ev;
        public LoginView(IEventAggregator ev)
        {
            InitializeComponent();
            this.ev = ev;
            ev.GetEvent<PackageLogin>().Subscribe(LoginAction);
        }

        private void LoginAction((string ,string) a)
        {
            MessageBox.Show(a.Item2);
            this.DialogResult = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
