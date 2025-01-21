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

namespace _3ISIP_322_PYSHONIN_STEPENKOV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double x, m;
            if (!double.TryParse(xTextBox.Text, out x) || !double.TryParse(mTextBox.Text, out m))
            {
                MessageBox.Show("Введите корректные значения для x и m.");
                return;
            }

            double result = 0;

            if (shRadioButton.IsChecked == true)
            {
                result = Math.Sinh(x); // sh(x) - гиперболический синус
            }
            else if (x2RadioButton.IsChecked == true)
            {
                result = Math.Pow(x, 2); // x^2
            }
            else if (expRadioButton.IsChecked == true)
            {
                result = Math.Exp(x); // e^x
            }

            resultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            xTextBox.Clear();
            mTextBox.Clear();
            resultTextBox.Clear();
            shRadioButton.IsChecked = false;
            x2RadioButton.IsChecked = false;
            expRadioButton.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Отменяем закрытие окна
            }
        }
    }
}
