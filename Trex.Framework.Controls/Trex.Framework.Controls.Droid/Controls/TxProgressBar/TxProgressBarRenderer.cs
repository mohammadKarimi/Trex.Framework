using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxProgressBar), typeof(TxProgressBarRenderer))]
namespace Trex.Framework.Controls.Droid
{
    using System;
    using Xamarin.Forms.Platform.Android;
    public class TxProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            Control.Indeterminate = ((TxProgressBar)Element).Indeterminate;
        }
    }
}