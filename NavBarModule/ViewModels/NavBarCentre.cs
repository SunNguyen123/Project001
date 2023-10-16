using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using NavBarModule.ViewModels;
using NavBarModule.Views;
namespace NavBarModule.ViewModels
{
    public class NavBarCentre : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ViewModelLocationProvider.Register<Nav_AdminView,Nav_AdminViewModels>();        
            ViewModelLocationProvider.Register<Nav_GiaoVienView,Nav_GiaoVienViewModels>();        
            ViewModelLocationProvider.Register<Nav_SinhVienView,Nav_SinhVienViewModels>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
