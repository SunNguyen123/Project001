using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Resource.NewControl
{
   public class DatagridNew2:DataGrid
    {


        public DatagridNew2()
        {
                
        }
        private static readonly DependencyProperty LoadingRowProperty = DependencyProperty.Register("IsLoading",typeof(bool),typeof(DatagridNew2));
  public bool IsLoading
        {
            set 
            {
                SetValue(LoadingRowProperty,value);
            }
            get => (bool)GetValue(LoadingRowProperty);
        }
        private static readonly DependencyProperty InitializingRowProperty = DependencyProperty.Register("IsInitializing", typeof(bool), typeof(DatagridNew2));
        public bool IsInitializing
        {
            set
            {
                SetValue(InitializingRowProperty, value);
            }
            get => (bool)GetValue(InitializingRowProperty);
        }

    }
}
