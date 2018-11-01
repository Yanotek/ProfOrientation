using ProfTests.Models;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void FirstMethodClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(new List<Methodic>
            {
                Data.Input.PrimaryMethodic(),
                Data.Input.PrimaryMethodicSecond()
            }, Enums.TestType.Choices));
        }

        private void SecondMethodClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(new List<Methodic>
            {
                Data.Input.SecondarySchool()
            }, Enums.TestType.Compare));
        }

        private void ThirtMethodClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(new List<Methodic>
            {
                Data.Input.HighSchool()
            }, Enums.TestType.Scale));
        }
    }
}
