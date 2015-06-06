namespace Trex.Framework.Service
{
    using Xamarin.Forms;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    public class NavigationService : INavigationService
    {
        public INavigation Navigation { get; set; }
        public Page Page { get; set; }
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return Page.DisplayActionSheet(title, cancel, destruction, buttons);
        }
        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
        {
            return Page.DisplayAlert(title, message, accept, cancel);
        }
        public Task DisplayAlert(string title, string message, string cancel)
        {
            return Page.DisplayAlert(title, message, cancel);
        }
        public Task<Page> PopAsync()
        {
            return Navigation.PopAsync();
        }

        public Task<Page> PopModalAsync()
        {
            return Navigation.PopModalAsync();
        }

        public Task PopToRootAsync()
        {
            return Navigation.PopToRootAsync();
        }

        public Task PushAsync(Page page)
        {
            return Navigation.PushAsync(page);
        }

        public Task PushModalAsync(Page page)
        {
            return Navigation.PushModalAsync(page);
        }



        public void InsertPageBefore(Page page, Page before)
        {
            Navigation.InsertPageBefore(page, before);
        }

        public IReadOnlyList<Page> ModalStack
        {
            get { return Navigation.ModalStack; }
        }

        public IReadOnlyList<Page> NavigationStack
        {
            get { return Navigation.NavigationStack; }
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Navigation.PopAsync(animated);
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navigation.PopToRootAsync(animated);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return Navigation.PushAsync(page, animated);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return Navigation.PushModalAsync(page, animated);
        }

        public void RemovePage(Page page)
        {
            Navigation.RemovePage(page);
        }


    }
}
