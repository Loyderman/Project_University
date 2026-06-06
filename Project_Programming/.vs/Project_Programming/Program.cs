using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Session session = new Session();
            try
            {
                while (true)
                {
                    string k = string.Empty;
                    if (i == 0)
                    {
                        Console.WriteLine("=================================================================");
                        Console.WriteLine("Hi, it is your port system. Which action do you want to do?");
                        Console.WriteLine("=================================================================");
                    }
                    i++;

                    Console.WriteLine("\n+---------------------------------------------------------------+");
                    Console.WriteLine("| MAIN PORT MENU                                                |");
                    Console.WriteLine("+---------------------------------------------------------------+");
                    Console.WriteLine("| 1. Add Passenger ship                                         |");
                    Console.WriteLine("| 2. Add Cargo ship                                             |");
                    Console.WriteLine("| 3. Change properties in your ship                             |");
                    Console.WriteLine("| 4. Remove ship                                                |");
                    Console.WriteLine("| 5. show information about the ship                            |");
                    Console.WriteLine("| 6. show information about the crew of the ship                |");
                    Console.WriteLine("| 7. Quit                                                       |");
                    Console.WriteLine("+---------------------------------------------------------------+");
                    Console.Write("  Print number of what you want to do: ");
                    k = Console.ReadLine();
                    Console.Clear();
                    if(k == "7")
                    {
                        break;
                    }
                    switch (k)
                    {
                        case "1":
                            {
                                PassengerShip pass = new PassengerShip();
                                Console.WriteLine("\n[Adding Passenger Ship]");
                                Console.WriteLine("  Print with separating by ',' characteristics of your ship:");
                                Console.WriteLine("  name of the ship, name of the port, engine power, displacement,");
                                Console.WriteLine("  number of passengers, number of sits and capacity of sits");
                                Console.Write("  -> ");
                                string character = Console.ReadLine();
                                pass = pass.AddShips(character) as PassengerShip;
                                Console.Clear();
                                Console.WriteLine($"Your ship with individual index: {pass.ShipIndex} was succesfully added to the {pass.NameOfThePort}");


                                break;
                            }
                        case "2":
                            {
                                CargoShip pass1 = new CargoShip();
                                Console.WriteLine("\n[Adding Cargo Ship]");
                                Console.WriteLine("  Print with separating by ',' characteristics of your ship:");
                                Console.WriteLine("  name of the ship, name of the port, engine power, displacement,");
                                Console.WriteLine("  load capacity and current load");
                                Console.Write("  -> ");
                                string character = Console.ReadLine();
                                pass1 =pass1.AddShips(character) as CargoShip;
                                Console.Clear();
                                Console.WriteLine($"Your ship with individual index: {pass1.ShipIndex} was succesfully added to the {pass1.NameOfThePort}");
                                break;
                            }

                        case "3":
                            {
                                session.ChooseShipYouWantToCange();
                                Console.Clear();
                                break;
                            }
                        case "4":
                            {
                                session.InterfaceforRemovingSips();
                                
                                break;
                            }
                        case "5":
                            {
                                Ship pass2 = new PassengerShip();
                                Console.Clear();
                                session.InterfaceOfShowingOfTheShip();


                                break;
                            }
                        case "6":
                            {
                                Console.Clear();
                                session.InterfaceForShowingMember();
                                break;
                            }

                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("\n[!] You have entered an incorrect number, try again.");
                                
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[CRITICAL ERROR]: {ex.Message} ");
            }
        }
    }
}



