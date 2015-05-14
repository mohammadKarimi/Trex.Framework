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
        private void SetFont(TxLabel view)
        {
            view.FontFamily = string.Format(@"\Assets\Fonts\{0}.ttf#{1}", view.FontFamily, view.FontFamily);
        }
    }
}


