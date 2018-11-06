using ProfTests.Enums;
using ProfTests.Interfaces;
using ProfTests.Models;
using ProfTests.Other;
using ProfTests.User_controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProfTests.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage(List<Methodic> Methodics)
        {
            InitializeComponent();
            DataContext = Model = new TestPageViewModel(Methodics, this);
        }

        TestPageViewModel Model;
    }

    public class TestPageViewModel : BaseViewModel
    {
        TestPage Page;

        public TestPageViewModel(List<Methodic> methodics, TestPage page)
        {
            Page = page;
            Methodics = methodics;
            SelectedMethodic = Methodics.First();
            SelectedQuestion = SelectedMethodic.Questions.First();
            RefreshControl(SelectedMethodic.Evaluation);
        }

        public SimpleCommand NextCommand
        {
            get
            {
                return new SimpleCommand((obj) =>
                {
                    var index = SelectedMethodic.Questions.FindIndex(x => x == SelectedQuestion);
                    SelectedQuestion = SelectedMethodic.Questions[index + 1];
                },
                (obj) =>
                {
                    var index = SelectedMethodic.Questions.FindIndex(x => x == SelectedQuestion);
                    if (index + 1 == SelectedMethodic.Questions.Count)
                        return false;
                    return true;
                });
            }
        }

        public SimpleCommand PreviousCommand
        {
            get
            {
                return new SimpleCommand((obj) =>
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
        }

        public SimpleCommand EndCommand
        {
            get
            {
                return new SimpleCommand((obj) =>
                {
                    var index = Methodics.FindIndex(x => x == SelectedMethodic);
                    if (index + 1 == Methodics.Count)
                    {
                        Methodics.ForEach(x => x.CalcResult(x));
                        Page.NavigationService.Navigate(new ResultPage(Methodics));
                    }
                    else
                    {
                        SelectedMethodic = Methodics[index + 1];
                        SelectedQuestion = SelectedMethodic.Questions.First();
                        RefreshControl(SelectedMethodic.Evaluation);
                        ShowInstruction();
                    }
                });
            }
        }

        public SimpleCommand CloseInstruction
        {
            get
            {
                return new SimpleCommand((obj) =>
                {
                    TestVisibility = Visibility.Visible;
                    InstructionVisibility = Visibility.Collapsed;
                });
            }
        }

        public List<Methodic> Methodics { get; set; }

        private Methodic _SelectedMethodic;
        public Methodic SelectedMethodic
        {
            get => _SelectedMethodic;
            set
            {
                _SelectedMethodic = value;
                OnPropertyChanged("SelectedMethodic");

                var index = Methodics.FindIndex(x => x == value);
                if (index + 1 == Methodics.Count)
                    LastMethodic = true;
            }
        }

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

        private bool _LastMethodic = false;
        public bool LastMethodic
        {
            get => _LastMethodic;
            set
            {
                _LastMethodic = value;
                OnPropertyChanged("LastMethodic");
            }
        }

        public void ShowInstruction()
        {
            TestVisibility = Visibility.Collapsed;
            InstructionVisibility = Visibility.Visible;
        }

        public Visibility _InstructionVisibility = Visibility.Visible;
        public Visibility InstructionVisibility
        {
            get => _InstructionVisibility;
            set
            {
                _InstructionVisibility = value;
                OnPropertyChanged("InstructionVisibility");
            }
        }

        public Visibility _TestVisibility = Visibility.Collapsed;
        public Visibility TestVisibility
        {
            get => _TestVisibility;
            set
            {
                _TestVisibility = value;
                OnPropertyChanged("TestVisibility");
            }
        }

        public void RefreshControl(IEvaluation control)
        {
            control.Model = this;
            Page.TestVariant.Children.Clear();
            Page.TestVariant.Children.Add((UserControl)control);
        }
    }
}
