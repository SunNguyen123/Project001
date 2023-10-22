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
using AdminModule.ViewModels;
using UserModule.ViewModels;
using Library_Dialog.ViewModels;
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

            Type DialogSvType = typeof(DialogCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = DialogSvType.AssemblyQualifiedName, ModuleName = DialogSvType.Name});

            Type loginType = typeof(LoginCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = loginType.AssemblyQualifiedName, ModuleName = loginType.Name });


            Type navigateType = typeof(NavBarCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = navigateType.AssemblyQualifiedName, ModuleName = navigateType.Name, InitializationMode = InitializationMode.WhenAvailable });

            Type SinhVienType = typeof(SinhVienCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = SinhVienType.AssemblyQualifiedName, ModuleName = SinhVienType.Name, InitializationMode=InitializationMode.OnDemand });

            Type UserInfoType = typeof(UserCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = UserInfoType.AssemblyQualifiedName, ModuleName = UserInfoType.Name });

            Type AdminType = typeof(AdminModuleCentre);
            moduleCatalog.AddModule(new ModuleInfo() { ModuleType = AdminType.AssemblyQualifiedName, ModuleName = AdminType.Name, InitializationMode = InitializationMode.OnDemand });


        }
        protected override void OnInitialized()
        {
            LoginView loginView = Container.Resolve<LoginView>();
            if (loginView.ShowDialog() == true) base.OnInitialized();
            else Application.Current.Shutdown();
          
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
