using Trex.Framework.Controls.Controls;
using Trex.Framework.Controls.iOS.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxLabel), typeof(TxLabelRenderer))]
namespace Trex.Framework.Controls.iOS.Controls
{
    using UIKit;
    using Xamarin.Forms.Platform.iOS;
    class TxLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
        }
    }
}