using System.Globalization;
using System.Windows.Data;

namespace WpfLib.Converter
{
    /// <summary>
    /// 乗算するコンバータ
    /// </summary>
    public class MultiplyConverter : IMultiValueConverter
    {
        /// <summary>
        /// convert
        /// </summary>
        /// <param name="values">values</param>
        /// <param name="targetType">targetType</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>returns</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double v)
                {
                    result *= v;
                }
            }

            return result;
        }

        /// <summary>
        /// convert back
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="targetTypes">targetTypes</param>
        /// <param name="parameter">parameter</param>
        /// <param name="culture">culture</param>
        /// <returns>returns</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
}
