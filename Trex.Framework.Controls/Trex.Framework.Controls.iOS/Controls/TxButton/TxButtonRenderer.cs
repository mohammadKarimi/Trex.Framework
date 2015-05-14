using Trex.Framework.Controls;
using Trex.Framework.Controls.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxButton), typeof(TxButtonRenderer))]
namespace Trex.Framework.Controls.iOS
{
    using System;
    using Trex.Framework.Controls;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;
    public class TxButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            this.SetFont((TxButton)Element);
        }
        private void SetFont(TxButton view)
        {
            UIFont uiFont;
            if (view.Font != Font.Default && (uiFont = view.Font.ToUIFont()) != null)
                Control.Font = uiFont;
            else if (view.Font == Font.Default)
                Control.Font = UIFont.SystemFontOfSize(17f);
        }
    }
}