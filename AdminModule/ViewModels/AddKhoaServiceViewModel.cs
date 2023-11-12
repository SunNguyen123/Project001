using System;
using Libary_ConnectDB;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using AdminModule.Models;
namespace AdminModule.ViewModels
{
    public class AddKhoaServiceViewModel : BindableBase, IDialogAware
    {

        private float _width;

        public float Width
        {
            get { return _width; }
            set { SetProperty<float>(ref _width,value); }
        }


        private float _height;

        public float Height
        {
            get { return _height; }
            set { SetProperty<float>(ref _height, value); }
        }

        public string TenKhoa { set; get; }
        public string GhiChu { set; get; }
        public DateTime NgayThanhLap { set; get; } = DateTime.Now;

        private IConnectDB connectDB;
        public DelegateCommand<string> ResultDialog { set; get; }
        private IDialogService dialogService;
        public AddKhoaServiceViewModel(IConnectDB connectDB,IDialogService dialogService)
        {
            this.connectDB = connectDB;
            this.dialogService = dialogService;
            ResultDialog = new DelegateCommand<string>(CloseDialog);
        }
        private string AutoID() 
        {

            return "KH"+DateTime.Now.Second+ DateTime.Now.Minute+ DateTime.Now.Hour;
        }
        private async void CloseDialog(string obj)
        {
          
            if (obj == "OK")
            {
                int count = await connectDB.CountRecord($"SELECT COUNT(TenKhoa) FROM KHOA WHERE TenKhoa=N'{TenKhoa}'");
                if (!string.IsNullOrWhiteSpace(TenKhoa) && count==0)
                {
                    var khoanew = new Khoa();
                    var c = AutoID();
               await connectDB.Execute($"INSERT INTO KHOA VALUES('{AutoID()}',N'{TenKhoa}','{NgayThanhLap.ToString("yyyy-MM-dd")}',N'{GhiChu}')");
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                }
                else 
                {
                    var ts1 = new DialogParameters();
                    ts1.Add("message1", "Tên khoa bạn nhập đã tồn tại!");
                    ts1.Add("message2", "Vui lòng thử lại sau !");


                    dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                    {
                        if (r.Result == ButtonResult.OK)
                        {

                        }

                    });
                }
            }
            else
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            }
            
        }

        public string Title => "Thêm Khoa";

        public event Action<IDialogResult> RequestClose;

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
