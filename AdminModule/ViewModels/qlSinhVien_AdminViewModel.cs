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
using System.Windows.Data;
using AlphaChiTech.Virtualization;
namespace AdminModule.ViewModels
{


    public class qlSinhVien_AdminViewModel : BindableBase, IRegionMemberLifetime
    {
        private int _countRecord;
             
        private string[] _dkTimKiem = { "Mã","Tên"};
        private VirtualizingObservableCollection<SinhVien> _listSV2=null;    

        public VirtualizingObservableCollection<SinhVien> ListSV2
        {
            get 
            {
                if (_listSV2 == null)
                {
                    _listSV2 = new VirtualizingObservableCollection<SinhVien>(new PaginationManager<SinhVien>(new SinhVienSource(connect)));
                }
                return _listSV2; 
            }
            set 
            {
                SetProperty<VirtualizingObservableCollection<SinhVien>>(ref _listSV2,value);
            }
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

        }

        private void TimKiemCommandMethod(string obj)
        {
            
        }

 

        private void ThemSVMethod()
        {
            var result = new DialogParameters();
            result.Add("flag",true);
            result.Add("list", ListSV2);

            dialogService.ShowDialog("AddSinhVien_AdminView",result,(p)=> 
            {

              
            });
        }

 
    }
}
