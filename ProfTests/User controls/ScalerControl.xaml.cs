using ProfTests.Interfaces;
using ProfTests.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfTests.User_controls
{
    /// <summary>
    /// Interaction logic for ScalerControl.xaml
    /// </summary>
    public partial class ScalerControl : UserControl, IEvaluation
    {
        public ScalerControl()
        {
            InitializeComponent();
        }

        public TestPageViewModel Model { get; set; }

        private void GoNext(object sender, MouseButtonEventArgs e)
        {
            var slider = sender as Slider;
            var position = e.MouseDevice.GetPosition(slider);
            var cell = (slider.ActualWidth / 9);
            var b = Convert.ToInt32(position.X / cell) + 1;
            if (Math.Abs(position.X - b * cell) < Math.Abs(position.X - (b + 1) * cell))
            {
                Model.SelectedQuestion.Answers.First().ScoreCount = b;
            }
            else
            {
                Model.SelectedQuestion.Answers.First().ScoreCount = b + 1;
            }
            if (Model.NextCommand.CanExecute(null))
                Model.NextCommand.Execute(null);
        }

        private void SetGreen(object sender, MouseEventArgs e)
        {
            Model.SelectedQuestion.Completed = true;
            Model.SelectedMethodic.Completed = !Model.SelectedMethodic.Questions.Any(x => x.Completed != true);
        }
    }

    public class NumberedTickBar : TickBar
    {
        protected override void OnRender(DrawingContext dc)
        {

            Size size = new Size(base.ActualWidth, base.ActualHeight);
            int tickCount = (int)((this.Maximum - this.Minimum) / this.TickFrequency) + 1;
            if ((this.Maximum - this.Minimum) % this.TickFrequency == 0)
                tickCount -= 1;
            Double tickFrequencySize;
            // Calculate tick's setting
            tickFrequencySize = (size.Width * this.TickFrequency / (this.Maximum - this.Minimum));
            string text = "";
            FormattedText formattedText = null;
            double num = this.Maximum - this.Minimum;
            int i = 0;
            // Draw each tick text
            for (i = 0; i <= tickCount; i++)
            {
                text = Convert.ToString(Convert.ToInt32(this.Minimum + this.TickFrequency * i), 10);

#pragma warning disable CS0618 // Type or member is obsolete
                formattedText = new FormattedText(text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 20, Brushes.Black);
#pragma warning restore CS0618 // Type or member is obsolete
                dc.DrawText(formattedText, new Point((tickFrequencySize * i), 30));

            }
        }
    }
}
