using Xamarin.Forms;
using Trex.Framework.Controls;
using Trex.Framework.Controls.WinPhone;

[assembly: ExportRenderer(typeof(TxIconLabel), typeof(TxIconLabelRenderer))]
namespace Trex.Framework.Controls.WinPhone
{
    using Xamarin.Forms.Platform.WinPhone;
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
            view.FontFamily = string.Format(@"\Assets\Fonts\{0}.ttf#{1}", view.FontFamily, view.FontFamily);
        }
    }
}