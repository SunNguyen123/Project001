using System;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Prism.Common;
using Prism.Commands;
namespace Library_Dialog.ViewModels
{
    public class DialogDeleteViewModel : BindableBase, IDialogAware
    {
        public string Title => "Thong bao";
        public DelegateCommand<string> ResutlDialog { set; get; }
        public event Action<IDialogResult> RequestClose;
        public DialogDeleteViewModel()
        {
            ResutlDialog = new DelegateCommand<string>(RequestDialog);
        }
        private string _message;

        public string Message1
        {
            get { return _message; }
            set { SetProperty(ref _message,value); }
        }

        private void RequestDialog(string obj)
        {
            if (obj=="OK") 
            {
                var result = new DialogResult(ButtonResult.OK);
                RequestClose?.Invoke(result);
            }
            else 
            {
                var result = new DialogResult(ButtonResult.Cancel);
                RequestClose?.Invoke(result);
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message1 = parameters.GetValue<string>("count");
        }
    }
}
