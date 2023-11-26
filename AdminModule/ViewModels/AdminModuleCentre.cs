using System;
using Prism.Unity;
using Prism.Modularity;
using Prism.Ioc;
using Prism.Mvvm;
using AdminModule.ViewModels;
using AdminModule.Views;
using Prism.Regions;
using Prism.Services.Dialogs;
using Library_Dialog.ViewModels;
using Library_Dialog.Views;

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
            ///view
            ViewModelLocationProvider.Register<qlKhoa_AdminView,qlKhoa_AdminViewModels>();
            ViewModelLocationProvider.Register<qlSinhVien_AdminView,qlSinhVien_AdminViewModel>();
            ViewModelLocationProvider.Register<qlNganh_AdminView,qlNganh_AdminViewModel>();
            ViewModelLocationProvider.Register<qlLop_AdminView,qlLop_AdminViewModel>();

            /// dich vu
            ViewModelLocationProvider.Register<Home_AdminView,Home_AdminViewModels>();
            ViewModelLocationProvider.Register<AddKhoaServiceView,AddKhoaServiceViewModel>();
            ViewModelLocationProvider.Register<EditKhoa_AdminView,EditKhoaServiceViewModel>();
            ViewModelLocationProvider.Register<AddSinhVien_AdminView,AddSinhVien_AdminViewModel>();
            ViewModelLocationProvider.Register<NganhServiceView,NganhServiceViewModel>();
            ViewModelLocationProvider.Register<LopServiceView,LopServiceViewModel>();


            regionManager.RegisterViewWithRegion<Home_AdminView>("Body");
            regionManager.RegisterViewWithRegion<qlKhoa_AdminView>("Body");
            regionManager.RegisterViewWithRegion<qlSinhVien_AdminView>("Body");
            regionManager.RegisterViewWithRegion<qlNganh_AdminView>("Body");
            regionManager.RegisterViewWithRegion<qlLop_AdminView>("Body");
            //containerRegistry.RegisterForNavigation<qlKhoa_AdminView, qlKhoa_AdminViewModels>();
            //regionManager.RegisterViewWithRegion<qlKhoa_AdminView>("Body");
            //var rgbody = regionManager.Regions["Body"];
            //var qlKhoa = containerProvider.Resolve<qlKhoa_AdminView>();
            //rgbody.Add(qlKhoa);

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddKhoaServiceView, AddKhoaServiceViewModel>();
            containerRegistry.RegisterDialog<EditKhoa_AdminView, EditKhoaServiceViewModel>();
            containerRegistry.RegisterDialog<AddSinhVien_AdminView, AddSinhVien_AdminViewModel>();
            containerRegistry.RegisterDialog<NganhServiceView, NganhServiceViewModel>();
            containerRegistry.RegisterDialog<LopServiceView, LopServiceViewModel>();
        }
    }
}
