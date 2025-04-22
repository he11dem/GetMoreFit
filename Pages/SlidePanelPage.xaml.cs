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
        
        public SlidePanelPage()
        {
            InitializeComponent();

        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NewFrame.Navigate(new AdminPage());
        }
    }
}
