namespace Trex.Framework.Controls.Controls.TxLabel
{
    using System;
    using Xamarin.Forms;
    public class TxIconLabel : Label
    {
        public TxIconLabel(string text, TxFontIcons font = TxFontIcons.FontAwesome)
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
