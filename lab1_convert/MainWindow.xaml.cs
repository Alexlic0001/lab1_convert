using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1_convert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Устанавливаем первый элемент по умолчанию
            ConversionTypeComboBox.SelectedIndex = 0;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            double inputValue;
            if (!double.TryParse(InputTextBox.Text.Replace('.', ','), out inputValue))
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedConversion = ((ComboBoxItem)ConversionTypeComboBox.SelectedItem).Content.ToString();
            double result = 0;

            switch (selectedConversion)
            {
                case "Килограммы в фунты":
                    result = KilogramsToPounds(inputValue);
                    break;
                case "Граммы в унции":
                    result = GramsToOunces(inputValue);
                    break;
                case "Тонны в килограммы":
                    result = TonsToKilograms(inputValue);
                    break;
                case "Пуд в килограммы":
                    result = PudToKilograms(inputValue);
                    break;
                case "Граммы в карат":
                    result = GramsToKarat(inputValue);
                    break;
                default:
                    MessageBox.Show("Не выбран тип конвертации.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            ResultTextBox.Text = result.ToString("F4");
        }

        private void ConversionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Можно добавить обработку при смене типа конвертации
        }
        private double KilogramsToPounds(double kg)
        {
            return kg * 2.20462;
        }

        private double GramsToOunces(double g)
        {
            return g * 0.035274;
        }

        private double TonsToKilograms(double tons)
        {
            return tons * 1000;
        }

        private double PudToKilograms(double kg)
        {
            return kg * 16.3807;
        }

        private double GramsToKarat(double g)
        {
            return g * 5;
        }
        //
    }
}