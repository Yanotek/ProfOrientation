using ProfTests.Models;
using ProfTests.Other;
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

namespace ProfTests.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage(ICollection<Methodic> methods)
        {
            InitializeComponent();
            DataContext = Model = new TestPageViewModel(methods);
            ListViewItem item = new ListViewItem();
        }

        TestPageViewModel Model;

        private void SetGreen(object sender, RoutedEventArgs e)
        {
            Model.SelectedQuestion.Completed = true;
        }
    }

    public class TestPageViewModel : BaseViewModel
    {
        public TestPageViewModel(ICollection<Methodic> methods)
        {
            Methods = methods;
            SelectedMethodic = Methods.First();
            SelectedQuestion = SelectedMethodic.Questions.First();

            NextCommand = new SimpleCommand((obj) =>
            {
                var index = SelectedMethodic.Questions.FindIndex(x=> x == SelectedQuestion);
                SelectedQuestion = SelectedMethodic.Questions[index + 1];
            },
            (obj) =>
            {
                var index = SelectedMethodic.Questions.FindIndex(x => x == SelectedQuestion);
                if (index + 1 == SelectedMethodic.Questions.Count)
                    return false;
                return true;
            });

            PreviousCommand = new SimpleCommand((obj) =>
            {
                var index = SelectedMethodic.Questions.FindIndex(x => x == SelectedQuestion);
                SelectedQuestion = SelectedMethodic.Questions[index - 1];
            },
            (obj) =>
            {
                var index = SelectedMethodic.Questions.FindIndex(x => x == SelectedQuestion);
                if (index == 0)
                    return false;
                return true;
            });
        }

        public SimpleCommand NextCommand { get; set; }
        public SimpleCommand PreviousCommand { get; set; }

        public ICollection<Methodic> Methods { get; set; }
        public Methodic SelectedMethodic { get; set; }

        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }
    }
}
