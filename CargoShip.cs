using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class CargoShip : Ship
    {
        private double currentLoad;
        private double loadCapacity;
        protected List<CargoShip> ships = new List<CargoShip>();
        protected List<CrewMember> crew = new List<CrewMember>();
        public CargoShip(double enginePower, string name_of_the_ship, double displacement, string name_of_the_port, double loadCapacity) : base(enginePower, name_of_the_ship, displacement, name_of_the_port)
        {
            this.loadCapacity = loadCapacity;
        }
        public double LoadCapacity
        {
            get { return loadCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Load capacity can't be negative");
                }
                loadCapacity = value;
            }
        }
        public double CurrentLoad
{
    get { return currentLoad; }
    set
    {
        if (value < 0)
        {
            throw new ArgumentException("Load can't be negative");
        }
        currentLoad = value;
    }
}
         public bool IsOverloading()
 {
     if (CurrentLoad > LoadCapacity)
     {
         Console.WriteLine("Your ship is overloaded");
         return true;

     }
     else
     {
         Console.WriteLine("Your ship is not overloaded");
         return false;
     }
 }

        public void AddShips(CargoShip CarShipToAdd)
        {

            ships.Add(CarShipToAdd);

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
        Console.WriteLine("There are characteristic of your cargo ship that you want to modify:");
        Console.WriteLine("1. Engine power (in watts)");
        Console.WriteLine("2. Displacement");
        Console.WriteLine("3. Name of the ship");
        Console.WriteLine("4. Load Capacity");
        Console.WriteLine("5. Current load");
        Console.WriteLine("6. Quit");
        int i = Convert.ToInt32(Console.ReadLine());
        if (i == 6)
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
                        double name = Convert.ToDouble(Console.ReadLine());


                        LoadCapacity = name;
                        Console.WriteLine($"You have modified property of {name_of_the_ship}");
                        k++;
                        break;

                    }
            case 5:
                {
                    Console.WriteLine("Print number you want modify the property:");
                    double name = Convert.ToDouble(Console.ReadLine());


                    CurrentLoad = name;
                    IsOverloading();
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
