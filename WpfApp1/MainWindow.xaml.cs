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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTimeOfDay_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtHours.Text, out int h) ||
                !int.TryParse(txtMinutes.Text, out int m))
            {
                lblTimeResult.Text = "Ошибка: введите целые числа.";
                return;
            }

            if (h < 0 || h > 23 || m < 0 || m > 59)
            {
                lblTimeResult.Text = "Ошибка: часы 0–23, минуты 0–59.";
                return;
            }

            string part;
            if (h >= 6 && h <= 11) part = "Доброе утро";
            else if (h >= 12 && h <= 17) part = "Добрый день";
            else if (h >= 18 && h <= 22) part = "Добрый вечер";
            else part = "Доброй ночи";

            string minutesInfo = m == 0 ? "" : $" ({m} мин.)";
            lblTimeResult.Text = $"{part}{minutesInfo}";
        }
        private void BtnDayOfWeek_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtDay.Text, out int d) || d < 1 || d > 7)
            {
                lblDayResult.Text = "Ошибка: введите число от 1 до 7.";
                return;
            }

            switch (txtDay.Text)
            {
                case "1":
                    lblDayResult.Text = ("Понедельник");
                    break;
                case "2":
                    lblDayResult.Text = ("вторник");
                    break;
                case "3":
                    lblDayResult.Text = ("среда");
                    break;
                case "4":
                    lblDayResult.Text = ("четверг");
                    break;
                case "5":
                    lblDayResult.Text = ("пятница");
                    break;
                case "6":
                    lblDayResult.Text = ("суббота");
                    break;
                case "7":
                    lblDayResult.Text = ("воскресенье");
                    break;
                case "8":
                    lblDayResult.Text = ("нету такого");
                    break;

            };

            string type = (d <= 5) ? "рабочий день" : "выходной";
            lblDayResult.Text = $"{txtDay} — {type}";
        }
        private void BtnTriangle_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtC.Text, out double c) ||
                a <= 0 || b <= 0 || c <= 0)
            {
                lblTriangleResult.Text = "Ошибка: введите положительные числа.";
                return;
            }

            if (!(a + b > c && a + c > b && b + c > a))
            {
                lblTriangleResult.Text = "Треугольник не существует.";
                return;
            }

            string type;
            if (Math.Abs(a - b) < 1e-6 && Math.Abs(b - c) < 1e-6)
                type = "равносторонний";
            else if (Math.Abs(a - b) < 1e-6 || Math.Abs(a - c) < 1e-6 || Math.Abs(b - c) < 1e-6)
                type = "равнобедренный";
            else
                type = "разносторонний";

            // Проверка на прямоугольный
            double[] s = { a, b, c };
            Array.Sort(s); // s[0] <= s[1] <= s[2]
            bool isRight = Math.Abs(s[0] * s[0] + s[1] * s[1] - s[2] * s[2]) < 1e-6;

            lblTriangleResult.Text = $"Треугольник {type}" +
                                     (isRight ? ", прямоугольный." : ".");
        }

        private void BtnScore_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtScore.Text, out int score))
            {
                lblScoreResult.Text = "Ошибка: введите целое число.";
                return;
            }

            if (score < 0 || score > 100)
            {
                lblScoreResult.Text = "Ошибка: баллы должны быть в диапазоне 0–100.";
            }
            else if (score >= 90)
            {
                lblScoreResult.Text = "Отлично (5)";
            }
            else if (score >= 75)
            {
                lblScoreResult.Text = "Хорошо (4)";
            }
            else if (score >= 60)
            {
                lblScoreResult.Text = "Удовлетворительно (3)";
            }
            else
            {
                lblScoreResult.Text = "Неудовлетворительно (2)";
            }
        }
    }
}


