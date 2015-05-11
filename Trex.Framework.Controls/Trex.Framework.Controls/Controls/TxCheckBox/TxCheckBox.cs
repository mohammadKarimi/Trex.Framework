namespace Trex.Framework.Controls
{
    using System;
    using Xamarin.Forms;
    using Trex.Framework.Controls.Extensions;
    using Trex.Framework.Core.Helper;
    using Trex.Framework.Core.Extensions;
    public class TxCheckBox : View
    {
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create<TxCheckBox, bool>(
                p => p.Checked, false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        public static readonly BindableProperty CheckedTextProperty =
            BindableProperty.Create<TxCheckBox, string>(
                p => p.CheckedText, string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty UncheckedTextProperty =
            BindableProperty.Create<TxCheckBox, string>(
                p => p.UncheckedText, string.Empty);

        public static readonly BindableProperty DefaultTextProperty =
            BindableProperty.Create<TxCheckBox, string>(
                p => p.Text, string.Empty);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<TxCheckBox, Color>(
                p => p.TextColor, Color.Black);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create<TxCheckBox, double>(
                p => p.FontSize, -1);

     
        public static readonly BindableProperty FontNameProperty =
            BindableProperty.Create<TxCheckBox, string>(
                p => p.FontName, string.Empty);

        public event EventHandler<EventArgs<bool>> CheckedChanged;

        public bool Checked
        {
            get
            {
                return this.GetValue<bool>(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    this.SetValue(CheckedProperty, value);
                    this.CheckedChanged.Invoke(this, value);
                }
            }
        }

        public string CheckedText
        {
            get
            {
                return this.GetValue<string>(CheckedTextProperty);
            }

            set
            {
                this.SetValue(CheckedTextProperty, value);
            }
        }
   
        public string UncheckedText
        {
            get
            {
                return this.GetValue<string>(UncheckedTextProperty);
            }

            set
            {
                this.SetValue(UncheckedTextProperty, value);
            }
        }
 
        public string DefaultText
        {
            get
            {
                return this.GetValue<string>(DefaultTextProperty);
            }

            set
            {
                this.SetValue(DefaultTextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return this.GetValue<Color>(TextColorProperty);
            }

            set
            {
                this.SetValue(TextColorProperty, value);
            }
        }
 
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }
        public string Text
        {
            get
            {
                return this.Checked
                    ? (string.IsNullOrEmpty(this.CheckedText) ? this.DefaultText : this.CheckedText)
                        : (string.IsNullOrEmpty(this.UncheckedText) ? this.DefaultText : this.UncheckedText);
            }
        }

        private static void OnCheckedPropertyChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        {
            var TxCheckBox = (TxCheckBox)bindable;
            TxCheckBox.Checked = newvalue;
        }
    }
}
