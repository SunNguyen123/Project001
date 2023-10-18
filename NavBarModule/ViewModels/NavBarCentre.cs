using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using NavBarModule.ViewModels;
using Prism.Regions;
using NavBarModule.Views;
namespace NavBarModule.ViewModels
{
    public class NavBarCentre : IModule
    {
        private IRegionManager manager;
        public NavBarCentre(IRegionManager manager)
        {
            this.manager = manager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            ViewModelLocationProvider.Register<Nav_AdminView,Nav_AdminViewModels>();        
            ViewModelLocationProvider.Register<Nav_GiaoVienView,Nav_GiaoVienViewModels>();        
            ViewModelLocationProvider.Register<Nav_SinhVienView,Nav_SinhVienViewModels>();
            manager.RegisterViewWithRegion<Nav_AdminView>("Navbar");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
