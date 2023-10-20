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
using NavBarModule.ViewModels;
using SinhVienModule.ViewModels;
using UserModule.ViewModels;
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


            Type navigateType = typeof(NavBarCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = navigateType.AssemblyQualifiedName, ModuleName = navigateType.Name, InitializationMode = InitializationMode.WhenAvailable });

            Type SinhVienType = typeof(SinhVienCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = SinhVienType.AssemblyQualifiedName, ModuleName = SinhVienType.Name, InitializationMode=InitializationMode.OnDemand });

            Type UserInfoType = typeof(UserCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = UserInfoType.AssemblyQualifiedName, ModuleName = UserInfoType.Name });
        }
        protected override void OnInitialized()
        {
            LoginView loginView = Container.Resolve<LoginView>();
            if(loginView.ShowDialog()==true) base.OnInitialized();
          
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<LoginView,LoginViewModel>();
            ViewModelLocationProvider.Register<SellApp,ShellViewModel>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IConnectDB,ConnectDB>();
        }
    }
}
