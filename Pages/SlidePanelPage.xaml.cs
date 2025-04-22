using GetMoreFit.Model.DB;
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

namespace GetMoreFit.Pages
{
    /// <summary>
    /// Логика взаимодействия для SlidePanelPage.xaml
    /// </summary>
    public partial class SlidePanelPage : Page
    {
        public static User users { get; set; }
        public SlidePanelPage(User user)
        {
            InitializeComponent();
            users = user;


            if (user.IDRole == 1) {
                NewFrame.Navigate(new TrainerHomePage());
            }
            else if(user.IDRole == 3)
            {
                NewFrame.Navigate(new AdminHomePage());
            }
            else
            {
                NewFrame.Navigate(new ModeratorHomePage());
            }




        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DocBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalendarBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TrackerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
