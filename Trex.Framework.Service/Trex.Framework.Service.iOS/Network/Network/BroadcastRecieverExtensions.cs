namespace Trex.Framework.Service.Droid.Network.Extension
{
    using Android.App;
    using Android.Content;
    using System;
    public static class BroadcastReceiverExtensions
    {
        public static Intent RegisterReceiver(this BroadcastReceiver receiver, IntentFilter intentFilter)
        {
            return Application.Context.RegisterReceiver(receiver, intentFilter);
        }

        public static void UnregisterReceiver(this BroadcastReceiver receiver)
        {
            Application.Context.UnregisterReceiver(receiver);
        }
    }
}