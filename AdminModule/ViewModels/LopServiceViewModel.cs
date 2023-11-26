using System;
using Resource;
using Prism.Services.Dialogs;
using AdminModule.Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Linq;
using Libary_ConnectDB;
using System.Threading.Tasks;

namespace AdminModule.ViewModels
{
    public class LopServiceViewModel : BaseModel, IDialogAware
    {
        private string _title = "";
        public string Title2
        {
            set
            {
                SetProperty(ref _title, value);
            }
            get
            {
                return _title;
            }
        }
        private string _maLop;

        public string MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }

        private IConnectDB connectDB;
        private IDialogService dialogService;
        public LopServiceViewModel(IConnectDB connectDB, IDialogService dialogService)
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
                    int count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM LOP WHERE TenLOP=N'{TenLop}'");
                    if (!string.IsNullOrWhiteSpace(TenLop) && count == 0)
                    {
                        await connectDB.ExecuteAsync($"INSERT INTO LOP  VALUES ('LP'+CAST(NEXT VALUE FOR SE_MALOP AS CHAR(5)),N'{TenLop}','{((KhoaHoc)ListKH.CurrentItem).MaKhoaHoc}','{((Nganh)ListNganh.CurrentItem).MaNganh}',N'{GhiChu}')");
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
                    int count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM NGANH WHERE TenNganh=N'{TenLop}' AND NOT MaLop='{MaLop}'");
                    if (!string.IsNullOrWhiteSpace(TenLop) && count == 0)
                    {
                        await connectDB.ExecuteAsync($"UPDATE LOP SET TenLop=N'{TenLop}',MaKhoaHoc='{((KhoaHoc)ListKH.CurrentItem).MaKhoaHoc}',MaNganh='{((Nganh)ListNganh.CurrentItem).MaNganh}',Ghichu=N'{GhiChu}' WHERE MaLop='{MaLop}'");
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

        private string _tenLop;
        public string TenLop
        {
            get { return _tenLop; }
            set { SetProperty(ref _tenLop,value); }
        }
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { SetProperty(ref _ghiChu, value); }
        }

        private bool check;
        public string Title => "Lop";
        public DelegateCommand<string> ResultDialog { set; get; }
        public event Action<IDialogResult> RequestClose;

        //DANH SACH NGANH
        private ObservableCollection<Nganh> _listNganh;
        public ListCollectionView _dsNganh;
        public ListCollectionView ListNganh
        {
            get { return _dsNganh; }
            set { SetProperty<ListCollectionView>(ref _dsNganh, value); }
        }
        //DANH SACH KHOA HOC
        private ObservableCollection<KhoaHoc> _listKH;
        public ListCollectionView _dsKH;
        public ListCollectionView ListKH
        {
            get { return _dsKH; }
            set { SetProperty<ListCollectionView>(ref _dsKH, value); }
        }


        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }
        private async Task LoadKH()
        {

            _listNganh = await connectDB.GetDataAsync<Nganh>("SELECT MaNganh,TenNganh FROM NGANH");
            ListNganh = new ListCollectionView(_listNganh);

        }
        private async Task LoadNganh()
        {

            _listKH = await connectDB.GetDataAsync<KhoaHoc>("SELECT MaKhoaHoc,TenKhoaHoc FROM KHOAHOC");
            ListKH = new ListCollectionView(_listKH);

        }
        public async void OnDialogOpened(IDialogParameters parameters)
        {
           await LoadKH();
           await LoadNganh();

            check = parameters.GetValue<bool>("flag");
            if (check)
            {
                Title2 = "Thêm lớp";

            }
            else
            {
                Title2 = "Sửa lớp";
                Lop lop = parameters.GetValue<Lop>("obj");
                TenLop = lop.TenLop;
                Nganh nganh1 = _listNganh.FirstOrDefault(c => c.MaNganh == lop.MaNganh);
                ListNganh.MoveCurrentTo(nganh1);

                KhoaHoc khoaHoc = _listKH.FirstOrDefault(c => c.MaKhoaHoc == lop.MaKhoaHoc);
                ListKH.MoveCurrentTo(khoaHoc);
                MaLop = lop.MaLop;
                GhiChu = lop.GhiChu;
            }
        }
    }
}
