using Trex.Framework.Controls.Controls;
using Trex.Framework.Controls.Droid.Controls;
using Xamarin.Forms;


[assembly: ExportRenderer(typeof(TxLabel), typeof(TxLabelRenderer))]
namespace Trex.Framework.Controls.Droid.Controls
{
    using Xamarin.Forms.Platform.Android;
    public class TxLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            this.SetFont((Label)Element);
        }
        private void SetFont(Label view)
        {
            Control.Typeface = view.FontFamily.ToExtendedTypeface(view.FontSize, "1", ((int)view.FontAttributes), Context);
        }
    }
}