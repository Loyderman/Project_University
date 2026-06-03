using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class CargoShip : Ship
    {
        private double loadCapacity;
        private double currentLoad;
        private int shipIndex;
        public CargoShip() : this(0, "Unknown", 0, "Unknown", 0, 0) { }
        public CargoShip(double enginePower, string name_of_the_ship, double displacement, string name_of_the_port, double loadCapacity, double load) : base(enginePower, name_of_the_ship, displacement, name_of_the_port)
        {
            LoadCapacity = loadCapacity;
            CurrentLoad = load;
            

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
        public override void AddShips(string charac)
        {
            CargoShip ShipToAdd = new CargoShip();
            string[] character = charac.Split(',');
            ShipToAdd.NameOfTheShip = character[0];
            ShipToAdd.NameOfThePort = character[1];
            ShipToAdd.EnginePower = Convert.ToInt32(character[2]);
            ShipToAdd.Displacement = Convert.ToInt32(character[3]);
            ShipToAdd.LoadCapacity = Convert.ToInt32(character[4]);
            ShipToAdd.CurrentLoad = Convert.ToInt32(character[5]);
            ship.Add(ShipToAdd);
            Random rnd = new Random();
            ShipToAdd.ShipIndex = rnd.Next(0, 1000);

        }

        public override void AddMembers(string str)
        {
            CrewMember member = new CrewMember();

            string[] character = str.Split(',');
            if (character.Length == 4)
            {
                member.SNP = character[0];
                member.Age = Convert.ToInt32(character[1]);
                member.Term_of_work = Convert.ToInt32(character[2]);
                member.Proffession = character[3];
                crew.Add(member);
            }

            else
            {
                Console.WriteLine("You have written string inccorectly");
            }
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
        public override void ShipModification(int num, string mod)
        {
                    switch (num)
                    {
                        case 1:
                            {
                        EnginePower = Convert.ToDouble(mod);
                        break;
                            }
                        case 2:
                            {

                        Displacement = Convert.ToDouble(mod);
 
                                break;
                            }
                        case 3:
                            {

                        NameOfTheShip = mod;

                                break;
                            }
                        case 4:
                            {

                                LoadCapacity = Convert.ToDouble(mod);

                                break;

                            }
                    case 5:
                        {

                            CurrentLoad = Convert.ToDouble(mod);
                            IsOverloading();
                            break;
                        }
                    default:
                        {
                            
                            break;
                        }
                    }
                
                
            }
        }
    }

