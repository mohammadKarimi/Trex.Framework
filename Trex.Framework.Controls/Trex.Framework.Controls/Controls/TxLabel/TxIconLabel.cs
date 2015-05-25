namespace Trex.Framework.Controls
{
    using System;
    using Xamarin.Forms;
    public class TxIconLabel : Label
    {
        public TxIconLabel(string text, TxFontIcons font = TxFontIcons.MaterialDesign)
        {
            this.Text = text;
            this.FontFamily = font.ToString();
        }
    }
    public enum TxFontIcons
    {
        FontAwesome,
        MaterialDesign
    }
}
