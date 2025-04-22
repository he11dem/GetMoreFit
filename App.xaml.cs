using GetMoreFit.Classes;
using GetMoreFit.Model.DB;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GetMoreFit
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static FitnessGetMoreFitEntities db = new FitnessGetMoreFitEntities();
        public static User currentUser = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Настройка основной темы
            var paletteHelper = new PaletteHelper();
            var baseTheme = BaseTheme.Light; var primaryColor = (Color)FindResource("PrimaryHueMid");
            var secondaryColor = (Color)FindResource("SecondaryAccentMid");
            // Создание и применение темы
            var theme = Theme.Create(baseTheme, primaryColor, secondaryColor);
            paletteHelper.SetTheme(theme);
            // Установка других кистей (например, фона)
            Application.Current.Resources["MaterialDesignPaper"] = FindResource("BackgroundPrimaryBrush");
            Application.Current.Resources["MaterialDesignDivider"] = FindResource("BorderColorBrush");
        }

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageClass.ErrorMessage(e.Exception.Message);
        }



    }


    
}
