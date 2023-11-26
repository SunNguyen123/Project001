using LoginModule.Model;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using System;
using Prism.Ioc;
using AdminModule.Views;
using AdminModule.ViewModels;
using Prism.Services.Dialogs;
using Library_Dialog.Views;
using System.Windows.Navigation;

namespace NavBarModule.ViewModels
{
   public class Nav_AdminViewModels:BindableBase,IRegionMemberLifetime
    {
        public DelegateCommand<string> navigateView { set; get; }
        public bool KeepAlive => true;
        private IContainerProvider containerProvider;
        private IRegionManager manager;
        private IDialogWindow dialogWindow;
        public Nav_AdminViewModels(IRegionManager manager, IContainerProvider containerProvider)
        {
            navigateView = new DelegateCommand<string>(ExecuteNavigateView);
            this.manager = manager;
            this.containerProvider = containerProvider;
           
           
        }

        private  void ExecuteNavigateView(string obj)
        {
            
            
            manager.RequestNavigate("Body", new Uri(obj, UriKind.Relative), (result) =>
         {
             if (result.Result == false)
             {
                 switch (obj)
                 {
                     case "qlKhoa_AdminView":
                         var rgbody = manager.Regions["Body"];
                         var qlKhoa = containerProvider.Resolve<qlKhoa_AdminView>();
                         rgbody.Add(qlKhoa);
                         rgbody.Activate(qlKhoa);
                         break;
                     case "qlNganh_AdminView":
                         var rgbody1 = manager.Regions["Body"];
                         var qlNganh = containerProvider.Resolve<qlNganh_AdminView>();
                         rgbody1.Add(qlNganh);
                         rgbody1.Activate(qlNganh);
                         break;
                 }
             }
         });








        }
    }
}
