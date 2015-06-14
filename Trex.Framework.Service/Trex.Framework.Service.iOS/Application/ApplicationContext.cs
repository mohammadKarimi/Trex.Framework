namespace Trex.Framework.Service.iOS.Application
{
    using Foundation;
    using System;
    using Trex.Framework.Service;
    public class ApplicationContext : IApplicationContext
    {
        public void CloseApp()
        {
            NSThread.Exit();
        }
    }
}