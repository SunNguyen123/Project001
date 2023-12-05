using AdminModule.Models;
using AdminModule.ViewModels;
using Prism.Events;
using Prism.Regions;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for qlKhoa_AdminView.xaml
    /// </summary>


    [Export]
    [ViewSortHint("02")]

    public partial class qlKhoa_AdminView : UserControl
    {
        private IEventAggregator ev;
        public qlKhoa_AdminView(IEventAggregator ev)
        {
            InitializeComponent();
            this.ev = ev;
     

        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, null);
            Keyboard.ClearFocus();
        }




        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dgvKhoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datacontext = (qlKhoa_AdminViewModels)this.DataContext;
            datacontext.SelectedObject = dgvKhoa.SelectedItem as Khoa;
        }



        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.Key>=Key.D0 && e.Key<=Key.D9) 
            //    ||(e.Key>=Key.NumPad0 && e.Key<=Key.NumPad9) 
            //    || e.Key==Key.Back || e.Key==Key.Enter 
            //    || e.Key == Key.Left || e.Key == Key.Right) { }
            //else
            //{
                
            //    e.Handled = true;
            //}
        }
    }
}
