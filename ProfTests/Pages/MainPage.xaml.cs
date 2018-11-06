using ProfTests.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            }));
        }

        private void SecondMethodClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(new List<Methodic>
            {
                Data.Input.SecondarySchool()
            }));
        }

        private void ThirtMethodClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(new List<Methodic>
            {
                Data.Input.HighSchool(),
                Data.Input.HighSchoolSecond()
            }));
        }
    }
}
