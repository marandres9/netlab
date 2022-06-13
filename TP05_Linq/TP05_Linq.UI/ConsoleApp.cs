using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05Linq.Common;
using TP05Linq.Logic;

namespace TP05Linq.UI
{
    public class ConsoleApp
    {
        public void Init()
        {
            var customerLogic = new CustomersLogic();
            var productLogic = new ProductsLogic();
            var orderLogic = new OrdersLogic();
            bool exit = false;

            while(!exit)
            {
                WriteColoredMessage("Ingrese un ejercicio (1-13), u otra cosa para salir", ConsoleColor.DarkCyan);
                var option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        ShowAssignment(1);
                        var customer = customerLogic.GetFirst();
                        WriteColoredMessage("[CustomerID] - [ContactName] - [Region]", ConsoleColor.DarkYellow);
                        Console.WriteLine($"{customer.CustomerID} - {customer.ContactName} - {customer.Region}");
                        break;
                    case "2":
                        ShowAssignment(2);
                        WriteColoredMessage("[ProductName] - [UnitsInStock]", ConsoleColor.DarkYellow);
                        foreach(var item in productLogic.GetWithoutStock())
                        {
                            Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
                        }
                        break;
                    case "3":
                        ShowAssignment(3);
                        WriteColoredMessage("[ProductName] - [UnitsInStock] - [UnitPrice]", ConsoleColor.DarkYellow);
                        foreach(var item in productLogic.GetInStockWorthMoreThan(3))
                        {
                            Console.WriteLine($"{item.ProductName} - {item.UnitsInStock} - {item.UnitPrice}");
                        }
                        break;
                    case "4":
                        ShowAssignment(4);
                        WriteColoredMessage("[ProductName] - [UnitsInStock] - [UnitPrice]", ConsoleColor.DarkYellow);
                        foreach(var item in customerLogic.GetFromRegion("WA"))
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
                        }
                        break;
                    case "5":
                        ShowAssignment(5);
                        int id = 789;
                        var product = productLogic.GetFirstOrDefaultByID(id);
                        if(product != null)
                        {
                            WriteColoredMessage("[ProductID] - [ProductName] - [UnitsInStock]", ConsoleColor.DarkYellow);
                            Console.WriteLine($"{product.ProductID} - {product.ProductName} - {product.UnitsInStock}");
                        }
                        else
                        {
                            Console.WriteLine($"Product with ID {id} not found. (Got null)");
                        }
                        break;
                    case "6":
                        ShowAssignment(6);
                        foreach(var item in customerLogic.GetCustomerNames())
                        {
                            Console.WriteLine($"{item.ToUpper()} - {item.ToLower()}");
                        }
                        break;
                    case "7":
                        ShowAssignment(7);
                        var customer_orders = customerLogic.GetOrdersFromRegionNewerThan("WA", new DateTime(1997, 1, 1));
                        // se ordena la lista por nombres
                        WriteColoredMessage("[ContactName] - [Region] - [OrderDate]", ConsoleColor.DarkYellow);
                        foreach(var item in customer_orders.OrderBy(e => e.ContactName))
                        {
                            Console.WriteLine($"{item.ContactName} - {item.Region} - {item.OrderDate}");
                        }
                        break;
                    case "8":
                        ShowAssignment(8);
                        WriteColoredMessage("[CustomerID] - [ContactName] - [Region]", ConsoleColor.DarkYellow);
                        foreach(var item in customerLogic.GetTopThreeFromRegion("WA"))
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
                        }
                        break;
                    case "9":
                        ShowAssignment(9);
                        WriteColoredMessage("[ProductID] - [ProductName]", ConsoleColor.DarkYellow);
                        foreach(var item in productLogic.GetSortByName())
                        {
                            Console.WriteLine($"{item.ProductID} - {item.ProductName}");
                        }
                        break;
                    case "10":
                        ShowAssignment(10);
                        WriteColoredMessage("[ProductName] - [UnitsInStock]", ConsoleColor.DarkYellow);
                        foreach(var item in productLogic.GetSortByUnitsInStock())
                        {
                            Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
                        }
                        break;
                    case "11":
                        ShowAssignment(11);
                        WriteColoredMessage("[ProductName] - [CategoryName]", ConsoleColor.DarkYellow);
                        foreach(var item in productLogic.GetWithCategories())
                        {
                            if(item.CategoryName != null)
                                Console.WriteLine($"{item.ProductName} - {item.CategoryName}");
                            else
                                Console.WriteLine($"{item.ProductName} - (null)");
                        }
                        break;
                    case "12":
                        ShowAssignment(12);
                        // Usa el metodo de extension GetFirst() de la clase List<T>
                        // Pide una lista cualquiera y se llama al metodo de extension
                        var prod = productLogic.GetSortByUnitsInStock().GetFirst();
                        Console.WriteLine("Primer item de la lista del ej. 10:");
                        WriteColoredMessage("[ProductID] - [ProductName] - [UnitsInStock]", ConsoleColor.DarkYellow);
                        Console.WriteLine($"{prod.ProductID} - {prod.ProductName} - {prod.UnitsInStock}");
                        break;
                    case "13":
                        ShowAssignment(13);
                        WriteColoredMessage("[ContactName] - [Orders]", ConsoleColor.DarkYellow);
                        foreach(var item in customerLogic.GetAll())
                        {
                            Console.WriteLine($"{item.ContactName} - {orderLogic.GetCustomerOrders(item)}");
                        }
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
        }
        public void WriteColoredMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void ShowAssignment(int num)
        {
            switch(num)
            {
                case 1:
                    WriteColoredMessage("Query para devolver objeto customer", ConsoleColor.Yellow);
                    break;
                case 2:
                    WriteColoredMessage("Query para devolver todos los productos sin stock", ConsoleColor.Yellow);
                    break;
                case 3:
                    WriteColoredMessage("Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad", ConsoleColor.Yellow);
                    break;
                case 4:
                    WriteColoredMessage("Query para devolver todos los customers de la Región WA", ConsoleColor.Yellow);
                    break;
                case 5:
                    WriteColoredMessage("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789", ConsoleColor.Yellow);
                    break;
                case 6:
                    WriteColoredMessage("Query para devolver los nombre de los Customers.Mostrarlos en Mayuscula y en Minuscula.", ConsoleColor.Yellow);
                    break;
                case 7:
                    WriteColoredMessage("Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.", ConsoleColor.Yellow);
                    break;
                case 8:
                    WriteColoredMessage("Query para devolver los primeros 3 Customers de la Región WA", ConsoleColor.Yellow);
                    break;
                case 9:
                    WriteColoredMessage("Query para devolver lista de productos ordenados por nombre", ConsoleColor.Yellow);
                    break;
                case 10:
                    WriteColoredMessage("Query para devolver lista de productos ordenados por unit in stock de mayor a menor.", ConsoleColor.Yellow);
                    break;
                case 11:
                    WriteColoredMessage("Query para devolver las distintas categorías asociadas a los productos", ConsoleColor.Yellow);
                    break;
                case 12:
                    WriteColoredMessage("Query para devolver el primer elemento de una lista de productos", ConsoleColor.Yellow);
                    break;
                case 13:
                    WriteColoredMessage("Query para devolver los customer con la cantidad de ordenes asociadas", ConsoleColor.Yellow);
                    break;
                default:
                    break;
            }

        }
    }
}
