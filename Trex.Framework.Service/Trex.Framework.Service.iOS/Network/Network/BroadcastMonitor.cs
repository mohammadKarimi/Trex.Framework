namespace Trex.Framework.Service.Droid.Network
{
    using Android.Content;
    using System;
    using Trex.Framework.Service.Droid.Network.Extension;
    public abstract class BroadcastMonitor : BroadcastReceiver
    {
        public virtual bool Start()
        {
            var intent = this.RegisterReceiver(this.Filter);
            if (intent == null)
            {
                return false;
            }

            return true;
        }


        public virtual void Stop()
        {
            this.UnregisterReceiver();
        }

        protected abstract IntentFilter Filter { get; }
    }
}