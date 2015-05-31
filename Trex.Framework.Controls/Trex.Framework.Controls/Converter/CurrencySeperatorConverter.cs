namespace Trex.Framework.Controls.Converter
{
    using System;
    using Xamarin.Forms;
    public class CurrencySeperatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
            {
                var currency = ((decimal)value).ToString("0,0");
                return currency.ToString();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
