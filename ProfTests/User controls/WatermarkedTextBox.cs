using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProfTests.User_controls
{
    public class WatermarkedTextBox : TextBox
    {
        public static readonly DependencyProperty WatermarkedTextProperty =
            DependencyProperty.Register("WatermarkedText", typeof(string), typeof(WatermarkedTextBox),
                new PropertyMetadata(string.Empty));

        public string WatermarkedText
        {
            get => (string)GetValue(WatermarkedTextProperty);
            set => SetValue(WatermarkedTextProperty, value);
        }
    }
}
