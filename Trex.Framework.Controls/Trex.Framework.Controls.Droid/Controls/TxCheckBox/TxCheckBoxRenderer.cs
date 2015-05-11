using Trex.Framework.Controls;
using Trex.Framework.Controls.Droid.Controls;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TxCheckBox), typeof(TxCheckBoxRenderer))]
namespace Trex.Framework.Controls.Droid.Controls
{
    using Android.Graphics;
    using System;
    using System.ComponentModel;
    using Xamarin.Forms.Platform.Android;
    public class TxCheckBoxRenderer : ViewRenderer<TxCheckBox, Android.Widget.CheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TxCheckBox> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
            {
                var checkBox = new Android.Widget.CheckBox(this.Context);
                checkBox.CheckedChange += CheckBoxCheckedChange;
                this.SetNativeControl(checkBox);
            }
            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.SetTextColor(e.NewElement.TextColor.ToAndroid());
            if (e.NewElement.FontSize > 0)
            {
                Control.TextSize = (float)e.NewElement.FontSize;
            }
            this.SetFont((TxCheckBox)Element);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (TxCheckBox)Element;
            if (e.PropertyName == TxCheckBox.FontProperty.PropertyName)
                this.SetFont(view);
            if (e.PropertyName == TxCheckBox.CheckedProperty.PropertyName)

                if (e.PropertyName == TxCheckBox.FontProperty.PropertyName)
                {
                    Control.Text = Element.Text;
                    Control.Checked = Element.Checked;
                }
            if (e.PropertyName == TxCheckBox.TextColorProperty.PropertyName)
                Control.SetTextColor(Element.TextColor.ToAndroid());
            if (e.PropertyName == TxCheckBox.FontSizeProperty.PropertyName)
            {
                if (Element.FontSize > 0)
                {
                    Control.TextSize = (float)Element.FontSize;
                }
            }
            if (e.PropertyName == TxCheckBox.UncheckedTextProperty.PropertyName)
            {
                Control.Text = Element.Text;
            }
        }
        private void SetFont(TxCheckBox view)
        {
            if (view.Font != Font.Default)
            {
                Control.TextSize = view.Font.ToScaledPixel();
                Control.Typeface = view.Font.ToExtendedTypeface(Context);
            }
        }
        void CheckBoxCheckedChange(object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e)
        {
            this.Element.Checked = e.IsChecked;
        }
    }
}