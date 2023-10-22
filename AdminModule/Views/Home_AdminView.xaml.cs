using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace AdminModule.Views
{
    /// <summary>
    /// Interaction logic for Home_AdminView.xaml
    /// </summary>
    /// 

    [Export]
    [ViewSortHint("01")]
    public partial class Home_AdminView : UserControl
    {
        public Home_AdminView()
        {
            InitializeComponent();
        }
    }
}
