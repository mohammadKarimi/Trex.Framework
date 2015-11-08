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
            this.SetFont((TxIconLabel)Element);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxIconLabel)Element;
            if (e.PropertyName == TxIconLabel.FontProperty.PropertyName)
                this.SetFont(view);
        }
        private void SetFont(TxIconLabel view)
        {
            view.FontFamily = @"\Assets\Fonts\" + view.FontFamily + ".ttf#" + view.FontFamily;
        }
    }
}