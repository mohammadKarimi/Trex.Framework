using Trex.Framework.Controls;
using Trex.Framework.Controls.WinPhone;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxButton), typeof(TxButtonRenderer))]
namespace Trex.Framework.Controls.WinPhone
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
