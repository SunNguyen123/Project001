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

namespace Resource.PasswordBoxNew
{
    /// <summary>
    /// Interaction logic for PasswordBox2.xaml
    /// </summary>
    public partial class PasswordBox2 : UserControl
    {
        public PasswordBox2()
        {
            InitializeComponent();
        }


        private static readonly DependencyProperty Password2Property = DependencyProperty.Register("Pass",typeof(string),typeof(PasswordBox2),new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,PassChange));
        
        public string Pass 
        {
            get 
            {
                return (string)GetValue(Password2Property);
            }
            set 
            {
                SetValue(Password2Property,value);
                if (Update) 
                {
                    ps.Password = value;
                }
                Update = true;
            }
        
        }


        private static readonly DependencyProperty UpdateProperty = DependencyProperty.Register("Update", typeof(bool), typeof(PasswordBox2));

        public  bool Update
        {
            get
                { 
            
                return (bool)GetValue(UpdateProperty);
            }
            set 
            {
                SetValue(UpdateProperty, value);
            }
        }

        private static void PassChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
  
        }

        private void ps_PasswordChanged(object sender, RoutedEventArgs e)
        {   
            Pass = ps.Password;
            Update = false;
        }
    }
}
