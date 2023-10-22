using System;
using System.Collections.Generic;
using Prism.Ioc;
using Prism.Modularity;
using Library_Dialog.Views;
using Library_Dialog.ViewModels;
using Prism.Mvvm;

namespace Library_Dialog.ViewModels
{
    public class DialogCentre : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

            ViewModelLocationProvider.Register<DialogMessageView, DialogMessageViewModel>();
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<DialogMessageView>();
        }
    }
}
