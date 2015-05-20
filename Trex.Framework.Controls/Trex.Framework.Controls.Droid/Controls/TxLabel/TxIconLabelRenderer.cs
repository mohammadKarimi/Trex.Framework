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
            this.SetFont((TxLabel)Element);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxLabel)Element;
            if (e.PropertyName == TxLabel.FontProperty.PropertyName)
                this.SetFont(view);
        }
        private void SetFont(TxLabel view)
        {
            Control.Typeface = view.FontFamily.ToExtendedTypeface(view.FontSize, "1", ((int)view.FontAttributes), Context);
        }
    }
}