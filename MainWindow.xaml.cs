using GetMoreFit.Pages;
using System.Windows;


namespace GetMoreFit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NewFrame.NavigationService.Navigate(new HomePage());
        }
    }
}
