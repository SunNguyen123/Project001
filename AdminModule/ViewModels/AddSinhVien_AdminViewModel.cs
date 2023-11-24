using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
namespace AdminModule.ViewModels
{
    public class AddSinhVien_AdminViewModel : BindableBase, IDialogAware
    {
        public string Title => "Them sinh vien";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
         
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }
    }
}
