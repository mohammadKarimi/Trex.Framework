namespace Trex.Framework.Controls
{
    using Xamarin.Forms;

    public class TxSeparator : View
    {
        public TxSeparator()
        {
            UpdateRequestedSize();
        }
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(TxSeparatorOrientation), typeof(TxSeparator), TxSeparatorOrientation.Horizontal, BindingMode.OneWay, null, null, null, null);
        public TxSeparatorOrientation Orientation
        {
            get
            {
                return (TxSeparatorOrientation)base.GetValue(TxSeparator.OrientationProperty);
            }

            private set
            {
                base.SetValue(TxSeparator.OrientationProperty, value);
            }
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(Color), typeof(TxSeparator), Color.Default, BindingMode.OneWay, null, null, null, null);
        public Color Color
        {
            get
            {
                return (Color)base.GetValue(TxSeparator.ColorProperty);
            }
            set
            {
                base.SetValue(TxSeparator.ColorProperty, value);
            }
        }
        public static readonly BindableProperty SpacingBeforeProperty = BindableProperty.Create("SpacingBefore", typeof(double), typeof(TxSeparator), (double)1, BindingMode.OneWay, null, null, null, null);
        public double SpacingBefore
        {
            get
            {
                return (double)base.GetValue(TxSeparator.SpacingBeforeProperty);
            }
            set
            {
                base.SetValue(TxSeparator.SpacingBeforeProperty, value);
            }
        }

        public static readonly BindableProperty SpacingAfterProperty = BindableProperty.Create("SpacingAfter", typeof(double), typeof(TxSeparator), (double)1, BindingMode.OneWay, null, null, null, null);
        public double SpacingAfter
        {
            get
            {
                return (double)base.GetValue(TxSeparator.SpacingAfterProperty);
            }
            set
            {
                base.SetValue(TxSeparator.SpacingAfterProperty, value);
            }
        }
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create("Thickness", typeof(double), typeof(TxSeparator), (double)1, BindingMode.OneWay, null, null, null, null);
        public double Thickness
        {
            get
            {
                return (double)base.GetValue(TxSeparator.ThicknessProperty);
            }
            set
            {
                base.SetValue(TxSeparator.ThicknessProperty, value);
            }
        }
        public static readonly BindableProperty StrokeTypeProperty = BindableProperty.Create("StrokeType", typeof(StrokeType), typeof(TxSeparator), StrokeType.Solid, BindingMode.OneWay, null, null, null, null);
        public StrokeType StrokeType
        {
            get
            {
                return (StrokeType)base.GetValue(TxSeparator.StrokeTypeProperty);
            }
            set
            {
                base.SetValue(TxSeparator.StrokeTypeProperty, value);
            }
        }
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ThicknessProperty.PropertyName ||
               propertyName == ColorProperty.PropertyName ||
               propertyName == SpacingBeforeProperty.PropertyName ||
               propertyName == SpacingAfterProperty.PropertyName ||
               propertyName == StrokeTypeProperty.PropertyName ||
               propertyName == OrientationProperty.PropertyName)
            {
                UpdateRequestedSize();
            }
        }
        private void UpdateRequestedSize()
        {
            var minSize = Thickness;
            var optimalSize = SpacingBefore + Thickness + SpacingAfter;
            if (Orientation == TxSeparatorOrientation.Horizontal)
            {
                MinimumHeightRequest = minSize;
                HeightRequest = optimalSize;
                HorizontalOptions = LayoutOptions.FillAndExpand;
            }
            else
            {
                MinimumWidthRequest = minSize;
                WidthRequest = optimalSize;
                VerticalOptions = LayoutOptions.FillAndExpand;
            }
        }
    }
    public enum StrokeType
    {
        Solid,
        Dotted,
        Dashed
    }
    public enum TxSeparatorOrientation
    {
        Vertical,
        Horizontal
    }

}
