using ProfTests.Models;
using ProfTests.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        LoginPageViewModel Model;
        public LoginPage()
        {
            InitializeComponent();
            DataContext = Model = new LoginPageViewModel();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Model.User.Name) && !String.IsNullOrEmpty(Model.User.SecondName))
            {
                NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Проверьте корректность введённых данных");
            }
        }
    }

    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            StaticParameters.User = User;
        }
        public User User { get; set; } = new User();
    }
}
