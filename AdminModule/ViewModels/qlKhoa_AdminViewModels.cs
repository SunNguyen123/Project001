using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
using System.Collections.ObjectModel;
using AdminModule.Models;
using System.Threading.Tasks;
using Prism.Commands;
using System;

namespace AdminModule.ViewModels
{
    public class qlKhoa_AdminViewModels : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private int _count;
        private IConnectDB connectDB;
        private ObservableCollection<Khoa> _dsKhoa;
        public DelegateCommand AddKhoaCommand { get; set; }
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
            AddKhoaCommand = new DelegateCommand(AddKhoaCommandMethod);
            LoadData();
        }

        private void AddKhoaCommandMethod()
        {
            dialogsv.ShowDialog("AddKhoaServiceView",new DialogParameters(), (r) =>
            { 
            
            
            });
        }
    }
}
