using System;
using System.Collections.Generic;
using Libary_ConnectDB;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace AdminModule.ViewModels
{
    public class AddKhoaServiceViewModel : BindableBase, IDialogAware
    {
        private IConnectDB connectDB;
        public DelegateCommand<string> ResultDialog { set; get; }
        public AddKhoaServiceViewModel(IConnectDB connectDB)
        {
            this.connectDB = connectDB;
            ResultDialog = new DelegateCommand<string>(CloseDialog);
        }

        private void CloseDialog(string obj)
        {
            ButtonResult result = ButtonResult.None;
            if (obj == "OK")
            {

                result = ButtonResult.OK;
            }
            else
            {
                result = ButtonResult.Cancel;
            }
            RequestClose?.Invoke(new DialogResult(result));
        }

        public string Title => "Thêm Khoa";

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
