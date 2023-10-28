using System;
using System.Windows;
using Libary_ConnectDB;
using LoginModule.Model;
using Prism.Mvvm;
using Prism.Commands;
using System.Collections;
using System.Collections.Generic;
using Prism.Events;
using Prism.Services.Dialogs;

namespace LoginModule.ViewModels
{
   public class LoginViewModel2:BindableBase
    {
        private TAIKHOAN user;
        private IConnectDB connect;
        private IDialogService dialogService;
        public DelegateCommand LoginCommand {set;get;}
        private IEventAggregator ev;
        public LoginViewModel2(IConnectDB connect,IEventAggregator ev, IDialogService dialogService)
        {
            user = new TAIKHOAN();
            user.MatKhau = "";
            user.TaiKhoan = "";
            this.connect = connect;
            
            LoginCommand = new DelegateCommand(LoginExecute);
            this.ev = ev;
            this.dialogService = dialogService;
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
                var ts1 = new DialogParameters();
                ts1.Add("message1", "Tài khoản hoặc mật khẩu không tồn tại!");
                ts1.Add("message2", "Vui lòng thử lại!");


                dialogService.ShowDialog("DialogMessageTextView", ts1, (r) =>
                {
                    if (r.Result == ButtonResult.OK)
                    {

                    }

                });
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
