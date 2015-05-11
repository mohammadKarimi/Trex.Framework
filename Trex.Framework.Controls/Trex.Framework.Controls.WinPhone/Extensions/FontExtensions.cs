namespace Trex.Framework.Controls.WinPhone 
{
    using System;
    using System.Windows.Media;
    using Xamarin.Forms;
    public static class FontExtensions
    {
        public static double GetHeight(this Font font)
        {
            if (!font.UseNamedSize) return font.FontSize;

            switch (font.NamedSize)
            {
                case NamedSize.Micro:
                    return (double)System.Windows.Application.Current.Resources[(object)"PhoneFontSizeSmall"] - 3.0;
                case NamedSize.Small:
                    return (double)System.Windows.Application.Current.Resources[(object)"PhoneFontSizeSmall"];
                case NamedSize.Default:
                case NamedSize.Medium:
                    return (double)System.Windows.Application.Current.Resources[(object)"PhoneFontSizeNormal"];
                case NamedSize.Large:
                    return (double)System.Windows.Application.Current.Resources[(object)"PhoneFontSizeLarge"];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static FontFamily GetFontFamily(this Font font)
        {
            return string.IsNullOrEmpty(font.FontFamily)
                       ? (FontFamily)System.Windows.Application.Current.Resources[(object)"PhoneFontFamilyNormal"]
                       : new FontFamily(font.FontFamily);
        }
    }
}
