using System;
using Libary_ConnectDB;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Services.Dialogs;
using AdminModule.Models;
namespace AdminModule.ViewModels
{
    public class AddKhoaServiceViewModel : BindableBase, IDialogAware
    {


        private string _tenKhoa;
        public string TenKhoa 
        {
            set => SetProperty(ref _tenKhoa,value);
            get => _tenKhoa; 
        }
        private string _ghichu="";

        public string GhiChu 
        {
            set => SetProperty(ref _ghichu, value);
            get => _ghichu;
        }
        private DateTime _ngayTl = DateTime.Now;
        public DateTime NgayThanhLap 
        {
            set => SetProperty<DateTime>(ref _ngayTl, value);
            get => _ngayTl;
        } 

        private IConnectDB connectDB;
        public DelegateCommand<string> ResultDialog { set; get; }
        private IDialogService dialogService;
        public AddKhoaServiceViewModel(IConnectDB connectDB,IDialogService dialogService)
        {
            this.connectDB = connectDB;
            this.dialogService = dialogService;
            ResultDialog = new DelegateCommand<string>(CloseDialog);
        }

        private async void CloseDialog(string obj)
        {
          
            if (obj == "OK")
            {
                int count = await connectDB.CountRecordAsync($"SELECT COUNT(TenKhoa) FROM KHOA WHERE TenKhoa=N'{TenKhoa}'");
                if (!string.IsNullOrWhiteSpace(TenKhoa) && count == 0)
                {
                    Random rd = new Random();
                    string maKhoa = "KH" + (rd.Next(1,100)+rd.Next(10,80)/2 + 1+rd.Next(1,100)).ToString();
                    _dsKhoa.Add(new Khoa()
                    {
                        STT = _dsKhoa.Count + 1,
                        MaKhoa = maKhoa,
                        TenKhoa = TenKhoa,
                        NamBatDau = NgayThanhLap,
                        GhiChu = GhiChu,
                    }) ;
                    
               await connectDB.ExecuteAsync($"INSERT INTO KHOA VALUES('{maKhoa}',N'{TenKhoa}','{NgayThanhLap.ToString("yyyy-MM-d")}',N'{GhiChu}')");
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
                else 
                {
                    var ts1 = new DialogParameters();
                    ts1.Add("message1", "Tên khoa bạn nhập đã tồn tại!");
                    ts1.Add("message2", "Vui lòng thử lại sau !");


                    dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                    {
                        if (r.Result == ButtonResult.OK)
                        {

                        }

                    });
                }
            }
            else
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            }
            
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
        private ObservableCollection<Khoa> _dsKhoa;
        public void OnDialogOpened(IDialogParameters parameters)
        {
            _dsKhoa = parameters.GetValue<ObservableCollection<Khoa>>("objs");
        }
    }
}
