using Xamarin.Forms;
using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid;

[assembly: ExportRenderer(typeof(TxEntry), typeof(TxEntryRendered))]
namespace Trex.Framework.Controls.Droid
{
    using System;
    using Xamarin.Forms.Platform.Android;
    using Android.Views;
    using Android.Text;

    public class TxEntryRendered : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var view = (TxEntry)Element;
            this.SetFont(view);
            this.SetXAlign(view);
            this.SetMaxLength(view);
            this.SetPlaceholderTextColor(view);
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxEntry)Element;
            if (e.PropertyName == TxEntry.FontProperty.PropertyName)
                this.SetFont(view);
            if (e.PropertyName == TxEntry.XAlignProperty.PropertyName)
                this.SetXAlign(view);
            if (e.PropertyName == TxEntry.MaxLengthProperty.PropertyName)
                this.SetMaxLength(view);
            if (e.PropertyName == TxEntry.PlaceholderTextColorProperty.PropertyName)
                this.SetPlaceholderTextColor(view);
        }

        #region Customized Method

        private void SetFont(TxEntry view)
        {
            if (view.Font != Font.Default)
            {
                Control.TextSize = view.Font.ToScaledPixel();
                Control.Typeface = view.Font.ToExtendedTypeface(Context);
            }
        }

        private void SetXAlign(TxEntry view)
        {
            switch (view.XAlign)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    Control.Gravity = GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    Control.Gravity = GravityFlags.End;
                    break;
                case Xamarin.Forms.TextAlignment.Start:
                    Control.Gravity = GravityFlags.Start;
                    break;
            }
        }
        private void SetMaxLength(TxEntry view)
        {
            Control.SetFilters(new IInputFilter[] { new global::Android.Text.InputFilterLengthFilter(view.MaxLength) });
        }
        private void SetPlaceholderTextColor(TxEntry view)
        {
            if (view.PlaceholderTextColor != Xamarin.Forms.Color.Default)
            {
                Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());
            }
        }
        #endregion
    }
}