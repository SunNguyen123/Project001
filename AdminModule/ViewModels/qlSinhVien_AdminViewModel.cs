using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Libary_ConnectDB;
using Library_Dialog;
using Prism.Services.Dialogs;
using AdminModule.Models;
using System.Threading.Tasks;
using Prism.Commands;
using Resource;
using System.Windows.Data;
using AlphaChiTech.Virtualization;
namespace AdminModule.ViewModels
{


    public class qlSinhVien_AdminViewModel : BindableBase, IRegionMemberLifetime
    {
        private int _countRecord;
             
        private string[] _dkTimKiem = { "Mã","Tên"};
        private Lazy<DelegateCommand> _xoaSVCommand;
        private SinhVien _selecSV;
        public SinhVien SelectSV 
        {
            set => _selecSV = value;
            get => _selecSV; 
        }

        public DelegateCommand XoaSVCommand
        {
            get
            {
               return _xoaSVCommand.Value;
            }
        }
        private Lazy<DelegateCommand> _suaSVCommand;
        public DelegateCommand SuaSVCommand
        {
            get
            {
                return _suaSVCommand.Value;
            }
        }
        private ObservableCollection<SinhVien> _danhsachSV;
        public ObservableCollection<SinhVien> DanhSachSV
        {
            get 
            {

                return _danhsachSV; 
            }
            set
            {
                SetProperty<ObservableCollection<SinhVien>>(ref _danhsachSV,value);
            }
        }
        private ListCollectionView listCollectionViewSV;
        public ListCollectionView ListCollectionViewSV
        {
            get => listCollectionViewSV;
            set => SetProperty<ListCollectionView>(ref listCollectionViewSV,value);



        }
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
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty<bool>(ref _isLoading,value); }
        }

        public string DieuKienTimKiem
        {
            get { return _dk; }
            set
            {
                SetProperty(ref _dk, value);
            }
        }
        public DelegateCommand ThemSVCommand { set; get; }
        public DelegateCommand<string> TimKiemCommand { get; set; }
        public int CountRecord
        {
            get { return _countRecord; }
            set { SetProperty<int>(ref _countRecord, value); }
        }
 
 

        public bool KeepAlive => true;
        private IConnectDB connect;
        private IDialogService dialogService;
        public qlSinhVien_AdminViewModel(IConnectDB connect,IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.connect = connect;
            ThemSVCommand = new DelegateCommand(ThemSVMethod);
            TimKiemCommand = new DelegateCommand<string>(TimKiemCommandMethod);
            _danhsachSV = new ObservableCollection<SinhVien>();
            _xoaSVCommand = new Lazy<DelegateCommand>(()=>new DelegateCommand(XoaSVMethod));
            _suaSVCommand = new Lazy<DelegateCommand>(() => new DelegateCommand(SuaSVMethod));
            LoadData();
        }

        private void SuaSVMethod()
        {
            var result = new DialogParameters();
            result.Add("flag", false); 
            result.Add("ds",DanhSachSV);
            result.Add("sv", SelectSV);
            dialogService.ShowDialog("AddSinhVien_AdminView", result, (p) =>
            {


            });
        }

        private void XoaSVMethod()
        {
            var p = new DialogParameters();
            p.Add("count", 1);
            dialogService.ShowDialog("DialogDeleteView",p,(r)=> 
            {
            if (r.Result == ButtonResult.OK)
            {
                Task.Run(() => 
                {
                connect.Execute($"EXECUTE DELSV '{((SinhVien)ListCollectionViewSV.CurrentItem).MaSV}'");
                });
                }
                DanhSachSV.Remove((SinhVien)ListCollectionViewSV.CurrentItem);
            
            });
        }

        private  async Task LoadData()
        {
            IsLoading = true;           
            DanhSachSV=await connect.GetDataAsync<SinhVien>("SELECT ROW_NUMBER() OVER( ORDER BY MaSV) AS STT,MaSV,AnhDaiDien,TenSV,CMND,NgaySinh,GioiTinh,DanToc,TonGiao,DiaChi,QueQuan,SDT,NgayNhapHoc,LOP.MaLop,SinhVien.GhiChu,LOP.TenLop FROM SinhVien  LEFT JOIN LOP ON LOP.MaLop=SinhVien.MaLop ;");
            ListCollectionViewSV = new ListCollectionView(DanhSachSV);
            IsLoading = false;

        }




        private void TimKiemCommandMethod(string obj)
        {
           
        }

 

        private void ThemSVMethod()
        {
            var result = new DialogParameters();
            result.Add("flag",true);
            result.Add("ds",DanhSachSV);
            dialogService.ShowDialog("AddSinhVien_AdminView",result,(p)=> 
            {

              
            });
        }

 
    }
}
