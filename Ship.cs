using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{

    public class Ship
    {
        protected double enginePower;
        protected string name_of_the_ship;
        protected double displacement;
        protected string name_of_the_port;
        protected List<CrewMember> crew = new List<CrewMember>();
        protected List<Ship> ship;
        public Ship(double enginePower, string name_of_the_ship, double displacement, string name_of_the_port)
        {
            EnginePower = enginePower;
            NameOfTheShip = name_of_the_ship;
            NameOfThePort= name_of_the_port;
            Displacement = displacement;
        }
        public Ship() : this(0, "Ship", 0, "Port") { }

        public double EnginePower
        {
            get
            {
                return enginePower;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Power of the engine can't be negative");
                enginePower = value;
            }
        }
        public string NameOfTheShip
        {
            get
            {
                return name_of_the_ship;

            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The name of the ship can't be empty or white space");
                name_of_the_ship = value;
            }
        }
        public double Displacement
        {
            get
            {
                return displacement;
            }

            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Displacement can`t be negative");
                }
                displacement = value;
            }
        }
        public string NameOfThePort
        {
            get
            {
                return name_of_the_port;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The name of the port can't be empty or white space");
                name_of_the_port = value;
            }
        }
        public virtual void AddShips(Ship ShipToAdd)
        {
            ship.Add(ShipToAdd);

        }
        public virtual void AddMembers(CrewMember member)
        {
            crew.Add(member);
        }
        public virtual bool IshasCaptain()
        {
            int i = 0;
            for (i = 0; i < crew.Count; i++)
            {
                if (crew[i].Proffession == "captain" || crew[i].Proffession == "Captain")
                {
                    i = -1;
                    break;
                }
            }
            if (i == -1)
            {
                return true;
            }
            return false;
        }
        public virtual void ShipModification()
        {
            int k = 0;
            while (true)
            {

                if (k > 0)
                {
                    Console.WriteLine("Do you want to modify another property?");
                    Console.WriteLine("1. Yes ");
                    Console.WriteLine("2. No");
                    int j = Convert.ToInt32(Console.ReadLine());
                    if (j == 2)
                        break;
                }
                Console.WriteLine("There are characteristic of your ship that you want to modify:");
                Console.WriteLine("1. Engine power (in watts)");
                Console.WriteLine("2. Displacement");
                Console.WriteLine("3. Name of the ship");
                Console.WriteLine("4. Quit");
                Console.WriteLine("Enter a number to modify property: ");
                int i = Convert.ToInt32(Console.ReadLine());
                if(i == 4)
                {
                    break;
                }

                    switch (i)
                    {
                        case 1:
                            {
                                Console.WriteLine("Print number you want modify the property:");
                                double Engine = Convert.ToDouble(Console.ReadLine());
                               
                               
                                    EnginePower = Engine;

                                Console.WriteLine($"You have modified property of {name_of_the_ship}");
                                k++;
                                    break;
                            }
                        case 2:
                            {

                                Console.WriteLine("Print number you want modify the property:");
                                double name= Convert.ToDouble(Console.ReadLine());
                               
                                
                                    Displacement = name;
                                Console.WriteLine($"You have modified property of {name_of_the_ship}");
                                k++;
                                break;
                            }
                        case 3:
                            {

                                Console.WriteLine("Print the new name of the ship:");
                                string name = Console.ReadLine();
                               
                                    NameOfTheShip = name;
                                Console.WriteLine($"You have modified property of {name_of_the_ship}");
                                k++;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("You have entered an inccorect number");
                                break;
                            }
                    }
                


            }
            
        }
    }
        

         
}
