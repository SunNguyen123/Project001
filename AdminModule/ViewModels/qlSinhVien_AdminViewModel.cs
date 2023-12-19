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
             
        private string[] _dkTimKiem = { "Mã","Tên"};
        private Lazy<DelegateCommand> _xoaSVCommand;
        private SinhVien _selecSV;
        public SinhVien SelectSV 
        {
            set => _selecSV = value;
            get => _selecSV; 
        }
        private DelegateCommand _taiLaiDuLieuCommand;

        public DelegateCommand TaiLaiDulieuCommand
        {
            get { return _taiLaiDuLieuCommand; }
            set { _taiLaiDuLieuCommand = value; }
        }

        private DelegateCommand _trangTruocCommand;

        public DelegateCommand TrangTruocCommand
        {
            get { return _trangTruocCommand; }
            set { _trangTruocCommand = value; }
        }

        private DelegateCommand _trangSauCommand;

        public DelegateCommand TrangSauCommand
        {
            get { return _trangSauCommand; }
            set { _trangSauCommand = value; }
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
        private int _soLuongSV;
        public int SoLuongSV
        {
            get { return _soLuongSV; }
            set { SetProperty<int>(ref _soLuongSV, value); }
        }

        private int _trangHienTai;

        public int TrangHienTai
        {
            get { return _trangHienTai; }
            set { SetProperty<int>(ref _trangHienTai,value); }
        }

        private int _soLuongTrang;

        public int SoLuongTrang
        {
            get { return _soLuongTrang; }
            set { SetProperty<int>(ref _soLuongTrang, value); }
        }


        public bool KeepAlive => true;

        public async Task TaiTrangSauMethod() 
        { 
        
        }

        private IConnectDB connect;
        private IDialogService dialogService;
        public qlSinhVien_AdminViewModel(IConnectDB connect,IDialogService dialogService)
        {
            this.dialogService = dialogService;
            this.connect = connect;
            ThemSVCommand = new DelegateCommand(ThemSVMethod);
            TimKiemCommand = new DelegateCommand<string>(TimKiemCommandMethod);
            _danhsachSV = new ObservableCollection<SinhVien>();
            _xoaSVCommand = new Lazy<DelegateCommand>(()=>new DelegateCommand(async()=> await XoaSVMethod()));
            _suaSVCommand = new Lazy<DelegateCommand>(() => new DelegateCommand(SuaSVMethod));
            _trangSauCommand = new DelegateCommand(async()=>await TaiTrangSauMethod());
            _taiLaiDuLieuCommand = new DelegateCommand(async ()=> await TaiDuLieuMethod());


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

        private async Task XoaSVMethod()
        {
            await Task.Delay(10);
            var p = new DialogParameters();
            p.Add("count", 1);
            dialogService.ShowDialog("DialogDeleteView",p, (r)=>
            {
                if (r.Result == ButtonResult.OK)
                {

                   connect.Execute($"EXECUTE DELSV '{((SinhVien)ListCollectionViewSV.CurrentItem).MaSV}'");
                   
                }
            }
            
            );
        }

        private  async Task TaiDuLieuMethod()
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
