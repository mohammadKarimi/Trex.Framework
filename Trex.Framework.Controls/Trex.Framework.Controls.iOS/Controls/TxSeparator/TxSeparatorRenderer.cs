using Trex.Framework.Controls;
using Trex.Framework.Controls.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxSeparator), typeof(TxSeparatorRenderer))]
namespace Trex.Framework.Controls.iOS
{
    using System.ComponentModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    public class TxSeparatorRenderer : ViewRenderer<TxSeparator, UITxSeparator>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TxSeparator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (Control == null)
            {
                BackgroundColor = Color.Transparent.ToUIColor();
                SetNativeControl(new UITxSeparator(Bounds));
            }

            SetProperties();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetProperties();
        }
        private void SetProperties()
        {
            var TxSeparator = Control;
            TxSeparator.Thickness = Element.Thickness;
            TxSeparator.StrokeColor = Element.Color.ToUIColor();
            TxSeparator.StrokeType = Element.StrokeType;
            TxSeparator.Orientation = Element.Orientation;
            TxSeparator.SpacingBefore = Element.SpacingBefore;
            TxSeparator.SpacingAfter = Element.SpacingAfter;
        }
    }
}

