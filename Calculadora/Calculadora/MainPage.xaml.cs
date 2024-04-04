using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        string currentInput = string.Empty;
        string operation = string.Empty;
        double firstNumber, secondNumber, result;

        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (pressed == "+" || pressed == "-" || pressed == "x" || pressed == "/")
            {
                operation = pressed;
                firstNumber = Convert.ToDouble(currentInput);
                currentInput = string.Empty;
            }
            else if (pressed == "=")
            {
                if (!string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentInput))
                {
                    secondNumber = Convert.ToDouble(currentInput);
                    switch (operation)
                    {
                        case "+":
                            result = firstNumber + secondNumber;
                            break;
                        case "-":
                            result = firstNumber - secondNumber;
                            break;
                        case "x":
                            result = firstNumber * secondNumber;
                            break;
                        case "/":
                            if (secondNumber != 0) // Validar si el divisor es diferente de cero
                                result = firstNumber / secondNumber;
                            else
                            {
                                // Manejar el error de división por cero
                                DisplayAlert("Error", "No se puede dividir entre cero", "OK");
                                return; // Salir del método para evitar la operación de división
                            }
                            break;
                    }
                    textDisplay.Text = result.ToString();
                    currentInput = result.ToString();
                    operation = string.Empty;
                }
            }
            else if (pressed == "C")
            {
                currentInput = string.Empty;
                operation = string.Empty;
                textDisplay.Text = "0";
            }
            else
            {
                currentInput += pressed;
                textDisplay.Text = currentInput;
            }
        }

        void Button_Clear_Clicked(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            operation = string.Empty;
            textDisplay.Text = "0";
        }
    }
}
