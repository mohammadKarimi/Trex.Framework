namespace Trex.Framework.Controls
{

    using System;
    using Xamarin.Forms;

    public class TxEntry : Entry
    {
        public static readonly BindableProperty FontProperty = BindableProperty.Create("Font", typeof(Font), typeof(TxEntry), new Font());
        public Font Font
        {
            get { return (Font)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }

        public static readonly BindableProperty XAlignProperty = BindableProperty.Create("XAlign", typeof(TextAlignment), typeof(TxEntry), TextAlignmentExtension.Start);
        public TextAlignment XAlign
        {
            get { return (TextAlignment)GetValue(XAlignProperty); }
            set { SetValue(XAlignProperty, value); }
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(TxEntry), int.MaxValue);
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(TxEntry), Color.Default);
        public Color PlaceholderTextColor
        {
            get { return (Color)GetValue(PlaceholderTextColorProperty); }
            set { SetValue(PlaceholderTextColorProperty, value); }
        }

        #region __iOS__
        public EventHandler LeftSwipe;
        public EventHandler RightSwipe;
        public void OnLeftSwipe(object sender, EventArgs e)
        {
            var handler = this.LeftSwipe;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnRightSwipe(object sender, EventArgs e)
        {
            var handler = this.RightSwipe;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
}
