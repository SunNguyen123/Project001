using System;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using Sell.Views;
using Sell.ViewModels;
namespace Sell
{
    public class Boottrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<SellApp>();
        }
        protected override void OnInitialized()
        {
            LoginView loginView = Container.Resolve<LoginView>();
            if (loginView.ShowDialog() == true) base.OnInitialized();
            else Application.Current.Shutdown();
        }
        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.Register<LoginView,LoginViewModel>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}
