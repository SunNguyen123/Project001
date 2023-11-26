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
        private string _loaiTk;

        public string LoaiTK
        {
            get { return _loaiTk; }
            set { _loaiTk = value; }
        }
        private string _dk =  "Mã";

        public string DieuKienTimKiem
        {
            get { return _dk; }
            set
            {
                SetProperty(ref _dk, value, nameof(DieuKienTimKiem));
            }
        }
        public DelegateCommand ThemSVCommand { set; get; }
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
            this._sinhViennProvider = new SinhVienProvider(connect);
            ListSV =new AsyncVirtualCollection<SinhVien>(_sinhViennProvider,50,2000);
            CountRecord = ListSV.Count;
            ThemSVCommand = new DelegateCommand(ThemSVMethod);

        }

        private void ThemSVMethod()
        {
            dialogService.ShowDialog("AddSinhVien_AdminView");
        }

        private async Task<ObservableCollection<SinhVien>> GetListSV()
        {
          return  await connect.GetDataAsync<SinhVien>("SELECT * FROM SINHVIEN");
        }
    }
}
