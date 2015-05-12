namespace Trex.Framework.Core.Services
{
    using System;
    using System.Threading.Tasks;
    public interface IToastNotificatoion
    {
        Task<bool> Notify(ToastNotificationModel notify);
        void RemoveAll();
    }
}
