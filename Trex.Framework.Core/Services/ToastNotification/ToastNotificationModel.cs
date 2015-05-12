namespace Trex.Framework.Core.Services
{
    using System;
   public  class ToastNotificationModel
    {
        public ToastNotificationType type { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public TimeSpan duration { get; set; }
        public object context { get; set; }
    }

   public enum ToastNotificationType
   {
       Info,
       Success,
       Warning,
       Error,
   }
}
