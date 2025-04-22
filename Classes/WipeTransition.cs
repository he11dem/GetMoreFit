using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace GetMoreFit
{

    public interface IPageTransition
    {
        void AnimateTransition(ContentPresenter presenter, object oldContent, object newContent);
    }


    public class WipeTransition : IPageTransition
    {
        public Duration Duration { get; set; }
        public SlideDirection Direction { get; set; }

        public enum SlideDirection
        {
            LeftToRight,
            RightToLeft,
            TopToBottom,
            BottomToTop
        }

        public WipeTransition()
        {
            Duration = new Duration(TimeSpan.FromSeconds(0.3));
            Direction = SlideDirection.LeftToRight;
        }

        public void AnimateTransition(ContentPresenter presenter, object oldContent, object newContent)
        {
            // Создаем сетку для анимации
            var grid = new Grid();
            grid.Background = Brushes.Transparent;

            if (oldContent != null)
            {
                var oldElement = (UIElement)oldContent;
                grid.Children.Add(oldElement);
            }

            var newElement = (UIElement)newContent;
            newElement.Opacity = 0;
            grid.Children.Add(newElement);

            // Заменяем содержимое
            presenter.Content = grid;

            // Создаем анимацию
            var translate = new TranslateTransform();
            switch (Direction)
            {
                case SlideDirection.LeftToRight:
                    translate.X = -presenter.ActualWidth;
                    break;
                case SlideDirection.RightToLeft:
                    translate.X = presenter.ActualWidth;
                    break;
                case SlideDirection.TopToBottom:
                    translate.Y = -presenter.ActualHeight;
                    break;
                case SlideDirection.BottomToTop:
                    translate.Y = presenter.ActualHeight;
                    break;
            }

            newElement.RenderTransform = translate;

            // Анимация входа новой страницы
            var animIn = new DoubleAnimation
            {
                Duration = Duration,
                To = 0
            };

            var opacityAnim = new DoubleAnimation
            {
                Duration = Duration,
                From = 0,
                To = 1
            };

            // Анимация выхода старой страницы
            var animOut = new DoubleAnimation
            {
                Duration = Duration,
                To = Direction == SlideDirection.LeftToRight || Direction == SlideDirection.RightToLeft
                    ? presenter.ActualWidth
                    : presenter.ActualHeight
            };

            if (Direction == SlideDirection.RightToLeft || Direction == SlideDirection.BottomToTop)
            {
                animOut.To = -animOut.To;
            }

            // Запускаем анимации
            animIn.Completed += (s, _) =>
            {
                presenter.Content = newContent;
                newElement.Opacity = 1;
                newElement.RenderTransform = null;
            };

            Storyboard.SetTarget(animIn, translate);
            Storyboard.SetTargetProperty(animIn,
                new PropertyPath(Direction == SlideDirection.LeftToRight || Direction == SlideDirection.RightToLeft
                    ? "X"
                    : "Y"));

            Storyboard.SetTarget(opacityAnim, newElement);
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath(UIElement.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(animIn);
            sb.Children.Add(opacityAnim);
            sb.Begin();
        }
    }
}
