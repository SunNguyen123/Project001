using System;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using Sell.Views;
namespace Sell
{
    public class Boottrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<SellApp>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
          
        }
    }
}
