using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GetMoreFit.Classes
{
    public class MessageClass
    {
        public static void InformationMessage(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static MessageBoxResult QuestionMessage(string text)
        {
            return MessageBox.Show(text, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
        public static void WarningMessage(string text)
        {
            MessageBox.Show(text, "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static void ErrorMessage(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
