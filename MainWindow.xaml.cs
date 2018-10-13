using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Events_4
{
    /// <summary>
    ///Создайте калькулятор на четыре арифметических действия (сложение, вычитание, умножение и деление). Для реализации калькулятора используйте паттерн MVP. 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        public event EventHandler ButtonEvent = null;
        public event EventHandler ButtonActionEvent = null;

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            ButtonEvent.Invoke(sender, e);
        }

        private void ButtonAction_Click(object sender, RoutedEventArgs e)
        {
            ButtonActionEvent.Invoke(sender, e);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
