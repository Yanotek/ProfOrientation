using ProfTests.Interfaces;
using ProfTests.Models;
using ProfTests.Pages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProfTests.User_controls
{
    public partial class SelectionImagesControl : UserControl, IEvaluation
    {
        public SelectionImagesControl()
        {
            InitializeComponent();
        }

        public TestPageViewModel Model { get; set; }

        private void SetGreen(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var list = (ListView)sender;
                var answer = (AnswerChoice)list.SelectedItem;
                foreach (var item in list.Items.Cast<AnswerChoice>())
                    item.IsSelected = false;
                answer.IsSelected = true;
                Model.SelectedQuestion.Completed = true;
                Model.SelectedMethodic.Completed = !Model.SelectedMethodic.Questions.Any(x => x.Completed != true);
            }
            catch
            {

            }
        }
    }
}
