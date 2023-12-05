using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Resource;
using Libary_ConnectDB;
using Prism.Events;
using AdminModule.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Data;

namespace AdminModule.ViewModels
{
   public class qlLop_AdminViewModel:BaseModel, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private int _count;
        private IConnectDB connectDB;
        private ObservableCollection<Lop> _ds;

        public Lop SelectedObject { get; set; }


        public DelegateCommand Remove { set; get; }
        private string sqlLoadFull = "SELECT ROW_NUMBER() OVER( ORDER BY MaLop) AS STT,MaLop,TenLop,KHOAHOC.MaKhoaHoc,KHOAHOC.TenKhoaHoc,NGANH.MaNganh,NGANH.TenNganh,LOP.GhiChu FROM LOP  LEFT JOIN NGANH ON LOP.MaNganh=NGANH.MaNganh LEFT JOIN KHOAHOC ON LOP.MaKhoaHoc=KHOAHOC.MaKhoaHoc";
        public DelegateCommand Edit { set; get; }
        public DelegateCommand Edit2 { set; get; }

        private string[] items = { "Mã", "Tên" };
        public string[] ITEMS
        {
            set { SetProperty<string[]>(ref items, value); }
            get => items;
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
        private string _gtTK = "";

        public string GiaTriTimKiem
        {
            get => _gtTK;
            set
            {

                _gtTK = value;
                TimKiemCommandMethod(_gtTK);
            }
        }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<string> TimKiemCommand { get; set; }

        private ListCollectionView _list;
        public ListCollectionView ListData
        {
            get { return _list; }
            set { SetProperty<ListCollectionView>(ref _list, value); }
        }

        public int Count
        {
            get { return _count; }
            set { SetProperty<int>(ref _count, value); }
        }
        private async void LoadData(string query)
        {

            _ds = await connectDB.GetDataAsync<Lop>(query);
            if (_ds != null)
            {
                ListData = new ListCollectionView(_ds);
                Count = ListData.Count;
            }


        }
        private IEventAggregator ev;
        public qlLop_AdminViewModel(IDialogService dialogsv, IConnectDB connectDB, IEventAggregator ev)
        {
            this.dialogsv = dialogsv;
            this.connectDB = connectDB;
            this.ev = ev;
            AddCommand = new DelegateCommand(AddCommandMethod);
            TimKiemCommand = new DelegateCommand<string>(TimKiemCommandMethod);
            Remove = new DelegateCommand(RemoveMethod);
            Edit = new DelegateCommand(EditMethod);
            Edit2 = new DelegateCommand(Edit2Method);
            TimKiemCommandMethod(_gtTK);
            
            
        }



        private void Edit2Method()
        {
            var ts = new DialogParameters();
            ts.Add("obj", _list.CurrentItem);
            ts.Add("flag", false);
            dialogsv.ShowDialog("LopServiceView", ts, (r) => {
               
            });
        }

        private async void EditMethod()
        {
            //var nganh = ListData.CurrentItem as Nganh;
            //var count = await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM NGANH WHERE TenNganh=N'{nganh.TenNganh}'");
            //if (count == 0)
            //{
            //    await connectDB.ExecuteAsync($"UPDATE LOP SET TenNganh=N'{nganh.TenNganh}',MaKhoa=N'{nganh.MaKhoa}',NamBatDau='{nganh.NamBatDau.ToString("yyyy-MM-d")}' WHERE MaKhoa='{nganh.MaNganh}'");
            //}
        }

        private void RemoveMethod()
        {
            var p = new DialogParameters();
            p.Add("count", 1);
            dialogsv.ShowDialog("DialogDeleteView", p, async (r) =>
            {
                if (r.Result == ButtonResult.OK)
                {

                        await connectDB.ExecuteAsync($"EXECUTE REMOVELOP '{((Lop)ListData.CurrentItem).MaLop}'");
                    _ds.Remove((Lop)ListData.CurrentItem);

                  
                    
                }
            });
        }

        private async void TimKiemCommandMethod(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Trim()) || obj == "")
            {
                LoadData(sqlLoadFull);

            }
            else
            {

                if (DieuKienTimKiem.Trim() == "Mã")
                {
                    LoadData(sqlLoadFull+$" WHERE MaLop LIKE '{obj}%'");
                }
                else
                {

                    LoadData(sqlLoadFull+ $" WHERE TenLop LIKE N'{obj}%'");
                }
            }
        }

        private void AddCommandMethod()
        {
            var p = new DialogParameters();
            p.Add("flag", true);
            p.Add("objs", _ds);
            dialogsv.ShowDialog("LopServiceView", p, ResultCallBack);
        }

        private void ResultCallBack(IDialogResult obj)
        {
            
        }
    }
}
