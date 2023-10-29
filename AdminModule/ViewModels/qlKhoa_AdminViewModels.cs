using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
using System.Collections.ObjectModel;
using AdminModule.Models;
using System.Threading.Tasks;

namespace AdminModule.ViewModels
{
    public class qlKhoa_AdminViewModels : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private int _count;
        private IConnectDB connectDB;
        private ObservableCollection<Khoa> _dsKhoa;

        public ObservableCollection<Khoa> DsKhoa
        {
            get { return _dsKhoa; }
            set { SetProperty(ref _dsKhoa,value); }
        }

        public int Count
        {
            get { return _count; }
            set { SetProperty<int>(ref _count,value); }
        }
        private async void LoadData() 
        {

            DsKhoa= await connectDB.GetData<Khoa>("SELECT * FROM KHOA");
            Count = DsKhoa.Count;
        }
        public qlKhoa_AdminViewModels(IDialogService dialogsv, IConnectDB connectDB)
        {
            this.dialogsv = dialogsv;
            this.connectDB = connectDB;
            LoadData();
        }




    }
}
