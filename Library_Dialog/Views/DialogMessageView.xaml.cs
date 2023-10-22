using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Services.Dialogs;
using Prism.Events;
using Prism.Ioc;
namespace Library_Dialog.Views
{
    /// <summary>
    /// Interaction logic for DialogMessageView.xaml
    /// </summary>
    public partial class DialogMessageView : Window,IDialogWindow
    {
        public DialogMessageView()
        {
            InitializeComponent();
        }

        public IDialogResult Result 
        {
            get => new DialogResult(ButtonResult.OK);
            set => throw new NotImplementedException(); 
        }
    }
}
