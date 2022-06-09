using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Logic;
using TP04_EntityFramework.Entity;
using TP04_EntityFramework.Common.Exceptions;
using TP04_EntityFramework.Common.ExtensionMethods;

namespace TP04_EntityFramework.UI
{
    public class ConsoleApp
    {
        public void Init()
        {
            bool exit = false;
            Table selectedTable;
            Operation selectedOperation;

            while(!exit)
            {
                ShowMenu();
                selectedTable = ParseEnum<Table>(Console.ReadLine());
                if(selectedTable == Table.Exit)
                {
                    exit = true;
                    continue;
                }
                else if(selectedTable == Table.Nothing)
                {
                    WriteColoredMessage("No valid option selected", ConsoleColor.Red);
                    continue;
                }

                ShowSubMenu(selectedTable);
                selectedOperation = ParseEnum<Operation>(Console.ReadLine());
                WriteColoredMessage($"Selected {selectedOperation} on {selectedTable}", ConsoleColor.Yellow);

                try
                {
                    switch(selectedOperation)
                    {
                        case Operation.Add:
                            AddRow(selectedTable);
                            break;
                        case Operation.Delete:
                            DeleteRow(selectedTable);
                            break;
                        case Operation.GetAll:
                            GetAllRows(selectedTable);
                            break;
                        case Operation.Update:
                            UpdateRow(selectedTable);
                            break;
                        default:
                            break;
                    }
                }
                catch(IDNotFoundException e)
                {
                    WriteColoredMessage(e.Message, ConsoleColor.Red);
                }
                catch(IDAlreadyTakenException e)
                {
                    WriteColoredMessage(e.Message, ConsoleColor.Red);
                }
                catch(TriedDeletingReferencedForeignKeyException e)
                {
                    WriteColoredMessage(e.Message, ConsoleColor.Red);
                }
                catch(EntityFailedValidationException e)
                {
                    WriteColoredMessage(e.Message, ConsoleColor.Red);

                }
            }
        }

        public void AddRow(Table table)
        {
            switch(table)
            {
                case Table.Shippers:
                {
                    var shippersLogic = new ShippersLogic();

                    Console.WriteLine("Input new company name (string)");
                    string companyName = Console.ReadLine();
                    Console.WriteLine("Input new phone (string)");
                    string phone = Console.ReadLine();

                    shippersLogic.Add(new Shippers { CompanyName = companyName, Phone = phone });
                    break;
                }
                case Table.Categories:
                {
                    var categoriesLogic = new CategoriesLogic();

                    Console.WriteLine("Input new category name (string)");
                    string categoryName = Console.ReadLine();
                    Console.WriteLine("Input new description (string)");
                    string description = Console.ReadLine();

                    categoriesLogic.Add(new Categories { CategoryName = categoryName, Description = description });
                    WriteColoredMessage("Warning: Image field left as 'null'", ConsoleColor.DarkYellow);
                    break;
                }
                case Table.Terrritories:
                {
                    var logic = new TerritoriesLogic();
                    Console.WriteLine("Input new territory ID (number string)");
                    string territoryID = Console.ReadLine();
                    Console.WriteLine("Input new territory description (string)");
                    string territoryDescription = Console.ReadLine();
                    Console.WriteLine("Input new region ID (int)");
                    string regionID_string = Console.ReadLine();
                    if(!int.TryParse(regionID_string, out int regionID))
                    {
                        WriteColoredMessage("Invalid input for field regionID, operarion canceled", ConsoleColor.Red);
                        return;
                    }
                    logic.Add(new Territories { TerritoryID = territoryID, TerritoryDescription = territoryDescription, RegionID = regionID });
                    break;
                }
                case Table.Region:
                {
                    var logic = new RegionLogic();
                    Console.WriteLine("Input new region ID (int)");
                    string regionID_string = Console.ReadLine();
                    if(!int.TryParse(regionID_string, out int regionID))
                    {
                        Console.WriteLine("Invalid input, operarion canceled");
                        return;
                    }
                    Console.WriteLine("Input new territory description (string)");
                    string regionDescription = Console.ReadLine();

                    logic.Add(new Region { RegionID = regionID, RegionDescription = regionDescription });
                    break;
                }
                default:
                    break;
            }
            WriteColoredMessage($"Added new row to table {table}", ConsoleColor.DarkYellow);
        }

        public void GetAllRows(Table table)
        {
            switch(table)
            {
                case Table.Shippers:
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    foreach(var item in shippersLogic.GetAll())
                    {
                        Console.WriteLine($"{item.ShipperID} - {item.CompanyName} - {item.Phone}");
                    }
                    break;
                }
                case Table.Categories:
                {
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    foreach(var item in categoriesLogic.GetAll())
                    {
                        Console.WriteLine($"{item.CategoryID} - {item.CategoryName} - {item.Description}");
                    }
                    break;
                }
                case Table.Terrritories:
                {
                    var logic = new TerritoriesLogic();
                    foreach(var item in logic.GetAll())
                    {
                        Console.WriteLine($"{item.TerritoryID} - {item.TerritoryDescription} - {item.Region.RegionDescription}");
                    }
                    break;
                }
                case Table.Region:
                {
                    var logic = new RegionLogic();
                    foreach(var item in logic.GetAll())
                    {
                        Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
                    }
                    break;
                }
                default:
                    break;
            }
        }

