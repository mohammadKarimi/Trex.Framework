using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxSeparator), typeof(TxSeparatorRenderer))]

namespace Trex.Framework.Controls.Droid
{
    using System.ComponentModel;
    using Xamarin.Forms.Platform.Android;

    public class TxSeparatorRenderer : ViewRenderer<TxSeparator, TxSeparatorDroidView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TxSeparator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (this.Control == null)
            {
                this.SetNativeControl(new TxSeparatorDroidView(this.Context));
            }

            this.SetProperties();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            this.SetProperties();
        }
        private void SetProperties()
        {
            Control.SpacingBefore = Element.SpacingBefore;
            Control.SpacingAfter = Element.SpacingAfter;
            Control.Thickness = Element.Thickness;
            Control.StrokeColor = Element.Color.ToAndroid();
            Control.StrokeType = Element.StrokeType;
            Control.Orientation = Element.Orientation;

            this.Control.Invalidate();
        }
    }
}

