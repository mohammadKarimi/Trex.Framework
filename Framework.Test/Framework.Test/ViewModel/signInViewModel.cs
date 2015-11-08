using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trex.Framework.Controls;
using Xamarin.Forms;

namespace Framework.Test.ViewModel
{
    public class signInViewModel : BaseViewModel
    {
        public signInViewModel()
        {
            this.signInCommand = new Command(async () => await SignIn());
        }

        private ICommand signInCommand;


        private async Task SignIn()
        {
            
        }

        public ICommand SignInCommand
        {
            get { return signInCommand; }
            set
            {
                if (signInCommand == value)
                    return;
                signInCommand = value;
                OnPropertyChanged();
            }
        }

        private int _DaysOfSyncData { get; set; }
        public int DaysOfSyncData
        {
            get { return _DaysOfSyncData; }
            set
            {
                if (_DaysOfSyncData == value)
                    return;
                _DaysOfSyncData = value;
                OnPropertyChanged();
            }
        }
    }
}
