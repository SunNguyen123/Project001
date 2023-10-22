using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using NavBarModule.ViewModels;
using Prism.Regions;
using NavBarModule.Views;
using Prism.Events;
using LoginModule.Model;
using System.Windows;

namespace NavBarModule.ViewModels
{
    public class NavBarCentre : IModule
    {
        private IRegionManager manager;
        private IEventAggregator ev;
        public NavBarCentre(IEventAggregator ev, IRegionManager manager)
        {
            this.manager = manager;
            this.ev = ev;
            
        }


       private IRegion regionNavbar;
        public void OnInitialized(IContainerProvider containerProvider)
        {

            regionNavbar = manager.Regions["Navbar"];
            ViewModelLocationProvider.Register<Nav_AdminView,Nav_AdminViewModels>();        
            ViewModelLocationProvider.Register<Nav_GiaoVienView,Nav_GiaoVienViewModels>();        
            ViewModelLocationProvider.Register<Nav_SinhVienView,Nav_SinhVienViewModels>();
            manager.RegisterViewWithRegion<Nav_AdminView>("Navbar");
            manager.RegisterViewWithRegion<Nav_GiaoVienView>("Navbar");
            manager.RegisterViewWithRegion<Nav_SinhVienView>("Navbar");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
