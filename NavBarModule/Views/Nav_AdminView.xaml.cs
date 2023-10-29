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

namespace NavBarModule.Views
{
    /// <summary>
    /// Interaction logic for Nav_AdminView.xaml
    /// </summary>
    public partial class Nav_AdminView : UserControl
    {
        public Nav_AdminView()
        {
            InitializeComponent();
            begin.IsChecked = true;
        }

        private void RadioButton_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RadioButton radioButton = sender as RadioButton;
                if (radioButton != null)
                {
                    radioButton.IsChecked = true;
                    // Thực hiện hoạt động tương ứng khác
                }
            }
        }

        private void StackPanel_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
