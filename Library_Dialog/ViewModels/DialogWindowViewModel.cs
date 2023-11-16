using System;
using Prism.Services.Dialogs;
using Prism.Mvvm;
using Prism.Commands;

namespace Library_Dialog.ViewModels
{
    public class DialogWindowViewModel : BindableBase, IDialogAware
    {
        public string Title => "Thông báo";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }
        public DelegateCommand<string> ResultDialog { set; get; }
        
        public DialogWindowViewModel()
        {
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
        private string _message1;

        public string Message1
        {
            get { return _message1; }
            set { SetProperty(ref _message1, value, Message1); }
        }

        private string _message2;

        public string Message2
        {
            get { return _message2; }
            set { SetProperty(ref _message2, value, Message2); }
        }
        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message1 = parameters.GetValue<string>("message1");
            Message2 = parameters.GetValue<string>("message2");
        }
    }
}
