using System;
using System.Windows;
using Libary_ConnectDB;
using LoginModule.Model;
using Prism.Mvvm;
using Prism.Commands;
using System.Collections;
using System.Collections.Generic;
using Prism.Events;
namespace LoginModule.ViewModels
{
   public class LoginViewModel2:BindableBase
    {
        private TAIKHOAN user;
        private IConnectDB connect;
        public DelegateCommand LoginCommand {set;get;}
        private IEventAggregator ev;
        public LoginViewModel2(IConnectDB connect,IEventAggregator ev)
        {
            user = new TAIKHOAN();
            user.MatKhau = "";
            user.TaiKhoan = "";
            this.connect = connect;
            
            LoginCommand = new DelegateCommand(LoginExecute);
            this.ev = ev;
        }
        private void LoginExecute() 
        {
            IList<TAIKHOAN> list = connect.GetData<TAIKHOAN>($"SELECT MaTk,PhanLoai FROM TAIKHOAN WHERE TaiKhoan='{TaiKhoan}' AND MatKhau='{MatKhau}'");
            if (list.Count == 1) 
            {
                ev.GetEvent<PackageLogin>().Publish((list[0].MaTk,list[0].PhanLoai));
            }
            else 
            {
                MessageBox.Show("Tài khoản ko tồn tại");
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
