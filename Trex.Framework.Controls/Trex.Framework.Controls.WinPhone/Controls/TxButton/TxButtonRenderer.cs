using Trex.Framework.Controls.Controls;
using Trex.Framework.Controls.WinPhone.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxButton), typeof(TxButtonRenderer))]
namespace Trex.Framework.Controls.WinPhone.Controls
{
    using System;
    using Xamarin.Forms.Platform.WinPhone;
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
                view.FontFamily = string.Format(@"\Assets\Fonts\{0}.ttf#{1}", view.FontFamily, view.FontFamily);
        }
    }
}
