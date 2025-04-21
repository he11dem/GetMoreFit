using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GetMoreFit.Convertors
{
    public class IndexToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Преобразует индекс (0, 1, 2...) в нумерацию (1, 2, 3...)
            return ((int)value + 1).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException(); // Обратное преобразование не требуется
        }
    }
}
