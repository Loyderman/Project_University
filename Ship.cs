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
        protected List<CrewMember> crew = new List<CrewMember>();
        protected static List<Ship> ship = new List<Ship>();
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
        public int ShipIndex
            {
            get {  return shipIndex; }
            set
            {
                shipIndex = value;
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

        public List<CrewMember> Crew
        {
            get { return crew; }
        }
        public List<Ship> Ships
        {
            get { return ship; }
        }
        public abstract void AddShips(string character);


        public abstract void AddMembers(string str);

        public abstract bool IshasCaptain();

        
        public abstract void ShipModification(int num, string modification);
        public int[] RemoveShipByname(string name)
        {
            int i = 0;
            int j = 0;
            for (j = 0; j < ship.Count;j++)
            {
                if (ship[j].NameOfTheShip == name)
                {
                    i++;
                }

            }
            int[] ints = new int[3];
            ints[0] = i;
            ints[1] = j;
            return ints;

        }

        public bool RemoveShipByIndex(int index)
        {

            int i = 0;
           
            foreach (Ship s in ship)
            {
                if (s.ShipIndex == index)
                {
                    ship.Remove(s);
                    return true;
                    
                }

            }
            return false;

        }
    }
        

         
}
