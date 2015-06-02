namespace Trex.Framework.Service.WinPhone.Application
{
    using System;
    using Trex.Framework.Service;
    public class ApplicationContext : IApplicationContext
    {
        public void CloseApp()
        {
            Windows.ApplicationModel.Core.CoreApplication.Exit();
        }
    }
}