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

        private void ExecuteNavigateView(string obj)
        {
            dialogWindow = containerProvider.Resolve<DialogMessageView>();
            dialogWindow.ShowDialog();
            manager.RequestNavigate("Body",new Uri(obj, UriKind.Relative),(result)=> 
         {
             if (result.Result==false) 
             {
                 switch (obj) 
                 {
                     case "qlKhoa_AdminView":
                         var rgbody = manager.Regions["Body"];
                         var qlKhoa = containerProvider.Resolve<qlKhoa_AdminView>();                       
                         rgbody.Add(qlKhoa);
                         rgbody.Activate(qlKhoa);
                         break;
                 }
             }        
         });
        }
    }
}
