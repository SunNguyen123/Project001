﻿using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Libary_ConnectDB;
using System.Collections.ObjectModel;
using AdminModule.Models;
using Prism.Commands;
using System.Windows.Data;
using System;
using System.Collections.Generic;
using Prism.Events;
using System.Collections;
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
        public Khoa SelectedObject { get; set; }
        public DelegateCommand RemoveKhoa { set; get; }
        private string sqlLoadFull = "SELECT ROW_NUMBER() OVER( ORDER BY MaKhoa) AS STT,MaKhoa,TenKhoa,NamBatDau,GhiChu FROM KHOA";
        public DelegateCommand EditKhoa { set; get; }
        public DelegateCommand EditKhoa2 { set; get; }

        private string[] items = { "Mã", "Tên" };
        public string[]  ITEMS
        {
            set { SetProperty<string[]>(ref items,value); }
            get => items;
        }
        private string _dk= "Mã";

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

        private ListCollectionView listKhoa;
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

            _dsKhoa= await connectDB.GetDataAsync<Khoa>(query);
            if (_dsKhoa!=null) 
            {
                DsKhoa = new ListCollectionView(_dsKhoa);
                Count = DsKhoa.Count;
            }


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
          
            EditKhoa2 = new DelegateCommand(EditKhoa2Method);
            TimKiemKhoaCommandMethod(_gtTK);
        }



        private void EditKhoa2Method()
        {
            var ts = new DialogParameters();
            ts.Add("obj", listKhoa.CurrentItem );
            dialogsv.ShowDialog("EditKhoa_AdminView",ts,(r)=> {
              
            });
        }



        private  void RemoveKhoaMethod()
        {
            var p = new DialogParameters();
            p.Add("count",1);
            dialogsv.ShowDialog("DialogDeleteView",p, async (r)=> 
            {
                if (r.Result==ButtonResult.OK)
                {

                    _dsKhoa.Remove(SelectedObject);
                        await connectDB.ExecuteAsync($"EXECUTE REMOVEKHOA '{SelectedObject.MaKhoa}'");

                    
                    
                }
            });

        }

        private async void TimKiemKhoaCommandMethod(string q)
        {
          
            if (string.IsNullOrWhiteSpace(q.Trim()) || q=="")
            {
                LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaKhoa) AS STT,MaKhoa,TenKhoa,NamBatDau,GhiChu FROM KHOA");
              
            }
            else 
            {

                if (DieuKienTimKiem.Trim() == "Mã")
                {
                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaKhoa) AS STT,MaKhoa,TenKhoa,NamBatDau,GhiChu FROM KHOA WHERE MaKhoa LIKE '{q}%'");
                }
                else
                {

                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaKhoa) AS STT,MaKhoa,TenKhoa,NamBatDau,GhiChu FROM KHOA WHERE TenKhoa LIKE N'{q}%'");
                }
            }
        }

        private  void AddKhoaCommandMethod()
        {

            var p = new DialogParameters();
            p.Add("objs",_dsKhoa);
            dialogsv.ShowDialog("AddKhoaServiceView",p,ResultCallBack);
        }

        private   void ResultCallBack(IDialogResult obj)
        {
            
            
        }
    }
}
