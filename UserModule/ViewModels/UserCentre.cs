using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using UserModule.Views;
namespace UserModule.ViewModels
{
    public class UserCentre:IModule
    {

        private IRegionManager manager;
        public UserCentre( IRegionManager manager)
        {
            this.manager = manager;   
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            manager.RegisterViewWithRegion<InfoView>("Infor");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}
