using GetMoreFit.Pages;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Web.UI;


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
            MainFrame.Navigate(new SlidePanelPage());
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        //private async void NavigateWithSlide(Page newpage)
        //{
        //    // Анимация сдвига влево
        //    var slideOut = new DoubleAnimation
        //    {
        //        To = -NewFrame.ActualWidth,
        //        Duration = TimeSpan.FromSeconds(0.3),
        //        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        //    };

        //    FrameTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);

        //    // Ждем завершения анимации
        //    await Task.Delay(300);

        //    // Переход
        //    NewFrame.Navigate(newpage);

        //    // Сброс позиции перед анимацией возврата
        //    FrameTransform.X = NewFrame.ActualWidth;

        //    // Анимация сдвига обратно
        //    var slideIn = new DoubleAnimation
        //    {
        //        To = 0,
        //        Duration = TimeSpan.FromSeconds(0.3),
        //        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        //    };

        //    FrameTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
        //}
    }
}
