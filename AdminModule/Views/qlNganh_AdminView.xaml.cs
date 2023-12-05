using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using AdminModule.Models;
using AdminModule.ViewModels;

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for qlNganh_AdminView.xaml
    /// </summary>
    public partial class qlNganh_AdminView : UserControl
    {
        public qlNganh_AdminView()
        {
            InitializeComponent();
        }





        private void nganh_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, null);
            Keyboard.ClearFocus();
        }

        private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
