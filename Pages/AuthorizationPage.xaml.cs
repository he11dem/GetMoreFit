using GetMoreFit.Classes;
using GetMoreFit.Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public static class UserInfo {
        public static User User { get; set; }
    }
    public partial class AuthorizationPage : Page
    {
        public static List<User> users = new List<User>();
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


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetValidationStyles();
            bool isValid = true;
            string login = LoginTbx.Text.Trim();
            string password = PasswordPbx.Password.Trim();
            users = new List<User>(DBConnection.fitness.User.ToList());

            if (string.IsNullOrEmpty(LoginTbx.Text))
            {
                ApplyErrorStyle(LoginTbx);
                isValid = false;
            }
            if (string.IsNullOrEmpty(PasswordPbx.Password))
            {
                ApplyErrorStyle(PasswordPbx);
                isValid = false;
            }
            if (!isValid)
            {
                txtError.Text = "Заполните все обязательные поля!";
                return;
            }
            if (password.Length < 3)
            {
                MessageClass.ErrorMessage("Пароль должен содержать минимум 3 символа!");
            }
            User currentUser = users.FirstOrDefault(x => x.UserName == login);
            if (App.currentUser == null)
            {
                UserInfo.User = currentUser;
                NavigationService.Navigate(new SlidePanelPage(currentUser));
                return;
            }
            MessageClass.ErrorMessage("Неверный логин или пароль.");
        }
        private void ApplyErrorStyle(Control control)
        {
            control.BorderBrush = Brushes.Red;
            control.BorderThickness = new Thickness(1);
            control.ToolTip = "Обязательное поле";
        }
        private void ResetValidationStyles()
        {
            LoginTbx.BorderBrush = Brushes.LightGray;
            PasswordPbx.BorderBrush = Brushes.LightGray;
            txtError.Text = "";
        }
    }
}
