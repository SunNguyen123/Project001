using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for qlKhoa_AdminView.xaml
    /// </summary>


    [Export]
    [ViewSortHint("02")]

    public partial class qlKhoa_AdminView : UserControl
    {
        public qlKhoa_AdminView()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this,null);
            Keyboard.ClearFocus();
        }
    }
}
