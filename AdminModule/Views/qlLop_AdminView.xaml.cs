using AdminModule.Models;
using AdminModule.ViewModels;
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

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for qlLop_AdminView.xaml
    /// </summary>
    public partial class qlLop_AdminView : UserControl
    {
        public qlLop_AdminView()
        {
            InitializeComponent();
        }

        private void lop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, null);
            Keyboard.ClearFocus();
        }

        private void dgvLop_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void dgvLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datacontext = (qlLop_AdminViewModel)this.DataContext;
            datacontext.SelectedObject = dgvLop.SelectedItems.Cast<Lop>().ToList();
        }
    }
}
