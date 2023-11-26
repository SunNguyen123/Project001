﻿
using Resource;
using Prism.Commands;
using Libary_ConnectDB;
using Prism.Regions;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using AdminModule.Models;
using Prism.Events;
using System.Threading.Tasks;

namespace AdminModule.ViewModels
{
    public class qlNganh_AdminViewModel : BaseModel, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private int _count;
        private IConnectDB connectDB;
        private ObservableCollection<Nganh> _ds;

        public List<Nganh> SelectedObject { get; set; }
        private IList<Khoa> _listKhoa;
        public ListCollectionView _dskhoa;
        public ListCollectionView ListKhoa
        {
            get { return _dskhoa; }
            set { SetProperty<ListCollectionView>(ref _dskhoa, value); }
        }
        private void LoadKhoa()
        {

            _listKhoa = connectDB.GetData<Khoa>("SELECT MaKhoa,TenKhoa FROM KHOA");
            ListKhoa = new ListCollectionView((List<Khoa>)_listKhoa);

        }
        public DelegateCommand Remove { set; get; }
        private string sqlLoadFull = "SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa";
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
            set { SetProperty(ref _list, value); }
        }

        public int Count
        {
            get { return _count; }
            set { SetProperty<int>(ref _count, value); }
        }
        private async void LoadData(string query)
        {

            _ds = await connectDB.GetDataAsync<Nganh>(query);
            if (_ds != null)
            {
                ListData = new ListCollectionView(_ds);
                Count = ListData.Count;
            }


        }
        private IEventAggregator ev;
        public qlNganh_AdminViewModel(IDialogService dialogsv, IConnectDB connectDB, IEventAggregator ev)
        {
            this.dialogsv = dialogsv;
            this.connectDB = connectDB;
            this.ev = ev;
            AddCommand = new DelegateCommand(AddCommandMethod);
            TimKiemCommand = new DelegateCommand<string>(TimKiemCommandMethod);
            Remove = new DelegateCommand(RemoveMethod);
            Edit = new DelegateCommand(EditMethod);
            Edit2 = new DelegateCommand(Edit2Method, Caneditexecute).ObservesProperty(() => SelectedObject);
            TimKiemCommandMethod(_gtTK);
            LoadKhoa();
        }

        private bool Caneditexecute()
        {
            bool flag = true;
            if (SelectedObject != null)
            {
                flag = SelectedObject.Count == 1 ? true : false;
            }

            return flag;
        }

        private void Edit2Method()
        {
            var ts = new DialogParameters();
            ts.Add("obj", _list.CurrentItem);
            ts.Add("flag", false);
            dialogsv.ShowDialog("NganhServiceView", ts, (r) => {
                if (r.Result == ButtonResult.OK) LoadData(sqlLoadFull);
            });
        }

        private async void EditMethod()
        {
                var nganh = ListData.CurrentItem as Nganh;
                var count=await connectDB.CountRecordAsync($"SELECT COUNT(*) FROM NGANH WHERE TenNganh=N'{nganh.TenNganh}'");
            if (count==0)
            {
                await connectDB.ExecuteAsync($"UPDATE NGANH SET TenNganh=N'{nganh.TenNganh}',MaKhoa=N'{nganh.MaKhoa}',NamBatDau='{nganh.NamBatDau.ToString("yyyy-MM-d")}' WHERE MaKhoa='{nganh.MaNganh}'");
            }
        }

        private  void RemoveMethod()
        {
            var p = new DialogParameters();
            p.Add("count", SelectedObject.Count);
            dialogsv.ShowDialog("DialogDeleteView", p, async (r) =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    foreach (var item in SelectedObject)
                    {

                        await connectDB.ExecuteAsync($"EXECUTE REMOVENGANH '{item.MaNganh}'");

                    }
                    TimKiemCommandMethod(_gtTK);
                }
            });
        }

        private void TimKiemCommandMethod(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Trim()) || obj == "")
            {
                LoadData(sqlLoadFull);

            }
            else
            {

                if (DieuKienTimKiem.Trim() == "Mã")
                {
                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa WHERE MaNganh LIKE '{obj}%'");
                }
                else
                {

                    LoadData($"SELECT ROW_NUMBER() OVER( ORDER BY MaNganh) AS STT,MaNganh,TenNganh,KHOA.MaKhoa,KHOA.TenKhoa,NGANH.NamBatDau FROM NGANH LEFT JOIN KHOA ON NGANH.MaKhoa=KHOA.MaKhoa WHERE TenNganh LIKE N'{obj}%'");
                }
            }
        }

        private void AddCommandMethod()
        {
            var p = new DialogParameters();
            p.Add("flag",true);
            dialogsv.ShowDialog("NganhServiceView", p, ResultCallBack);
        }

        private void ResultCallBack(IDialogResult obj)
        {
            if (obj.Result == ButtonResult.OK) TimKiemCommandMethod(_gtTK);
        }
    }
}
