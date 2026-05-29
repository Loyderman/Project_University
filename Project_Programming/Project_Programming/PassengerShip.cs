using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class PassengerShip : Ship
    {
        private int number_of_passengers;
        private int number_of_sits;
        private int capacity_of_sit;
        //protected List<PassengerShip> ship;
        //protected List<CrewMember> crew = new List<CrewMember>();

        public PassengerShip() : this(0, "Unknown", 234, "Unknown", 0, 0, 1) { }
        public PassengerShip(double enginePower, string name_of_the_ship, double displacement, string name_of_the_port, int number_of_passengers, int number_of_sits, int capacity_of_sit) : base(enginePower, name_of_the_ship, displacement, name_of_the_port)
        {

            Number_of_passengers = number_of_passengers;
            Number_of_sits = number_of_sits;
            Capacity_of_sit = capacity_of_sit;
            
        }
        public int Number_of_passengers
        {
            get
            {
                return number_of_passengers;
            }
            set
            {
                if (number_of_passengers < 0)
                {
                    throw new ArgumentException("The number of passengers can't be negative");

                }
                number_of_passengers = value;
            }
        }
        public int Number_of_sits
        {
            get
            {
                return number_of_sits;
            }
            set
            {
                if (number_of_sits < 0)
                {
                    throw new ArgumentException("The number of sits can't be negative");

                }
                number_of_sits = value;
            }
        }
        public int Capacity_of_sit
        {
            get
            {
                return capacity_of_sit;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity of sit can't be negative or equal to zero");

                }
                capacity_of_sit = value;
            }
        }
        public bool IsEnoughSits()
        {
            if (Number_of_passengers + crew.Count <= Capacity_of_sit * Number_of_sits)
                return true;
            return false;


        }
        public void ChangeNumberOfSits()
        {
            if (!IsEnoughSits())
            {
                int a = Number_of_passengers + crew.Count - (Capacity_of_sit * Number_of_sits);
                if (a < Capacity_of_sit)
                {
                    Number_of_sits += 1;
                }
                else
                {
                    Number_of_sits += (a + (Capacity_of_sit - 1)) / Capacity_of_sit;
                }


            }


        }
        public override void AddShips(Ship ShipToAdd)
        {
            ship.Add(ShipToAdd);
            Console.WriteLine($"Your ship was succesfully added to the {name_of_the_port}");

        }
      
        public override void AddMembers(CrewMember member)
        {
            crew.Add(member);
        }
        public override bool IshasCaptain()
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
        public override void ShipModification()
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
                Console.WriteLine("There are characteristic of your passenger ship that you want to modify:");
                Console.WriteLine("1. Engine power (in watts)");
                Console.WriteLine("2. Displacement");
                Console.WriteLine("3. Name of the ship");
                Console.WriteLine("4. Number of passengers");
                Console.WriteLine("5. Number of sits");
                Console.WriteLine("6. Capacity of sit");
                Console.WriteLine("7. Quit");
                int i = Convert.ToInt32(Console.ReadLine());

                if (i == 7)
                    break;

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
                                double name = Convert.ToDouble(Console.ReadLine());

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
                        case 4:
                            {

                                Console.WriteLine("Print number you want modify the property:");
                                int name = Convert.ToInt32(Console.ReadLine());
                                Number_of_passengers = name;
                                Console.WriteLine($"You have modified property of {name_of_the_ship}");
                                k++;
                                break;
                            }
                        case 5:
                            {

                                Console.WriteLine("Print number you want modify the property:");
                                int name = Convert.ToInt32(Console.ReadLine());

                                Number_of_sits = name;
                                Console.WriteLine($"You have modified property of {name_of_the_ship}");
                                k++;
                                break;
                            }
                        case 6:
                            {

                                Console.WriteLine("Print number you want modify the property:");
                                int name = Convert.ToInt32(Console.ReadLine());
                                Capacity_of_sit = name;
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
