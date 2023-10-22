using System;
using Prism.Mvvm;
using Prism.Regions;
namespace AdminModule.ViewModels
{
    public class Home_AdminViewModels : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => true;
    }
}
