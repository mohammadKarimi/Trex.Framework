using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid;
using Xamarin.Forms;


[assembly: ExportRenderer(typeof(TxLabel), typeof(TxLabelRenderer))]
namespace Trex.Framework.Controls.Droid
{
    using Xamarin.Forms.Platform.Android;
    public class TxLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            this.SetFont((TxLabel)Element);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName == TxLabel.TextProperty.PropertyName)
                    this.SetFont((TxLabel)Element);
                if (e.PropertyName == TxLabel.FontFamilyProperty.PropertyName)
                    this.SetFont((TxLabel)Element);
        }

        private void SetFont(TxLabel view)
        {
            Control.Typeface = view.FontFamily.ToExtendedTypeface(view.FontSize, "1", ((int)view.FontAttributes), Context);
        }
    }
}