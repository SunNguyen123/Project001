using System;
using LoginModule.Model;
using Prism.Events;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using Prism.Unity;
using Prism.Services;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;

namespace Sell.ViewModels
{
    public class ShellViewModel:BindableBase
    {
        private IEventAggregator ev;
        private IRegionManager rgmanager;
        private IModuleManager moduleManager;
        
        public DelegateCommand SignOut { set; get; }
        public ShellViewModel(IEventAggregator ev,IRegionManager rgmanager, IModuleManager moduleManager)
        {
            this.ev = ev;
            ev.GetEvent<PackageLogin>().Subscribe(LoadNavbar);
            this.rgmanager = rgmanager;
            this.moduleManager = moduleManager;
            SignOut = new DelegateCommand(ExecuteSignOut);
        }
        private void ExecuteSignOut()
        {
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            System.Windows.Application.Current.Shutdown();
        }

        private void LoadNavbar((string, string) tuple)
        {
            switch (tuple.Item2) 
            {
                case "admin":
                    moduleManager.LoadModule("AdminModuleCentre");

                    rgmanager.RequestNavigate("Navbar", "Nav_AdminView");
                    break;
                case "giaovien":
                    rgmanager.RequestNavigate("Navbar", "Nav_GiaoVienView");
                    break;
                case "sinhvien":
                    rgmanager.RequestNavigate("Navbar", "Nav_SinhVienView");

                    break;
            }
        }
    }
}
