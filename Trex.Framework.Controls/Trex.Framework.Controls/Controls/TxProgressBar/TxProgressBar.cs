namespace Trex.Framework.Controls
{
    using Xamarin.Forms;
    public class TxProgressBar : ProgressBar
    {
        public static readonly BindableProperty IndeterminateProperty = BindableProperty.Create("Indeterminate ", typeof(bool), typeof(TxProgressBar), false);
        public bool Indeterminate
        {
            get { return (bool)GetValue(IndeterminateProperty); }
            set { SetValue(IndeterminateProperty, value); }
        }
    }
}
