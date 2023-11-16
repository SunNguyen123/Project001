using System;
using Libary_ConnectDB;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Sell.ViewModels
{
    public class ConfigViewModel : BindableBase, IDialogAware
    {
        public string Title => "Config";
        private IConnectDB kn;
        private IDialogService dialogService;
        private string _tenmaychu;

        public string TenMayChu
        {
            get { return _tenmaychu; }
            set { SetProperty(ref _tenmaychu,value); }
        }
        private string  _tenDatabase;

        public string  TenDataBase
        {
            get { return _tenDatabase; }
            set { SetProperty(ref _tenDatabase, value); }
        }

        public DelegateCommand<string> ResultCommand { set; get; }
        public event Action<IDialogResult> RequestClose;
        public ConfigViewModel(IConnectDB kn, IDialogService dialogService)
        {
            ResultCommand = new DelegateCommand<string>(CloseDialogMethod);
            this.kn = kn;
            this.dialogService = dialogService;
            
        }
        private  void CloseDialogMethod(string obj)
        {
            if (obj.Trim() == "OK")
            {
                if (!string.IsNullOrWhiteSpace(TenMayChu) && !string.IsNullOrWhiteSpace(TenDataBase))
                {
                    kn.ConfigDB(TenMayChu,TenDataBase);
                    var bt = ButtonResult.OK;
                    var dialogresult = new DialogResult(bt);
                    RequestClose?.Invoke(dialogresult);
                }
                else
                {
                    var ts1 = new DialogParameters();
                    ts1.Add("message1", $"Thông tin bạn vừa nhập chưa chính xác hoặc đầy đủ");
                    ts1.Add("message2", $"Vui lòng thử lại sau !");
                    dialogService.ShowDialog("DialogWindowView", ts1, (r) => { });
                }
            }
            else
            {
                var bt = ButtonResult.Cancel;
                var dialogresult = new DialogResult(bt);
                RequestClose?.Invoke(dialogresult);
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
          
        }
    }
}
