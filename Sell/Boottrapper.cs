using System;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using Sell.Views;
using Sell.ViewModels;
using Prism.Modularity;
using Libary_ConnectDB;
using LoginModule.ViewModels;

namespace Sell
{
    public class Boottrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<SellApp>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type loginType = typeof(LoginCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = loginType.AssemblyQualifiedName, ModuleName = loginType.Name });
        }
        protected override void OnInitialized()
        {
            LoginView loginView = Container.Resolve<LoginView>();
            if(loginView.ShowDialog()==true) base.OnInitialized();
          
        }
        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.Register<LoginView,LoginViewModel>();
            base.ConfigureViewModelLocator();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IConnectDB,ConnectDB>();
        }
    }
}
