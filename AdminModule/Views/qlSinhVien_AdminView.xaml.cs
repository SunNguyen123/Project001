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
using AdminModule.ViewModels;
using AdminModule.Models;

namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for qlSinhVien_AdminView.xaml
    /// </summary>


    [Export]
    [ViewSortHint("03")]
    public partial class qlSinhVien_AdminView : UserControl
    {
        public qlSinhVien_AdminView()
        {
            InitializeComponent();
        }

        private void DatagridNew2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qlSinhVien_AdminViewModel qlSinhVien_ = (qlSinhVien_AdminViewModel)this.DataContext;
            qlSinhVien_.SelectSV = dgvSV.SelectedItem as SinhVien;
        }
    }
}
