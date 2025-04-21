using GetMoreFit.Model;
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
    /// Логика взаимодействия для TestTestPage.xaml
    /// </summary>
    public partial class TestTestPage : Page
    {
        public static List<Product> products { get; set; }
        public TestTestPage()
        {
            InitializeComponent();

            products = new List<Product>(DBConnection.lopushEntities.Product.ToList());



            TaskUserLV.ItemsSource = new List<Product>(DBConnection.lopushEntities.Product.ToList());
            this.DataContext = this;
        }
    }
}
