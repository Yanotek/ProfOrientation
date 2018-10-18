using ProfTests.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ProfTests.Converters
{
    class QuestionBorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var quest = (bool)value;
            if (quest)
                
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66008000"));
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F1E1E1E"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
