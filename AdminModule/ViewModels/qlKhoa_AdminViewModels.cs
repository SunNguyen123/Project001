using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
using System.Collections.ObjectModel;
using AdminModule.Models;
using Prism.Commands;
using System.Windows.Controls;
using System.Windows.Data;
using System;
using System.Collections.Generic;
using Prism.Events;
using System.Collections;

namespace AdminModule.ViewModels
{
    public class qlKhoa_AdminViewModels : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private int _count;
        private IConnectDB connectDB;
        private ObservableCollection<Khoa> _dsKhoa;
        public List<Khoa> SelectedObject { get; set; }
        public DelegateCommand RemoveKhoa { set; get; }
        private string[] items = { "Mã", "Tên" };
        public string[]  ITEMS
        {
            set { SetProperty<string[]>(ref items,value); }
            get => items;
        }
        private string _dk="Mã";

        public string DieuKienTimKiem
        {
            get { return _dk; }
            set 
            { 
                
                SetProperty(ref _dk,value); 
            }
        }
        private string _gtTK="";

        public string GiaTriTimKiem
        {
            get => _gtTK;
            set
            {

                _gtTK = value;
                TimKiemKhoaCommandMethod(_gtTK);
            }
        }
        public DelegateCommand AddKhoaCommand { get; set; }
        public DelegateCommand<string> TimKiemKhoaCommand { get; set; }

        private ListCollectionView listKhoa ;
        public ListCollectionView DsKhoa
        {
            get { return listKhoa; }
            set { SetProperty(ref listKhoa, value); }
        }

        public int Count
        {
            get { return _count; }
            set { SetProperty<int>(ref _count,value); }
        }
        private async void LoadData(string query) 
        {

            _dsKhoa= await connectDB.GetData<Khoa>(query);
            DsKhoa = new ListCollectionView(_dsKhoa);
            
           if(DsKhoa != null) Count = DsKhoa.Count;

        }
        private IEventAggregator ev;
        public qlKhoa_AdminViewModels(IDialogService dialogsv, IConnectDB connectDB, IEventAggregator ev)
        {
            this.dialogsv = dialogsv;
            this.connectDB = connectDB;
            this.ev = ev;
             AddKhoaCommand = new DelegateCommand(AddKhoaCommandMethod);
            TimKiemKhoaCommand = new DelegateCommand<string>(TimKiemKhoaCommandMethod);
          
           
            RemoveKhoa = new DelegateCommand(RemoveKhoaMethod);
            LoadData("SELECT * FROM KHOA");
        }

   

        private async void RemoveKhoaMethod()
        {
            
            foreach (var item in SelectedObject) 
            { 
            
                await connectDB.Execute($"DELETE FROM KHOA WHERE MaKhoa='{item.MaKhoa}'");
            
            }
            LoadData($"SELECT * FROM KHOA ");

        }

        private void TimKiemKhoaCommandMethod(string q)
        {
          
            if (string.IsNullOrWhiteSpace(q.Trim()) || q=="")
            {
                LoadData($"SELECT * FROM KHOA ");
              
            }
            else 
            {

                if (DieuKienTimKiem.Trim() == "Mã")
                {
                    LoadData($"SELECT * FROM KHOA WHERE MaKhoa LIKE '{q}%'");
                }
                else
                {

                    LoadData($"SELECT * FROM KHOA WHERE TenKhoa LIKE N'{q}%'");
                }
            }
        }

        private  void AddKhoaCommandMethod()
        {

            var p = new DialogParameters();
            p.Add("",100);
            dialogsv.ShowDialog("AddKhoaServiceView",p,ResultCallBack);
        }

        private   void ResultCallBack(IDialogResult obj)
        {
            
            if (obj.Result == ButtonResult.OK) TimKiemKhoaCommandMethod(_gtTK);
        }
    }
}
