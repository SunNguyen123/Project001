using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
using Microsoft.Win32;
using System.IO;
using Resource;
using System.Collections.ObjectModel;
using System.Windows.Data;
using AdminModule.Models;
using AlphaChiTech.Virtualization;
using System.Windows.Media.Imaging;

namespace AdminModule.ViewModels
{
    public class AddSinhVien_AdminViewModel : BaseModel, IDialogAware
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
        private string[] _gtSource = { "Nam", "Nữ" };

        public string[] GtSource
        {
            get { return _gtSource; }
            set { _gtSource = value; }
        }
        private string _gt ="Nam";

        public string GioiTinh
        {
            get { return _gt; }
            set { SetProperty(ref _gt, value); }
        }

        private string _danToc;

        public string DanToc
        {
            get { return _danToc; }
            set
            {
                if (value.Length == 0)
                {
                    AddError(nameof(DanToc), "Không được bỏ trống !");
                    
                }
                else
                {
                    RemoveError(nameof(DanToc), "Không được bỏ trống !");
                }
                SetProperty(ref _danToc, value);
            }
        }
        private string _tonGiao;

        public string TonGiao
        {
            get { return _tonGiao; }
            set {
                if (value.Length == 0)
                {
                    AddError(nameof(TonGiao), "Không được bỏ trống !");
                    
                }
                else
                {
                    RemoveError(nameof(TonGiao), "Không được bỏ trống !");
                }
                SetProperty(ref _tonGiao, value);
            }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set
            {
                if (value.Length == 0)
                {
                    AddError(nameof(DiaChi), "Không được bỏ trống !");
                    
                }
                else
                {
                    RemoveError(nameof(DiaChi), "Không được bỏ trống !");
                }
                SetProperty(ref _diaChi, value);
            }
        }
        private string _queQuan;

        public string QueQuan
        {
            get { return _queQuan; }
            set {
                if (value.Length == 0)
                {
                    AddError(nameof(QueQuan), "Không được bỏ trống !");
                  
                }
                else
                {
                    RemoveError(nameof(QueQuan), "Không được bỏ trống !");
                }
                SetProperty(ref _queQuan, value);
            }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { SetProperty(ref sdt, value); }
        }
        private DateTime _ngayNhapHoc=DateTime.Now;

        public DateTime NgayNhapHoc
        {
            get { return _ngayNhapHoc; }
            set { SetProperty<DateTime>(ref _ngayNhapHoc, value); }
        }

        private ObservableCollection<Lop> _listLop;
        public ListCollectionView _dsLop;
        public ListCollectionView ListLop
        {
            get { return _dsLop; }
            set { SetProperty<ListCollectionView>(ref _dsLop, value); }
        }

        private Lazy<DelegateCommand<string>> _resultDialog;
        private Lazy<DelegateCommand> _opentDialog;
        private byte[] _pathImg;
        public byte[] PathImg
        {
            get => _pathImg;
            set
            {
                SetProperty<byte[]>(ref _pathImg,value,nameof(PathImg));
            }
        }
        private async Task LoadKhoa()
        {

            _listLop = await connectDB.GetDataAsync<Lop>("SELECT MaLop,TenLop FROM LOP");
            ListLop = new ListCollectionView(_listLop);

        }
        public DelegateCommand OpenDialog
        {
            get => _opentDialog.Value;
        }
        private bool _isLoading=false;
        private string _cmnd;
        public string CMND
        {
            get { return _cmnd; }
            set 
            {
                if (value.Length == 0)
                {
                    AddError(nameof(CMND), "Không được bỏ trống !");
                  
                }
                else
                {
                    RemoveError(nameof(CMND), "Không được bỏ trống !");
                }
                SetProperty(ref _cmnd, value);
            }
        }
        private string _maSV;

        public string MaSV
        {
            get
            {
                return _maSV;
            }
            set { _maSV = value; }
        }

        private string _tenSV;

        public string TenSV
        {
            get { return _tenSV; }
            set

            {
                if (value.Length ==0) 
                { 
                    AddError(nameof(TenSV), "Không được bỏ trống !"); 
                  
                }
                else 
                { 
                    RemoveError(nameof(TenSV), "Không được bỏ trống !"); 
                }
                SetProperty(ref _tenSV, value);


            }
        }

