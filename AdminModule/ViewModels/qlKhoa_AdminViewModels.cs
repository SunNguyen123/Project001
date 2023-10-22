using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace AdminModule.ViewModels
{
    public class qlKhoa_AdminViewModels : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;
        private IDialogService dialogsv;
        private string ag="100";

        public string Age
        {
            get { return ag; }
            set { ag = value; }
        }

        public qlKhoa_AdminViewModels(IDialogService dialogsv,IDialogWindow window)
        {
            this.dialogsv = dialogsv;
        }




    }
}
