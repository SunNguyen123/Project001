using Prism.Ioc;
using Prism.Modularity;
using System;
using Prism.Regions;
using LoginModule.Views;
using Prism.Mvvm;
using Libary_ConnectDB;
using System.Windows;

namespace LoginModule.ViewModels
{
    public class LoginCentre : IModule
    {
        private IRegionManager manager;
        public LoginCentre(IRegionManager manager, IConnectDB connect)
        {
            this.manager = manager;
         
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            manager.RegisterViewWithRegion<LoginView>("log");
            ViewModelLocationProvider.Register<LoginView, LoginViewModel2>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