        private DateTime _ngaySinh=DateTime.Now;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set 
            {
                SetProperty<DateTime>(ref _ngaySinh,value); 
            }
        }
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

        private string _filePath;


        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath,value); }
        }

        public bool Loading
        {
            get { return _isLoading; }
            set { SetProperty<bool>(ref _isLoading,value) ; }
        }
        private bool check;
        public DelegateCommand<string> ResultDialog 
        {
            get => _resultDialog.Value; 
        }
        public string Title => "Them sinh vien";
        private IConnectDB connectDB;
        private IDialogService dialogService;
        public event Action<IDialogResult> RequestClose;
        public AddSinhVien_AdminViewModel(IConnectDB connectDB, IDialogService dialogService)
        {
            this.connectDB = connectDB;
            this.dialogService = dialogService;
            _resultDialog = new Lazy<DelegateCommand<string>>(()=> new DelegateCommand<string>(ResultDialogMethod, CanResultDialogMethod).ObservesProperty(()=>Loading));
            _opentDialog = new Lazy<DelegateCommand>(()=> new DelegateCommand(OpenResultDialogMethod, CanopentDialogMethod).ObservesProperty(() => Loading));
        }

        private bool CanopentDialogMethod()
        {
            return true;
        }

        private bool CanResultDialogMethod(string arg)
        {
            return true;
        }

        private void OpenResultDialogMethod()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog()==true) 
            {
                _filePath = openFileDialog.FileName;
                PathImg=ConvertImg.cvimg(_filePath);
               
                
            }
        }

        private async void ResultDialogMethod(string obj)
        {
            if (obj=="OK") 
            {
                Loading = true;
                if (check)
                {
                    
                    if (!string.IsNullOrWhiteSpace(TenSV))
                    {                        
                        bool gt = GioiTinh == "Nam" ? true : false;

                        list.Add(new SinhVien()
                        {
                            TenSV = TenSV,
                            STT = (list.Count + 1).ToString(),
                            CMND = CMND,
                            GioiTinh = gt,
                            NgayNhapHoc=NgayNhapHoc,
                            NgaySinh=NgaySinh,
                            DiaChi=DiaChi,
                            QueQuan=QueQuan,
                            AnhDaiDien=PathImg,
                            GhiChu=GhiChu,TonGiao=TonGiao,DanToc=DanToc,TenLop= ((Lop)ListLop.CurrentItem).TenLop

                        }) ;
                        
                        await connectDB.ExecuteImg(ConvertImg.cvimg(_filePath),CMND,TenSV,NgaySinh,gt,DanToc,TonGiao,DiaChi,QueQuan,SDT,NgayNhapHoc,((Lop)ListLop.CurrentItem).MaLop,GhiChu);                       
                        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                    }
                    else
                    {
                        Loading = false;
                        var ts1 = new DialogParameters();
                        ts1.Add("message1", $"Thông tin bạn vừa nhập đã tồn tại hoặc chưa đầy đủ");
                        ts1.Add("message2", $"Vui lòng thử lại sau !");
                        dialogService.ShowDialog("DialogWindowView", ts1, (r) => 
                        { 
                        
                        });
                    }
                }
                else
                {
                    int count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM SINHVIEN WHERE TenSV=N'{TenSV}' AND NOT MaSV='{MaSV}'");
                    if (!string.IsNullOrWhiteSpace(TenSV) && count == 0)
                    {
                        await connectDB.ExecuteAsync($"");
                        var bt = ButtonResult.OK;
                        var dialogresult = new DialogResult(bt);
                        RequestClose?.Invoke(dialogresult);
                    }
                    else
                    {
                        Loading = false;
                        var ts1 = new DialogParameters();
                        ts1.Add("message1", $"Thông tin bạn vừa nhập đã tồn tại hoặc chưa đầy đủ");
                        ts1.Add("message2", $"Vui lòng thử lại sau !");
                        dialogService.ShowDialog("DialogWindowView", ts1, (r) => { });
                    }
                }


            }
            else
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
         
        }
        private VirtualizingObservableCollection<SinhVien> list;
        public async void OnDialogOpened(IDialogParameters parameters)
        {
           await LoadKhoa();
            check = parameters.GetValue<bool>("flag");
            if (check)
            {
                Title2 = "Thêm Sinh viên";
                list = parameters.GetValue<VirtualizingObservableCollection<SinhVien>>("list");
            }
            else
            {
                Title2 = "Sửa Sinh viên";
                SinhVien sinhVien = parameters.GetValue<SinhVien>("sv");
                CMND = sinhVien.CMND;
                TenSV = sinhVien.TenSV;
                NgaySinh = sinhVien.NgaySinh;
                GioiTinh = sinhVien.GioiTinh?"Nam":"Nữ";
                DanToc = sinhVien.DanToc;
                TonGiao = sinhVien.TonGiao;
                DiaChi = sinhVien.DiaChi;
                QueQuan = sinhVien.QueQuan;
                GhiChu = sinhVien.GhiChu;
                SDT = sinhVien.SDT;
                NgayNhapHoc = sinhVien.NgayNhapHoc;
                Lop lop = _listLop.FirstOrDefault(c=>c.MaLop==sinhVien.MaLop);
                ListLop.MoveCurrentTo(lop);
                list = parameters.GetValue<VirtualizingObservableCollection<SinhVien>>("list");
                PathImg = sinhVien.AnhDaiDien;

            }
        }
    }
}
