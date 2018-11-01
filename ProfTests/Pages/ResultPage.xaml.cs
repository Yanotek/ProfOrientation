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
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(List<Methodic> methodics)
        {
            InitializeComponent();
            DataContext = Model = new ResultPageViewModel(methodics.SelectMany(x=> x.TestResult).ToList());
        }

        ResultPageViewModel Model;
    }

    public class ResultPageViewModel : BaseViewModel
    {
        public ResultPageViewModel(List<TestResult> results)
        {
            Results = results;
        }

        public List<TestResult> Results { get; set; }
    }
}
