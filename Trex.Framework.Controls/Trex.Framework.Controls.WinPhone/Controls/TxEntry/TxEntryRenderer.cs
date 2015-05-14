using Xamarin.Forms;
using Trex.Framework.Controls;
using Trex.Framework.Controls.WinPhone ;

[assembly: ExportRenderer(typeof(TxEntry), typeof(TxEntryRenderer))]
namespace Trex.Framework.Controls.WinPhone
{
    using Microsoft.Phone.Controls;
    using System.Windows.Controls;
    using Xamarin.Forms.Platform.WinPhone;
    using System.Linq;
    using TextAlignment = TextAlignment;
    using System.ComponentModel;

    public class TxEntryRenderer : EntryRenderer
    {
        private PasswordBox _passwordBox;
        private PhoneTextBox _phoneTextBox;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var view = (TxEntry)Element;
            if (view.IsPassword)
            {
                _passwordBox = (PasswordBox)Control.Children.FirstOrDefault(c => c is PasswordBox);
            }
            else
            {
                _phoneTextBox = (PhoneTextBox)Control.Children.FirstOrDefault(c => c is PhoneTextBox);
            }
            this.SetFont(view);
            this.SetXAlign(view);
            this.SetMaxLength(view);
            this.SetPlaceholderTextColor(view);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxEntry)Element;
            if (e.PropertyName == TxEntry.FontProperty.PropertyName)
                this.SetFont(view);
            if (e.PropertyName == TxEntry.XAlignProperty.PropertyName)
                this.SetXAlign(view);
            if (e.PropertyName == TxEntry.PlaceholderTextColorProperty.PropertyName)
                this.SetPlaceholderTextColor(view);
        }
        #region Customized Method
        private void SetFont(TxEntry view)
        {
            if (view.Font != Font.Default)
            {
                //Text Me
                view.Font = Font.OfSize(string.Format(@"\Assets\Fonts\{0}.ttf#{1}", view.Font.FontFamily, view.Font.FontFamily), view.Font.FontSize);
                if (view.IsPassword)
                {
                    if (_passwordBox != null)
                    {
                        _passwordBox.FontSize = view.Font.GetHeight();
                    }
                }
                else
                {
                    if (_phoneTextBox != null)
                    {
                        _phoneTextBox.FontSize = view.Font.GetHeight();
                    }
                }
            }
        }
        private void SetXAlign(TxEntry view)
        {
            if (!view.IsPassword && _phoneTextBox != null)
            {
                switch (view.XAlign)
                {
                    case TextAlignment.Center:
                        _phoneTextBox.TextAlignment = System.Windows.TextAlignment.Center;
                        break;
                    case TextAlignment.End:
                        _phoneTextBox.TextAlignment = System.Windows.TextAlignment.Right;
                        break;
                    case TextAlignment.Start:
                        _phoneTextBox.TextAlignment = System.Windows.TextAlignment.Left;
                        break;
                }
            }
        }
        private void SetMaxLength(TxEntry view)
        {
            if (_phoneTextBox != null) _phoneTextBox.MaxLength = view.MaxLength;
        }
        private void SetPlaceholderTextColor(TxEntry view)
        {
            if (!view.IsPassword)
                if (view.PlaceholderTextColor != Color.Default && _phoneTextBox != null)
                {
                    var hintStyle = new System.Windows.Style(typeof(System.Windows.Controls.ContentControl));
                    hintStyle.Setters.Add(
                        new System.Windows.Setter(
                            System.Windows.Controls.Control.ForegroundProperty,
                            view.PlaceholderTextColor.ToBrush())
                        );
                    _phoneTextBox.HintStyle = hintStyle;
                }
        }
        #endregion
    }
}
