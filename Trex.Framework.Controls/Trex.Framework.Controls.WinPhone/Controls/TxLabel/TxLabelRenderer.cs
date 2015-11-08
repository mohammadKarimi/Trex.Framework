using Xamarin.Forms;
using Trex.Framework.Controls;
using Trex.Framework.Controls.WinPhone;

[assembly: ExportRenderer(typeof(TxLabel), typeof(TxLabelRenderer))]
namespace Trex.Framework.Controls.WinPhone
{
    using Xamarin.Forms.Platform.WinPhone;
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
            var view = (TxLabel)Element;
            if (e.PropertyName == TxLabel.FontProperty.PropertyName)
                this.SetFont(view);
        }
        private void SetFont(TxLabel view)
        {
            view.FontFamily = @"\Assets\Fonts\" + view.FontFamily + ".ttf#" + view.FontFamily;
        }
    }
}


