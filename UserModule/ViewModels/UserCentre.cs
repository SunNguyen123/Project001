using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using UserModule.ViewModels;
using UserModule.Views;
namespace UserModule.ViewModels
{
    public class UserCentre:IModule
    {

        private IRegionManager manager;
        public UserCentre(IRegionManager manager)
        {
            this.manager = manager;   
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            manager.RegisterViewWithRegion<InfoView>("Infor");
            ViewModelLocationProvider.Register<InfoView,UserViewModel>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}
