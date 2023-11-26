using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Resource;
using Libary_ConnectDB;
using Prism.Commands;
using Prism.Services.Dialogs;
using AdminModule.Models;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Linq;
namespace AdminModule.ViewModels
{
    public class NganhServiceViewModel : BaseModel, IDialogAware
    {
        private string _title="";
        public string Title2
        {
            set 
            {
                SetProperty(ref _title,value);
            }
            get
            {
                return _title;
            }
        }
        private bool check;
        public string Title => _title;
        public DelegateCommand<string> ResultDialog { set; get; }
        public event Action<IDialogResult> RequestClose;
       
        private ObservableCollection<Khoa> _listKhoa;
        public ListCollectionView _dskhoa;
        public ListCollectionView ListKhoa
        {
            get { return _dskhoa; }
            set { SetProperty<ListCollectionView>(ref _dskhoa, value); }
        }
        private string _maNganh;

        public string MaNganh
        {
            get
            {
                return _maNganh;
            }
            set
            {
                SetProperty(ref _maNganh, value);
            }
        }
        private string _tenNganh;

        public string TenNganh
        {
            get
            {
                return _tenNganh;
            }
            set
            {
                SetProperty(ref _tenNganh, value);
            }
        }
        private string _maKhoa;

        public string MaKhoa
        {
            get
            {
                return _maKhoa;
            }
            set
            {
                SetProperty(ref _maKhoa, value);
            }
        }
        private DateTime _namBatDau=DateTime.Now;

        public DateTime NamBatDau
        {
            get { return _namBatDau; }
            set { SetProperty<DateTime>(ref _namBatDau, value); }

        }

        public bool CanCloseDialog()
        {
            return true;
        }
        private IConnectDB connectDB;
        private IDialogService dialogService;
        public NganhServiceViewModel(IConnectDB connectDB,IDialogService dialogService)
        {
            this.connectDB = connectDB;
            this.dialogService = dialogService;
            ResultDialog = new DelegateCommand<string>(ResultMethod);
           
        }

        private async void ResultMethod(string obj)
        {
            if (obj.Trim() == "OK")
            {


                if (check)
                {
                    int count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM NGANH WHERE TenNganh=N'{TenNganh}'");
                    if (!string.IsNullOrWhiteSpace(TenNganh) && count == 0)
                    {
                        await connectDB.ExecuteAsync($"INSERT INTO NGANH  VALUES ('NG'+CAST(NEXT VALUE FOR SE_MANGANH AS CHAR(5)),N'{TenNganh}','{((Khoa)ListKhoa.CurrentItem).MaKhoa}','{NamBatDau.ToString("yyyy-MM-d")}')");
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
                    int count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM NGANH WHERE TenNganh=N'{TenNganh}' AND NOT MaNganh='{MaNganh}'");
                    if (!string.IsNullOrWhiteSpace(TenNganh) && count == 0)
                    {
                        await connectDB.ExecuteAsync($"UPDATE NGANH SET TenNganh=N'{TenNganh}',MaKhoa='{((Khoa)ListKhoa.CurrentItem).MaKhoa}',NamBatDau='{NamBatDau.ToString("yyyy-MM-d")}' WHERE MaNganh='{MaNganh}'");
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
            
            }
            else
            {
                var bt = ButtonResult.Cancel;
                var dialogresult = new DialogResult(bt);
                RequestClose?.Invoke(dialogresult);
            }
        }

        public void OnDialogClosed()
        {
           
        }
        private async Task LoadKhoa()
        {

            _listKhoa = await connectDB.GetDataAsync<Khoa>("SELECT MaKhoa,TenKhoa FROM KHOA");
            ListKhoa = new ListCollectionView(_listKhoa);
            
        }
        public async void OnDialogOpened(IDialogParameters parameters)
        {
            await  LoadKhoa();
            check = parameters.GetValue<bool>("flag");
            if (check)
            {
                Title2 = "Thêm ngành";

            }
            else
            {
                Title2 = "Sửa ngành";
                Nganh nganh = parameters.GetValue<Nganh>("obj");
                TenNganh = nganh.TenNganh;
                Khoa khoa = _listKhoa.FirstOrDefault(c => c.MaKhoa == nganh.MaKhoa);
                ListKhoa.MoveCurrentTo(khoa);
                MaNganh = nganh.MaNganh;
                NamBatDau = nganh.NamBatDau;
                MaKhoa = nganh.MaKhoa;

            }
        }
    }
}
