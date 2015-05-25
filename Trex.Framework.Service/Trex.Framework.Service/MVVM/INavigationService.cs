namespace Trex.Framework.Service.MVVM
{
    using System.Threading.Tasks;
    using Xamarin.Forms;
    public interface INavigationService : INavigation
    {
        Task DisplayAlert(string title, string message, string cancel = "تائید");
        Task<bool> DisplayAlert(string title, string message, string accept = "تائید", string cancel = "انصراف");
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
