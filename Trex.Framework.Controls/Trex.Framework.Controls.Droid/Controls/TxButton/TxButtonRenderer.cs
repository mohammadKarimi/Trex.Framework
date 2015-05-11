using Trex.Framework.Controls.Controls;
using Trex.Framework.Controls.Droid.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxButton), typeof(TxButtonRenderer))]
namespace Trex.Framework.Controls.Droid.Controls
{
    using Xamarin.Forms.Platform.Android;
    public class TxButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            this.SetFont((TxButton)Element);
        }
        private void SetFont(TxButton view)
        {
            if (view.Font != Font.Default)
            {
                Control.Typeface = view.Font.ToExtendedTypeface(Context);
            }
        }
    }
}