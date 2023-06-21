using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace Calculadora_Basica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;

                string value = (string)button.Content;

                if (Isnumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperator(value);
                }
                else if (value=="CE")
                {
                    Screen.Clear();
                }
                else if (value=="=")
                {
                    HandleEquals(Screen.Text);
                }
                else if (value=="C")
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length-1);
                }


            }
            catch (Exception ex)
            {

                throw new Exception ("Sucedio un error "+ex.Message);
            }
        }


        //Metodos auxiliares

        private bool Isnumber(string number)
        {
            return double.TryParse(number, out _);
        }

        private void HandleNumbers(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text=value;
            }
            else
            {
                Screen.Text += value;
            }

        }

        private bool IsOperator(string posibleOperator)
        {
            //PRIMERA FORMA
           /* if (posibleOperator == "+" || posibleOperator == "-"
                || posibleOperator == "*" || posibleOperator == "/")
            {
                return true;
            }
            return false;*/

            //SEGUNDA FORMA
            return posibleOperator == "+" || posibleOperator == "-"
                || posibleOperator == "*" || posibleOperator == "/";


        }

        private void HandleOperator(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text)&& !ContainsOtherOperator(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        private bool ContainsOtherOperator(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-")
                || screenContent.Contains("*") || screenContent.Contains("/");
        }

        private void HandleEquals(string screenContent)
        {

            string op = FindOperator(screenContent);
            if(!String.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;

                    case "-": Screen.Text = Res();
                        break;

                    case "*": Screen.Text = Mul();
                        break;

                    case "/": Screen.Text = Div();
                        break;

                    default:
                        break;
                }
            }
        }

        private string FindOperator(string screenContent)
        {
            foreach (var c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return " ";
        }

        private string Sum()
        {
            string[] number = Screen.Text.Split('+');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1+n2, 12).ToString();

        }

        private string Res()
        {
            string[] number= Screen.Text.Split("-");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1],out double n2);

            return Math.Round(n1-n2, 12).ToString();
        }

        private string Mul()
        {
            string[] number = Screen.Text.Split("*");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }

        private string Div()
        {
            string[] number = Screen.Text.Split("/");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }


    }

}
