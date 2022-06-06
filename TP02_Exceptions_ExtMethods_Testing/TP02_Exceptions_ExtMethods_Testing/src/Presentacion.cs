using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP02_Exceptions_ExtMethods_Testing.Exceptions;

namespace TP02_Exceptions_ExtMethods_Testing
{
    internal class Presentacion
    {
        public void Init()
        {
            bool success;
            bool exit = false;
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
                            Ejercicio1();
                            break;
                        case "3":
                            Ejercicio3();
                            break;
                        case "4":
                            Ejercicio4();
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    WriteColoredMessage("Excepcion simple atrapada", ConsoleColor.Red);
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
            Console.WriteLine("Opcion 1: Ejercicio 1-2");
            Console.WriteLine("Opcion 3: Ejercicio 3");
            Console.WriteLine("Opcion 4: Ejercicio 4");
            Console.WriteLine("Opcion 0: Salir");
        }

        public void Ejercicio1()
        {
            double num1, num2, result;

            Console.WriteLine("Operacion: Dividir");
            Console.WriteLine("Ingresar dividendo");
            num1 = Logic.ParseUserInput(Console.ReadLine());
            Console.WriteLine("Ingresar divisor");
            num2 = Logic.ParseUserInput(Console.ReadLine());

            result = Logic.Divide(num1, num2);
            WriteColoredMessage("Resultado: " + result, ConsoleColor.DarkGreen);
        }

        public void Ejercicio3()
        {
            Console.WriteLine("Este metodo dispara una excepcion simple");
            Console.WriteLine("Presione una tecla para lanzar la excepcion");
            Console.ReadKey();
            Logic.ThrowException();
        }

        public void Ejercicio4()
        {
            double num1, result;
            Console.WriteLine("Operacion: Raiz cuadrada");
            Console.WriteLine("(Puede ingresar un numero negativo para disparar una excepcion personalizada)");
            Console.WriteLine("Ingresar radicando");
            num1 = Logic.ParseUserInput(Console.ReadLine());

            result = Logic.SquareRoot(num1);
            WriteColoredMessage($"Resultado: (+/-) {result}", ConsoleColor.DarkGreen);
        }

        public void WriteColoredMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}