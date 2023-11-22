using System;
using System.Text;
using System.Windows;
using Libary_ConnectDB;
using LoginModule.Model;
using Prism.Mvvm;
using Prism.Commands;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Prism.Events;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO.Compression;
using System.IO;

namespace LoginModule.ViewModels
{
   public class LoginViewModel2:BindableBase
    {
        private TAIKHOAN user;
        private IConnectDB connect;
        private IDialogService dialogService;
        private bool _isLoad=false;
        public bool IsLoad 
        {
            get 
            {
                return _isLoad;
            }
            set 
            {
                SetProperty(ref _isLoad,value);
            }
        }
        public DelegateCommand LoginCommand {set;get;}
        private IEventAggregator ev;
        public LoginViewModel2(IConnectDB connect,IEventAggregator ev, IDialogService dialogService)
        {
            user = new TAIKHOAN();
            user.MatKhau = "";
            user.TaiKhoan = "";
            this.connect = connect;           
            this.ev = ev;
            this.dialogService = dialogService;
            LoginCommand = new DelegateCommand(LoginExecute,CanLoginExecute).ObservesProperty(()=> IsLoad);
            string b = MD5Hash("admin");
            string c = MD5Hash("123");
        }
        private string MD5Hash(string exp) 
        {
                StringBuilder stringBuilder = new StringBuilder();
            using (MD5 md5=MD5.Create()) 
            {
                byte[] sample = Encoding.UTF8.GetBytes(exp);
                byte[] hash = md5.ComputeHash(sample);
                foreach (var i in hash) 
                {
                    stringBuilder.Append(i.ToString());
                }
            }
                return stringBuilder.ToString();
        }
        private bool CanLoginExecute()
        {
            return !IsLoad;
        }

        private async void LoginExecute() 
        {
            IsLoad = true;
            try
            {
                ObservableCollection<TAIKHOAN> list = await connect.GetDataAsync<TAIKHOAN>($"SELECT MaTk,PhanLoai FROM TAIKHOAN WHERE TaiKhoan='{MD5Hash(TaiKhoan)}' AND MatKhau='{MD5Hash(MatKhau)}'");

                if (list == null) { 
                    
                    
                    IsLoad = false;
                    return; 
                }
                if (list != null && list.Count != 0)
                {
                    ev.GetEvent<PackageLogin>().Publish((list[0].MaTk, list[0].PhanLoai));
                }
                else
                {
                    IsLoad = false;

                    var ts1 = new DialogParameters();
                    ts1.Add("message1", "Tài khoản hoặc mật khẩu bạn vừa nhập không tồn tại");
                    ts1.Add("message2", "Vui lòng thử lại sau !");


                    dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                    {
                        if (r.Result == ButtonResult.OK)
                        {

                        }

                    });
                }
            }
            catch
            {

            }
        }
        public string TaiKhoan 
        {
            set 
            {
                SetProperty(ref user.TaiKhoan,value,nameof(TaiKhoan));
            }
            get 
            {
                return user.TaiKhoan;
            }
        }

        public string MatKhau
        {
            set
            {
                SetProperty(ref user.MatKhau, value, nameof(MatKhau));
            }
            get
            {
                return user.MatKhau;
            }
        }


    }
}
