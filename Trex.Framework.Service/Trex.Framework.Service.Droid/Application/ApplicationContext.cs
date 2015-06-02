namespace Trex.Framework.Service.Droid.Application
{
    using System;
    using Trex.Framework.Service;
    public class ApplicationContext : IApplicationContext
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}