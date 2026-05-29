using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
   
    public abstract class Ship
    {
        protected double enginePower;
        protected string name_of_the_ship;
        protected double displacement;
        protected string name_of_the_port;
        private int shipIndex;
        protected static List<CrewMember> crew = new List<CrewMember>();
        protected static List<Ship> ship = new List<Ship>();
        public Ship(double enginePower, string name_of_the_ship, double displacement, string name_of_the_port)
        {
            EnginePower = enginePower;
            NameOfTheShip = name_of_the_ship;
            NameOfThePort= name_of_the_port;
            Displacement = displacement;
            Random rnd = new Random();
            shipIndex = rnd.Next(0, 2000000);
            ship.Add(this);
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
        public int ShipIndex
            {
            get {  return shipIndex; }
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
        public abstract void AddShips(Ship ShipToAdd);


        public abstract void AddMembers(CrewMember member);

        public abstract bool IshasCaptain();

        
        public abstract void ShipModification();
        public void RemoveShipByname(string name)
        {
            int i = 0;
            for (int j = 0; j < ship.Count;j++)
            {
                if (ship[j].NameOfTheShip == name)
                {
                    ship.RemoveAt(j);
                    i = -1;
                    break;
                }

            }
            if (i == -1)
            {
                Console.WriteLine("You have successfully removed the ship from the port");
            }
            else
            {
                Console.WriteLine("You have entered an inccorect name or this ship is not exist");
            }

        }

        public void RemoveShipByIndex(int index)
        {
            Console.WriteLine("Input desired index of the ship: ");
            int desiredIndex = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            foreach (Ship s in ship)
            {
                if (s.ShipIndex == desiredIndex)
                {
                    ship.Remove(s);
                    i = -1;
                    break;
                }

            }
            if (i == -1)
            {
                Console.WriteLine("You have successfully removed the ship from the port");
            }
            else
            {
                Console.WriteLine("You have entered an inccorect name or this ship is not exist");
            }
        }
    }
        

         
}
