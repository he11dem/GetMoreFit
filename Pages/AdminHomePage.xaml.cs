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
    /// Логика взаимодействия для AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Page
    {
        public static List<Trainers> trainers = new List<Trainers>();
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListTrainersPage());
        }
    }
}
