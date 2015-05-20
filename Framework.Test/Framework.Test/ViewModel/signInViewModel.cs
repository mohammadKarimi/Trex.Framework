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
            var a = Navigation;
            await Page.DisplayAlert("sad", "asdf", "asdf");
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

    }
}
