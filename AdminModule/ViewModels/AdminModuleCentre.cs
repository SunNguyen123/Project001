using System;
using Prism.Unity;
using Prism.Modularity;
using Prism.Ioc;
using Prism.Mvvm;
using AdminModule.ViewModels;
using AdminModule.Views;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AdminModule.ViewModels
{
    public class AdminModuleCentre : IModule
    {

        private IRegionManager regionManager;
   
        public AdminModuleCentre(IRegionManager regionManager, IDialogService dialogsv)
        {
            this.regionManager = regionManager;
          
        }      
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ViewModelLocationProvider.Register<Home_AdminView,Home_AdminViewModels>();
            ViewModelLocationProvider.Register<qlKhoa_AdminView,qlKhoa_AdminViewModels>();
            regionManager.RegisterViewWithRegion<Home_AdminView>("Body");
            regionManager.RegisterViewWithRegion<qlKhoa_AdminView>("Body");
            //containerRegistry.RegisterForNavigation<qlKhoa_AdminView, qlKhoa_AdminViewModels>();
            //regionManager.RegisterViewWithRegion<qlKhoa_AdminView>("Body");
            //var rgbody = regionManager.Regions["Body"];
            //var qlKhoa = containerProvider.Resolve<qlKhoa_AdminView>();
            //rgbody.Add(qlKhoa);
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
