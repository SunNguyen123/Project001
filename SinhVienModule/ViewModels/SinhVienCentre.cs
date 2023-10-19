using System;
using System.Xml;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SinhVienModule.Views;
namespace SinhVienModule.ViewModels
{
    public class SinhVienCentre : IModule
    {
        private IRegionManager manager;
        public SinhVienCentre(IRegionManager manager)
        {
                this.manager = manager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            manager.RegisterViewWithRegion<QuanlySvView>("Body");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
