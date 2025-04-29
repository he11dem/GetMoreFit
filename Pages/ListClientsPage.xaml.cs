using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using GetMoreFit.Model.DB;

namespace GetMoreFit.Pages
{
    public class PlaceholderTextRule : ValidationRule
    {
      
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return ValidationResult.ValidResult;
        }
    }
    public partial class ListClientsPage : Page
    {
        public static List<Clients> clients { get; set; }
        private bool isUserText = false;
        public ListClientsPage()
        {
            InitializeComponent();
            ClientsLV.ItemsSource = new List<Clients>(DBConnection.fitness.Clients.ToList());
            this.DataContext = this;
        }

        
        private void SearchClientTbx_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchClientTbx.Text))
            {
                SearchClientTbx.Text = "Найти клиента...";
                SearchClientTbx.Foreground = Brushes.Gray;
            }
            else
            {
                SearchClientTbx.Foreground = Brushes.Black;
                isUserText = true;
            }
        }
        private void SearchClientTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearPlaceholder();
        }

        private void SearchClientTbx_LostFocus(object sender, RoutedEventArgs e)
        {
            RestorePlaceholderIfEmpty();
        }

        private void SearchClientTbx_MouseEnter(object sender, MouseEventArgs e)
        {
            ClearPlaceholder();
        }

        private void SearchClientTbx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!SearchClientTbx.IsKeyboardFocused)
            {
                RestorePlaceholderIfEmpty();
            }
        }

        private void SearchClientTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            isUserText = !string.IsNullOrWhiteSpace(SearchClientTbx.Text) &&
                        SearchClientTbx.Text != "Найти клиента...";
        }

        private void ClearPlaceholder()
        {
            if (!isUserText && SearchClientTbx.Text == "Найти клиента...")
            {
                SearchClientTbx.Text = "";
                SearchClientTbx.Foreground = Brushes.Black;
            }
        }

        private void RestorePlaceholderIfEmpty()
        {
            if (!isUserText && string.IsNullOrWhiteSpace(SearchClientTbx.Text))
            {
                SearchClientTbx.Text = "Найти клиента...";
                SearchClientTbx.Foreground = Brushes.Gray;
            }
        }

        private void ClientsLV_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                // Анимация масштаба
                var scale = new ScaleTransform(0.98, 0.98);
                border.RenderTransform = scale;
            }
        }

        private void ClientsLV_Unselected(object sender, RoutedEventArgs e)
        {
            if (sender is Border border)
            {
                // Возврат к исходному масштабу
                var scale = new ScaleTransform(1, 1);
                border.RenderTransform = scale;
            }
        }

        private void AddNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewClientPage());
        }

        private void ClientsLV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ClientsLV.SelectedItem is Clients clients)
            {
                clients = ClientsLV.SelectedItem as Clients;
                NavigationService.Navigate(new EditClientPage(clients));
            }
        }
    }
}
