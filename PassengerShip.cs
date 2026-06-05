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
                if (value < 0)
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
                if (value < 0)
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
        public override Ship AddShips(string charac)
        {
            PassengerShip ShipToAdd = new PassengerShip();
            string[] character = charac.Split(',');
            if(character.Length == 7)
            {
                ShipToAdd.NameOfTheShip = character[0];
                ShipToAdd.NameOfThePort = character[1];
                ShipToAdd.EnginePower = Convert.ToInt32(character[2]);
                ShipToAdd.Displacement = Convert.ToInt32(character[3]);
                ShipToAdd.Number_of_passengers = Convert.ToInt32(character[4]);
                ShipToAdd.Number_of_sits = Convert.ToInt32(character[5]);
                ShipToAdd.Capacity_of_sit = Convert.ToInt32(character[6]);
                ship.Add(ShipToAdd);
                Random rnd = new Random();
                ShipToAdd.ShipIndex = rnd.Next(0, 1000);
                return ShipToAdd;
                
            }

            else
            {
                throw new ArgumentException("You have entered data incorrectly");
            }
 

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
                throw new ArgumentException("You have written string inccorectly");
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
        public override void ShipModification(int num, string modification)
        {
           

                    switch (num)
                    {
                        case 1:
                            {
                            

                                EnginePower = Convert.ToDouble(modification);
                               
                                
                                break;
                            }
                        case 2:
                            {

                               

                                Displacement = Convert.ToDouble(modification);
                                
                               
                                break;
                            }
                        case 3:
                            {

                                NameOfTheShip = modification;
                               
                               
                                break;
                            }
                        case 4:
                            {

                                Number_of_passengers = Convert.ToInt32(modification);
                                
                               
                                break;
                            }
                        case 5:
                            {

                                Number_of_sits = Convert.ToInt32(modification);
                               
                               
                                break;
                            }
                        case 6:
                            {
                                Capacity_of_sit = Convert.ToInt32(modification);
                                

                               
                                break;
                            }
                        default:
                        {
                            throw new ArgumentException("You have entered an inccorect number");
                            
                        }
                    }
                
                
            
        }
    }
}
