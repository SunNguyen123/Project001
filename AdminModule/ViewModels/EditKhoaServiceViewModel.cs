using System;
using Prism.Services.Dialogs;
using Prism.Mvvm;
using AdminModule.Models;
using Prism.Commands;
using Libary_ConnectDB;
namespace AdminModule.ViewModels
{
    public class EditKhoaServiceViewModel : BindableBase, IDialogAware
    {
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { SetProperty(ref _maKhoa,value); }
        }

        private string _tenKhoa;

        public string TenKhoa
        {
            get { return _tenKhoa; }
            set { SetProperty(ref _tenKhoa, value); }

        }
        private DateTime _namBatDau;

        public DateTime NamBatDau
        {
            get { return _namBatDau; }
            set { SetProperty<DateTime>(ref _namBatDau, value); }

        }

        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { SetProperty(ref _ghiChu, value); }

        }
        public DelegateCommand<string> ResultCommand { set; get; }


        public string Title => "Sửa khoa";

        public event Action<IDialogResult> RequestClose;
        private IConnectDB kn;
        private IDialogService dialogService;
        public EditKhoaServiceViewModel(IConnectDB kn,IDialogService dialogService)
        {
            ResultCommand = new DelegateCommand<string>(CloseDialogMethod);
            this.kn = kn;
            this.dialogService = dialogService;
        }

        private async void CloseDialogMethod(string obj)
        {
            if (obj.Trim() == "OK")
            {
                int count= await kn.CountRecord($"SELECT COUNT(*) FROM KHOA WHERE TenKhoa=N'{TenKhoa}'");
                if (!string.IsNullOrWhiteSpace(TenKhoa) && count==0)
                {
                    await kn.Execute($"UPDATE KHOA SET TenKhoa=N'{TenKhoa}',NamBatDau='{NamBatDau.ToString("yyyy-MM-d")}',Ghichu=N'{GhiChu}' WHERE MaKhoa='{MaKhoa}'");
                    var bt = ButtonResult.OK;
                    var dialogresult = new DialogResult(bt);
                    RequestClose?.Invoke(dialogresult);
                }
                else
                {
                    var ts1 = new DialogParameters();
                    ts1.Add("message1", $"Thông tin bạn vừa nhập đã tồn tại hoặc chưa đầy đủ");
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
            var obj = parameters.GetValue<Khoa>("obj") ;
            MaKhoa = obj.MaKhoa;
            TenKhoa = obj.TenKhoa;
            NamBatDau = obj.NamBatDau;
            GhiChu = obj.GhiChu;
        }
    }
}
