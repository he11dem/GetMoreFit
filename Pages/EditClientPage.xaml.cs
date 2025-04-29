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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        public EditClientPage(Clients clients)
        {
            InitializeComponent();
        }

        private void LoadImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                    Title = "Выберите изображение"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                        LoadImage.Source = bitmap;

                        // Скрываем плейсхолдер
                        Placeholder.Visibility = Visibility.Collapsed;

                        LoadImage.Clip = new EllipseGeometry(new Point(100, 100), 100, 100);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                        "Ошибка",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
