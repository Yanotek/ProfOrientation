using ProfTests.Interfaces;
using ProfTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl, IEvaluation
    {
        public TestControl()
        {
            InitializeComponent();
        }

        public TestPageViewModel Model { get; set; }

        private void SetGreen(object sender, RoutedEventArgs e)
        {
            Model.SelectedQuestion.Completed = true;
            Model.SelectedMethodic.Completed = !Model.SelectedMethodic.Questions.Any(x => x.Completed != true);
            if(Model.NextCommand.CanExecute(null))
                Model.NextCommand.Execute(null);
        }
    }
}
