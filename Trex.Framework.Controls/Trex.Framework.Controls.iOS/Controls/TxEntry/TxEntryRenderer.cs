using Trex.Framework.Controls;
using Trex.Framework.Controls.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxEntry), typeof(TxEntryRenderer))]
namespace Trex.Framework.Controls.iOS
{
    using Foundation;
    using System;
    using System.ComponentModel;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;
    public class TxEntryRenderer : EntryRenderer
    {
        private UISwipeGestureRecognizer _leftSwipeGestureRecognizer;
        private UISwipeGestureRecognizer _rightSwipeGestureRecognizer;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (TxEntry)Element;

            if (view != null)
            {
                SetFont(view);
                SetXAlign(view);
                SetPlaceholderTextColor(view);
                SetMaxLength(view);
            }

            if (e.OldElement == null)
            {
                _leftSwipeGestureRecognizer = new UISwipeGestureRecognizer(() => view.OnLeftSwipe(this, EventArgs.Empty))
                {
                    Direction = UISwipeGestureRecognizerDirection.Left
                };

                _rightSwipeGestureRecognizer = new UISwipeGestureRecognizer(() => view.OnRightSwipe(this, EventArgs.Empty))
                {
                    Direction = UISwipeGestureRecognizerDirection.Right
                };

                Control.AddGestureRecognizer(_leftSwipeGestureRecognizer);
                Control.AddGestureRecognizer(_rightSwipeGestureRecognizer);
            }

            if (e.NewElement == null)
            {
                Control.RemoveGestureRecognizer(_leftSwipeGestureRecognizer);
                Control.RemoveGestureRecognizer(_rightSwipeGestureRecognizer);
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxEntry)Element;
            if (e.PropertyName == TxEntry.XAlignProperty.PropertyName)
                SetXAlign(view);
            if (e.PropertyName == TxEntry.PlaceholderTextColorProperty.PropertyName)
                SetPlaceholderTextColor(view);
        }

        private void SetFont(TxEntry view)
        {
            UIFont uiFont;
            if (view.Font != Font.Default && (uiFont = view.Font.ToUIFont()) != null)
                Control.Font = uiFont;
            else if (view.Font == Font.Default)
                Control.Font = UIFont.SystemFontOfSize(17f);
        }
        private void SetXAlign(TxEntry view)
        {
            switch (view.XAlign)
            {
                case TextAlignment.Center:
                    Control.TextAlignment = UITextAlignment.Center;
                    break;
                case TextAlignment.End:
                    Control.TextAlignment = UITextAlignment.Right;
                    break;
                case TextAlignment.Start:
                    Control.TextAlignment = UITextAlignment.Left;
                    break;
            }
        }
        private void SetMaxLength(TxEntry view)
        {
            Control.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= view.MaxLength;
            };
        }
        private void SetPlaceholderTextColor(TxEntry view)
        {
            if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderTextColor != Color.Default)
            {
                NSAttributedString placeholderString = new NSAttributedString(view.Placeholder, new UIStringAttributes() { ForegroundColor = view.PlaceholderTextColor.ToUIColor() });
                Control.AttributedPlaceholder = placeholderString;
            }
        }
    }
}


