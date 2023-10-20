using System;
using LoginModule.Model;
using Prism.Events;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Windows;
namespace Sell.ViewModels
{
    public class ShellViewModel:BindableBase
    {
        private IEventAggregator ev;
        private IRegionManager rgmanager;
        public DelegateCommand SignOut { set; get; }
        public ShellViewModel(IEventAggregator ev,IRegionManager rgmanager)
        {
            this.ev = ev;
            ev.GetEvent<PackageLogin>().Subscribe(LoadNavbar);
            this.rgmanager = rgmanager;
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
