using GetMoreFit.Classes;
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


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetValidationStyles();
            bool isValid = true;
            string login = LoginTbx.Text.Trim();
            string password = PasswordPbx.Password.Trim();


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

            if (login == "ivanov" && password == "hash1")
            {
                NavigationService.Navigate(new ModeratorPage());
                return;
            }   
            if (login == "sidorov" && password == "hash3")
            {
                NavigationService.Navigate(new AdminPage());
            }
            App.currentTrainer = App.db.Trainers.FirstOrDefault(x => x.Name == login);
            if (App.currentTrainer == null)
            {
                NavigationService.Navigate(new TrainersPage());
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
