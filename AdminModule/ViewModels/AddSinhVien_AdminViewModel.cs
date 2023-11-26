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
namespace AdminModule.ViewModels
{
    public class AddSinhVien_AdminViewModel : BaseModel, IDialogAware
    {
        
            private string[] _gtSource = { "Nam", "Nữ" };

        public string[] GtSource
        {
            get { return _gtSource; }
            set { _gtSource = value; }
        }
        private string _gt;

        public string GioiTinh
        {
            get { return _gt; }
            set { SetProperty(ref _gt, value); }
        }

        private string _danToc;

        public string DanToc
        {
            get { return _danToc; }
            set { SetProperty(ref _danToc, value); }
        }
        private string _tonGiao;

        public string TonGiao
        {
            get { return _tonGiao; }
            set { 
                SetProperty(ref _tonGiao, value);
            }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { SetProperty(ref _diaChi, value); }
        }
        private string _queQuan;

        public string QueQuan
        {
            get { return _queQuan; }
            set { SetProperty(ref _queQuan, value); }
        }
        private string sdt;

        public string SDT
        {
            get { return sdt; }
            set { SetProperty(ref sdt, value); }
        }
        private DateTime _ngayNhapHoc;

        public DateTime NgayNhapHoc
        {
            get { return _ngayNhapHoc; }
            set { SetProperty<DateTime>(ref _ngayNhapHoc, value); }
        }


        private Lazy<DelegateCommand<string>> _resultDialog;
        private Lazy<DelegateCommand> _opentDialog;
        private Uri _pathImg=null;
        public Uri PathImg
        {
            get => _pathImg;
            set
            {
                SetProperty<Uri>(ref _pathImg,value);
            }
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
            set { SetProperty(ref _cmnd, value); }
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
                    return; 
                }
                else 
                { 
                    RemoveError(nameof(TenSV), "Không được bỏ trống !"); 
                }
                SetProperty(ref _tenSV, value);


            }
        }

        private DateTime _ngaySinh;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set 
            {
                SetProperty<DateTime>(ref _ngaySinh,value); 
            }
        }


        private string _filePath;


        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public bool Loading
        {
            get { return _isLoading; }
            set { SetProperty<bool>(ref _isLoading,value) ; }
        }

        public DelegateCommand<string> ResultDialog 
        {
            get => _resultDialog.Value; 
        }
        public string Title => "Them sinh vien";
        private IConnectDB connectDB;
        public event Action<IDialogResult> RequestClose;
        public AddSinhVien_AdminViewModel(IConnectDB connectDB)
        {
            this.connectDB = connectDB;
            _resultDialog = new Lazy<DelegateCommand<string>>(()=> new DelegateCommand<string>(ResultDialogMethod));
            _opentDialog = new Lazy<DelegateCommand>(()=> new DelegateCommand(OpenResultDialogMethod));
        }

        private void OpenResultDialogMethod()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog()==true) 
            {
                _filePath = openFileDialog.FileName;
                PathImg = new Uri(_filePath);
                
            }
        }

        private void ResultDialogMethod(string obj)
        {
            if (obj=="OK") 
            {
             
           
                    byte[] imageBytes = File.ReadAllBytes(_filePath);
                    connectDB.Execute($"");
              
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
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

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }
    }
}
