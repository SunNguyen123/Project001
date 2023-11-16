using Libary_ConnectDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using Prism.Regions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
namespace Sell.ViewModels
{
   public class LoginViewModel:BindableBase
    {

        public DelegateCommand ConnectCommand { set; get; }
        public DelegateCommand ConfigCommand { set; get; }

        private IDialogService dialogService;

        public LoginViewModel(IDialogService dialogService)
        {
            ConnectCommand = new DelegateCommand(ConnectMethod);
            ConfigCommand = new DelegateCommand(ConfigMethod);
            this.dialogService = dialogService;
        }

        private void ConfigMethod()
        {
            dialogService.ShowDialog("ConfigView");
        }

        private void ConnectMethod()
        {


        }
    }
}
