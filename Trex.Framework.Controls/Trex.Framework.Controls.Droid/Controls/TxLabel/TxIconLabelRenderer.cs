using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxIconLabel), typeof(TxIconLabelRenderer))]
namespace Trex.Framework.Controls.Droid
{
    using System;
    using Xamarin.Forms.Platform.Android;
    public class TxIconLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            this.SetFont((TxIconLabel)Element);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == TxLabel.TextProperty.PropertyName)
                this.SetFont((TxIconLabel)Element);
        }
        private void SetFont(TxIconLabel view)
        {
            Control.Typeface = view.FontFamily.ToExtendedTypeface(view.FontSize, "1", ((int)view.FontAttributes), Context);
        }
    }
}