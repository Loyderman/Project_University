using System;
using System.Collections.Generic;
using System.Linq;
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
                        Console.WriteLine("Hi,it is your port system. Which action do you want to do?");
                        Console.WriteLine("=================================================================");
                    }
                    i++;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("1.Add Passenger ship");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("2.Add Cargo ship");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("3.Change properties in your ship");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("4.Remove ship");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Print number of what you want to do:");
                    k = Console.ReadLine();

                    switch (k)
                    {
                        case "1":
                            {
                                PassengerShip pass = new PassengerShip();
                                Console.WriteLine("Print with separating by , characteristics of your ship: name of the ship, name of the port, engine power, displacement, number of passengers, number of sits and capacity of sits");
                                string character = Console.ReadLine();
                                pass.AddShips(character);



                                break;
                            }
                        case "2":
                            {
                                CargoShip pass1 = new CargoShip();
                                Console.WriteLine("Print with separating by , characteristics of your ship: name of the ship, name of the port, engine power, displacement, load capacity and current load");
                                string character = Console.ReadLine();
                                pass1.AddShips(character);

                                break;

                            }


                        case "3":
                            {
                                session.ChooseShipYouWantToCange();

                                break;

                            }
                        case "4":
                            {
                                session.InterfaceforRemovingSips();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You have entered an inccorect number, try again");
                                break;
                            }
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} ");
            }


        }
    }
}
    


