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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }


        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Для Frame или NavigationWindow
            NavigationService.Navigate(new RequestPassPage());
            e.Handled = true;
        }

        private void HyperLink_RegistrNavigate(object sender, RequestNavigateEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
            e.Handled = true;
        }
    }
}
