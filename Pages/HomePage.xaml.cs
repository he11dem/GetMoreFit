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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetMoreFit.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private List<string> imagePaths = new List<string>()
        {
    "pack://application:,,,/Resources/Images/strong_girl.jpg",
    "pack://application:,,,/Resources/Images/strong_woman.jpg",
    "pack://application:,,,/Resources/Images/forcar.jpg"
        };
        private int currentIndex = 0;
        private Point touchStart;
        private bool isDragging = false;
        private const double SwipeThreshold = 50;

        public HomePage()
        {
            InitializeComponent();
            Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateImage();
            CreateIndicators();

            // Обработчики событий
            SwipeContainer.TouchDown += OnTouchDown;
            SwipeContainer.TouchMove += OnTouchMove;
            SwipeContainer.TouchUp += OnTouchUp;

            SwipeContainer.MouseDown += OnMouseDown;
            SwipeContainer.MouseMove += OnMouseMove;
            SwipeContainer.MouseUp += OnMouseUp;

            // Инициализация трансформации
            ImageBorder.RenderTransform = new TranslateTransform();
        }

        private void UpdateImage()
        {
            try
            {
                var uri = new Uri(imagePaths[currentIndex], UriKind.Absolute);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = uri;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                MainImageBrush.ImageSource = bitmap;
                UpdateIndicators();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");

                // Альтернативный вариант - загрузка из встроенных ресурсов
                try
                {
                    var uri = new Uri("pack://application:,,,/Resources/Images/default_image.jpg", UriKind.Absolute);
                    MainImageBrush.ImageSource = new BitmapImage(uri);
                }
                catch
                {
                    // Если и это не сработает, установим просто цвет фона
                    MainImageBrush.ImageSource = null;
                    ImageBorder.Background = Brushes.LightGray;
                }
            }
        }
        private void CreateIndicators()
        {
            IndicatorsPanel.Children.Clear();
            for (int i = 0; i < imagePaths.Count; i++)
            {
                var ellipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Margin = new Thickness(5),
                    Fill = i == currentIndex ? Brushes.White : Brushes.Gray,
                    Opacity = 0.7
                };
                IndicatorsPanel.Children.Add(ellipse);
            }
        }

        private void UpdateIndicators()
        {
            for (int i = 0; i < IndicatorsPanel.Children.Count; i++)
            {
                if (IndicatorsPanel.Children[i] is Ellipse ellipse)
                {
                    ellipse.Fill = i == currentIndex ? Brushes.White : Brushes.Gray;
                }
            }
        }

        private void OnTouchDown(object sender, TouchEventArgs e)
        {
            touchStart = e.GetTouchPoint(SwipeContainer).Position;
            isDragging = true;
            e.Handled = true;
        }

        private void OnTouchMove(object sender, TouchEventArgs e)
        {
            if (!isDragging) return;

            var currentPos = e.GetTouchPoint(SwipeContainer).Position;
            var offsetX = currentPos.X - touchStart.X;

            ImageBorder.RenderTransform = new TranslateTransform(offsetX, 0);
            e.Handled = true;
        }

        private void OnTouchUp(object sender, TouchEventArgs e)
        {
            if (!isDragging) return;

            var endPos = e.GetTouchPoint(SwipeContainer).Position;
            var offsetX = endPos.X - touchStart.X;
            ProcessSwipe(offsetX);
            isDragging = false;
            e.Handled = true;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            touchStart = e.GetPosition(SwipeContainer);
            isDragging = true;
            e.Handled = true;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;

            var currentPos = e.GetPosition(SwipeContainer);
            var offsetX = currentPos.X - touchStart.X;

            ImageBorder.RenderTransform = new TranslateTransform(offsetX, 0);
            e.Handled = true;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!isDragging || e.ChangedButton != MouseButton.Left) return;

            var endPos = e.GetPosition(SwipeContainer);
            var offsetX = endPos.X - touchStart.X;
            ProcessSwipe(offsetX);
            isDragging = false;
            e.Handled = true;
        }

        private void ProcessSwipe(double offsetX)
        {
            if (Math.Abs(offsetX) > SwipeThreshold)
            {
                if (offsetX > 0 && currentIndex > 0)
                {
                    AnimateSwipe(1, () => { currentIndex--; UpdateImage(); });
                }
                else if (offsetX < 0 && currentIndex < imagePaths.Count - 1)
                {
                    AnimateSwipe(-1, () => { currentIndex++; UpdateImage(); });
                }
                else
                {
                    AnimateReturn();
                }
            }
            else
            {
                AnimateReturn();
            }
        }

        private void AnimateSwipe(int direction, Action onCompleted)
        {
            var animation = new DoubleAnimation
            {
                To = direction * SwipeContainer.ActualWidth,
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            animation.Completed += (s, e) =>
            {
                ImageBorder.RenderTransform = new TranslateTransform(0, 0);
                onCompleted?.Invoke();
            };

            ImageBorder.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        private void AnimateReturn()
        {
            var animation = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            ImageBorder.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        private void TrainerLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void AdminLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private void MinumazeBtn_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.WindowState = WindowState.Minimized;
        }
    }
}
