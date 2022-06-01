using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP02_Exceptions_ExtMethods_Testing.Exceptions;

namespace TP02_Exceptions_ExtMethods_Testing
{
    public class CalculatorConsoleApp
    {
        public void Init()
        {
            var calc = new Calculator();
            bool exit = false;
            bool success;

            double num1, num2, result;

            string option;

            while(!exit)
            {
                success = false;

                ShowMessages();
                option = Console.ReadLine();
                try
                {
                    switch(option)
                    {
                        case "1":
                            Console.WriteLine("Operacion: Dividir");
                            Console.WriteLine("Ingresar dividendo");
                            num1 = calc.ParseUserInput(Console.ReadLine());
                            Console.WriteLine("Ingresar divisor");
                            num2 = calc.ParseUserInput(Console.ReadLine());

                            result = calc.Divide(num1, num2);
                            WriteColoredMessage("Resultado: " + result, ConsoleColor.DarkGreen);
                            break;
                        case "2":
                            Console.WriteLine("Operacion: Raiz cuadrada");
                            Console.WriteLine("Ingresar radicando");
                            num1 = calc.ParseUserInput(Console.ReadLine());

                            result = calc.SquareRoot(num1);
                            WriteColoredMessage($"Resultado: (+/-) {result}", ConsoleColor.DarkGreen);
                            break;
                        case "0":
                            exit = true;
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            WriteColoredMessage("No es una opcion valida", ConsoleColor.Red);
                            break;
                    }
                    success = true;
                }
                catch(InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                    WriteColoredMessage("Excepcion atrapada: Entrada invalida", ConsoleColor.Red);
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    WriteColoredMessage("Excepcion atrapada: Intento dividir por cero", ConsoleColor.Red);
                }
                catch(NegataiveRadicandException ex)
                {
                    Console.WriteLine(ex.Message);
                    WriteColoredMessage("Excepcion atrapada: Intento sacar raiz par de un numero negativo", ConsoleColor.Red);
                }
                finally
                {
                    if(success)
                    {
                        WriteColoredMessage("Operacion exitosa\n", ConsoleColor.DarkYellow);
                    }
                    else
                    {
                        WriteColoredMessage("Operacion fallida\n", ConsoleColor.DarkYellow);

                    }
                }
            }
        }

        public void ShowMessages()
        {
            Console.WriteLine("Opcion 1: Dividir");
            Console.WriteLine("Opcion 2: Raiz cuadrada");
            Console.WriteLine("Opcion 0: Salir");
        }

        public void WriteColoredMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