        public void DeleteRow(Table table)
        {
            Console.WriteLine("Input row ID");
            // id_string se convierte a int (o no) dependiendo de lo que necesite cada tabla
            string id_string = Console.ReadLine();

            switch(table)
            {
                case Table.Shippers:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input, operation canceled");
                        return;
                    }
                    ShippersLogic shipperpsLogic = new ShippersLogic();
                    shipperpsLogic.Delete(id);
                    break;
                }
                case Table.Categories:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input, operation canceled");
                        return;
                    }
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    categoriesLogic.Delete(id);
                    break;
                }
                case Table.Terrritories:
                {
                    var logic = new TerritoriesLogic();
                    logic.Delete(id_string);
                    break;
                }
                case Table.Region:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input, operation canceled");
                        return;
                    }
                    var logic = new RegionLogic();
                    logic.Delete(id);
                    break;
                }
                default:
                    break;
            }
            WriteColoredMessage($"Deleted row {id_string} of table {table}", ConsoleColor.DarkYellow);
        }

        public void UpdateRow(Table table)
        {
            Console.WriteLine("Input row ID");
            string id_string = Console.ReadLine();

            WriteColoredMessage("An empty string keeps the previous values", ConsoleColor.DarkYellow);
            switch(table)
            {
                case Table.Shippers:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input");
                        return;
                    }
                    ShippersLogic shipperpsLogic = new ShippersLogic();

                    Console.WriteLine("Input new company name (string)");
                    string companyName = Console.ReadLine();
                    Console.WriteLine("Input new phone (number string)");
                    string phone = Console.ReadLine();

                    shipperpsLogic.Update(new Shippers { ShipperID = id, CompanyName = companyName, Phone = phone });
                    break;
                }
                case Table.Categories:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input");
                        return;
                    }
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    Console.WriteLine("Input new category name (string)");
                    string categoryName = Console.ReadLine();
                    Console.WriteLine("Input new description (string)");
                    string description = Console.ReadLine();

                    categoriesLogic.Update(new Categories { CategoryID = id, CategoryName = categoryName, Description = description });
                    break;
                }
                case Table.Terrritories:
                {
                    var logic = new TerritoriesLogic();

                    string territoryDescription;
                    Console.WriteLine("Input new TerritoryDescription (string)");
                    territoryDescription = Console.ReadLine();
                    Console.WriteLine("Input new RegionID (int)");
                    // ParseNullableInt() deuvelve null si el usuario ingresa una cadena vacia.
                    // De esta forma regionID se pasa como null y no se modifica en la base de datos.
                    int? regionID = Console.ReadLine().ParseNullableInt();

                    logic.Update(id_string, territoryDescription, regionID);
                    break;
                }
                case Table.Region:
                {
                    if(!int.TryParse(id_string, out int id))
                    {
                        Console.WriteLine("Invalid input");
                        return;
                    }
                    var logic = new RegionLogic();

                    Console.WriteLine("Input new RegionDescription (string)");
                    string regionDescription = Console.ReadLine();

                    logic.Update(new Region { RegionID = id, RegionDescription = regionDescription });
                    break;
                }
                default:
                    break;
            }
            WriteColoredMessage($"Updated row {id_string} of table {table}", ConsoleColor.DarkYellow);
        }

        public T ParseEnum<T>(string input)
        {   
            // si input es valido devuelve el enum para ese valor, sino devuelve el valor por defecto (0) del enum
            int num_input;
            if(int.TryParse(input, out num_input) && Enum.IsDefined(typeof(T), num_input))
            {
                return (T) Enum.Parse(typeof(T), input);
            }
            else
            {
                return default;
            }
        }

        public enum Table
        {
            Shippers = 1, Categories, Terrritories, Region, Nothing = 0, Exit = 9
        }

        public enum Operation
        {
            Add = 1, Delete, GetAll, Update, Nothing = 0
        }

        public void ShowMenu()
        {
            WriteColoredMessage("Select a table from the Northwind DB to query", ConsoleColor.Yellow);
            Console.WriteLine("> 1: Shippers");
            Console.WriteLine("> 2: Categories");
            Console.WriteLine("> 3: Territories");
            Console.WriteLine("> 4: Region");
            Console.WriteLine("> 9: Exit");
        }

        public void ShowSubMenu(Table table)
        {
            WriteColoredMessage($"Select an operation to perform on table: {table}", ConsoleColor.Yellow);
            Console.WriteLine("> 1: Add new row");
            Console.WriteLine("> 2: Delete row");
            Console.WriteLine("> 3: Get all rows");
            Console.WriteLine("> 4: Update row");
            Console.WriteLine("> 0: Nothing");
        }

        public void WriteColoredMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
