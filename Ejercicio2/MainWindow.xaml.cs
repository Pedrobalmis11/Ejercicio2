using System;
using System.Windows;
using System.Windows.Controls;


namespace Ejercicio2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            calcularButton.IsEnabled = false;
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            operadorTextBox.Text = "";
            operando1TextBox.Text = "";
            operando2TextBox.Text = "";
            resultadoTextBox.Text = "";

        }

        private static bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float resultado;
                if (operando1TextBox.Text == "" || operando2TextBox.Text == "")
                {
                    MessageBox.Show("¡No puedes tener campos vacios!", "Error en los campos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (operadorTextBox.Text == "+")
                    {
                        resultado = float.Parse(operando1TextBox.Text) + float.Parse(operando2TextBox.Text);
                        resultadoTextBox.Text = resultado.ToString();

                    }
                    else if (operadorTextBox.Text == "-")
                    {
                        resultado = float.Parse(operando1TextBox.Text) - float.Parse(operando2TextBox.Text);
                        resultadoTextBox.Text = resultado.ToString();

                    }
                    else if (operadorTextBox.Text == "*")
                    {
                        resultado = float.Parse(operando1TextBox.Text) * float.Parse(operando2TextBox.Text);
                        resultadoTextBox.Text = resultado.ToString();
                    }
                    else
                    {
                        if (float.Parse(operando2TextBox.Text) == 0)
                        {
                            MessageBox.Show("¡No es posible dividir entre 0!", "Error en la división", MessageBoxButton.OK, MessageBoxImage.Error);
                            if (float.Parse(operando2TextBox.Text) == 0) operando2TextBox.Text = "";
                        }
                        else
                        {
                            resultado = float.Parse(operando1TextBox.Text) / float.Parse(operando2TextBox.Text);
                            resultadoTextBox.Text = resultado.ToString();
                        }

                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("¡El número introducido no es correcto!", "Error de formato", MessageBoxButton.OK, MessageBoxImage.Error);

                if (!IsNumeric(operando1TextBox.Text)) operando1TextBox.Text = "";
                if (!IsNumeric(operando2TextBox.Text)) operando2TextBox.Text = "";
            }

        }

        private void operadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (operadorTextBox.Text == "+" || operadorTextBox.Text == "-" || operadorTextBox.Text == "/" || operadorTextBox.Text == "*") calcularButton.IsEnabled = true;
            else calcularButton.IsEnabled = false;

        }
    }
}
