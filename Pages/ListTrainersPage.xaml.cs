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
using GetMoreFit.Model.DB;

namespace GetMoreFit.Pages
{
    
    public partial class ListTrainersPage : Page
    {
        public static List<Trainers> trainers { get; set; }
        private bool isUserText = false;
        public ListTrainersPage()
        {
            InitializeComponent();
            TrainersLV.ItemsSource = new List<Trainers>(DBConnection.fitness.Trainers.ToList());
            this.DataContext = this;

        }
        private void SearchTrainersTbx_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTrainersTbx.Text))
            {
                SearchTrainersTbx.Text = "Найти клиента...";
                SearchTrainersTbx.Foreground = Brushes.Gray;
            }
            else
            {
                SearchTrainersTbx.Foreground = Brushes.Black;
                isUserText = true;
            }
        }
        private void SearchTrainersTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearPlaceholder();
        }

        private void SearchTrainersTbx_LostFocus(object sender, RoutedEventArgs e)
        {
            RestorePlaceholderIfEmpty();
        }

        private void SearchTrainersTbx_MouseEnter(object sender, MouseEventArgs e)
        {
            ClearPlaceholder();
        }

        private void SearchTrainersTbx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!SearchTrainersTbx.IsKeyboardFocused)
            {
                RestorePlaceholderIfEmpty();
            }
        }

        private void SearchTrainersTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            isUserText = !string.IsNullOrWhiteSpace(SearchTrainersTbx.Text) &&
                        SearchTrainersTbx.Text != "Найти клиента...";
        }

        private void ClearPlaceholder()
        {
            if (!isUserText && SearchTrainersTbx.Text == "Найти клиента...")
            {
                SearchTrainersTbx.Text = "";
                SearchTrainersTbx.Foreground = Brushes.Black;
            }
        }

        private void RestorePlaceholderIfEmpty()
        {
            if (!isUserText && string.IsNullOrWhiteSpace(SearchTrainersTbx.Text))
            {
                SearchTrainersTbx.Text = "Найти клиента...";
                SearchTrainersTbx.Foreground = Brushes.Gray;
            }
        }
        private void TrainersLV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TrainersLV.SelectedItem is Trainers trainers)
            {
                trainers = TrainersLV.SelectedItem as Trainers;
                NavigationService.Navigate(new EditClientPage(trainers));
            }
        }
    }
}
