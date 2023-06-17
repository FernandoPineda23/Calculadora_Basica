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
            if (!String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text += value;
            }
        }



    }

}
