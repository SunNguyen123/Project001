using System;
using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Regions;
using Libary_ConnectDB;
using Library_Dialog;
using Prism.Services.Dialogs;
using AdminModule.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Resource;
namespace AdminModule.ViewModels
{


    public class qlSinhVien_AdminViewModel : BindableBase, IRegionMemberLifetime
    {
        private int _countRecord;
        private SinhVienProvider _sinhViennProvider;
       
        private string[] _dkTimKiem = { "Mã","Tên"};

        public string[] DieuKienTK
        {
            get { return _dkTimKiem ; }
            set { _dkTimKiem = value; }
        }
        private string _gtTk;

        public string GiatriTK
        {
            get { return _gtTk; }
            set { _gtTk = value; }
        }
        private string _dk = "Mã";

        public string DieuKienTimKiem
        {
            get { return _dk; }
            set
            {
                SetProperty(ref _dk, value);
            }
        }
        private string sqlLoadFull = "SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa";
        public DelegateCommand ThemSVCommand { set; get; }
        public DelegateCommand<string> TimKiemCommand { get; set; }
        public int CountRecord
        {
            get { return _countRecord; }
            set { SetProperty<int>(ref _countRecord, value); }
        }
        private AsyncVirtualCollection<SinhVien> _listSV;
        public AsyncVirtualCollection<SinhVien> ListSV 
        {
            get
            {
                return _listSV;
            }
            set => SetProperty<AsyncVirtualCollection<SinhVien>>(ref _listSV,value);
        }
        public bool KeepAlive => true;
        private IConnectDB connect;
        private IDialogService dialogService;
        public qlSinhVien_AdminViewModel(IConnectDB connect,IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.connect = connect;
            
            LoadData("D");
            CountRecord = ListSV.Count;
            ThemSVCommand = new DelegateCommand(ThemSVMethod);
            TimKiemCommand = new DelegateCommand<string>(TimKiemCommandMethod);

        }

        private void TimKiemCommandMethod(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Trim()) || obj == "")
            {
                LoadData(sqlLoadFull);

            }
            else
            {

                if (DieuKienTimKiem.Trim() == "Mã")
                {
                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa WHERE MaNganh LIKE '{obj}%'");
                }
                else
                {

                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa WHERE TenNganh LIKE N'{obj}%'");
                }
            }
        }

        private void LoadData(string sqlLoadFull)
        {
            _sinhViennProvider = new SinhVienProvider(connect);
            ListSV = new AsyncVirtualCollection<SinhVien>(_sinhViennProvider, 50, 2000);
        }

        private void ThemSVMethod()
        {
            var result = new DialogParameters();
            result.Add("flag",true);
            dialogService.ShowDialog("AddSinhVien_AdminView",result,(p)=> 
            {
                LoadData("d");            
            });
        }

        private async Task<ObservableCollection<SinhVien>> GetListSV()
        {
            
          return  await connect.GetDataAsync<SinhVien>("SELECT * FROM SINHVIEN");
        }
    }
}
