using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class Session
    {

        public Session() { }


        public void ChooseShipYouWantToCange()
        {
            Ship template = new PassengerShip();
            if (template.Ships.Count == 0)
            {
                Console.WriteLine("-----------------You already don`t have ships-----------------");
            }
            else if (template.Ships.Count == 1)
            {
                if (template.Ships[0] is PassengerShip)
                {
                    ModifyPassengerShip(template.Ships[0] as PassengerShip);
                }
                else
                {
                    ModifyCargoShip(template.Ships[0] as CargoShip);
                }
            }
            else
            {
                Console.WriteLine("===Print an individual index of your ship: ");
                int Inindex = Convert.ToInt32(Console.ReadLine());
                foreach (Ship ship in template.Ships)
                {
                    if (ship.ShipIndex == Inindex)
                    {
                        if (template.Ships[0] is PassengerShip)
                        {
                            ModifyPassengerShip(template.Ships[0] as PassengerShip);
                        }
                        else
                        {
                            ModifyCargoShip(template.Ships[0] as CargoShip);
                        }
                        break;
                    }
                }
            }

        }
        public void ModifyPassengerShip(PassengerShip pass)
        {
            while (true)
            {
                Console.WriteLine("$-------------------------------------------------------------------------------$");
                Console.WriteLine($"\nWhat do you want to do with your ship: {pass.NameOfTheShip}");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("1. Modify a property of your ship");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("2. Change number of sits of your ship");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("3. Add members to your ship");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"4. Check if the {pass.NameOfTheShip} has captain");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("5.Change profession of your crew member");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("6. Exit");
                Console.WriteLine("$-------------------------------------------------------------------------------$");
                Console.Write("Enter a number to do something: ");

                string input = Console.ReadLine();
                if (input == "6")
                    break;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Modifying property...");

                        InterfaceForModificationOPfPass(pass);

                        break;

                    case "2":
                        Console.WriteLine("Changing number of seats...");
                        pass.ChangeNumberOfSits();
                        break;

                    case "3":
                        Console.WriteLine("Adding members...");
                        Console.WriteLine("Print with separating by , characteristics of your member: SNP, age, term of work, proffesion");
                        string str = Console.ReadLine();
                        pass.AddMembers(str);

                        break;

                    case "4":
                        Console.WriteLine("Checking for captain...");
                        if (pass.IshasCaptain())
                        {
                            Console.WriteLine("Your ship have captain");
                        }
                        else
                        {
                            Console.WriteLine("Your ship don`t have captain");
                        }

                        break;
                    case "5":
                        {
                            Console.WriteLine("Changing profession...");
                            InterfaceForChangingProfession(pass);
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 5.");
                        break;
                }
            }

        }


        public void ModifyCargoShip(CargoShip pass1)
        {
            while (true)
            {
                Console.WriteLine("$-------------------------------------------------------------------------------$");
                Console.WriteLine($"\nWhat do you want to do with your ship: {pass1.NameOfTheShip}");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("1. Modify a property of your ship");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("2. Check if your ship is overloaded");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("3. Add members to your ship");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"4. Check if the {pass1.NameOfTheShip} has captain");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("5. Change proffesion of your crew member");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("6. Exit");
                Console.WriteLine("$-------------------------------------------------------------------------------$");
                Console.Write("Enter a number to do something: ");

                string input = Console.ReadLine();
                if (input == "6")
                    break;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Modifying property...");
                        InterfaceForModificationOPfCargo(pass1);

                        break;

                    case "2":
                        Console.WriteLine("Checking...");
                        pass1.IsOverloading();
                        break;

                    case "3":
                        {
                            Console.WriteLine("Adding members...");
                            Console.WriteLine("Print with separating by , characteristics of your member: SNP, age, term of work, proffesion");
                            string str = Console.ReadLine();
                            pass1.AddMembers(str); ;

                            break;

                        }

                    case "4":
                        Console.WriteLine("Checking for captain...");
                        if (pass1.IshasCaptain())
                        {
                            Console.WriteLine("Your ship have captain");
                        }
                        else
                        {
                            Console.WriteLine("Your ship don`t have captain");
                        }
                        break;

                    case "5":
                        {
                            Console.WriteLine("Changing proffession:");
                            InterfaceForChangingProfession(pass1);

                            Console.WriteLine("Your proffession was successfully changed");

                            break;

                        }



                    default:
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        public bool InterfaceForChangingProfession(Ship ship)
        {
            if (ship.Crew.Count == 0)
            {
                Console.WriteLine("-------This ship has not members--------");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("Print SNP of member which profession you want to change:");
                CrewMember currentMember = new CrewMember();
                string snp = Console.ReadLine();
                foreach (var a in ship.Crew)
                {
                    if (a.SNP == snp)
                    {
                        currentMember = a;
                    }
                }
                if (currentMember.SNP == "Unknown crew member")
                {
                    Console.WriteLine("There are not such crew member");
                    return false;
                }
                Console.WriteLine($"Print a profession which will be owned by {currentMember.SNP}");
                string prof = Console.ReadLine();
                currentMember.Change_profession(prof);
                Console.WriteLine("---------You have successfuly changed profession of your member---------");
                return true;
            }

        }


        public void InterfaceForModificationOPfPass(PassengerShip pass)
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

                Console.WriteLine("Print the new parameter of property:");
                string name = Console.ReadLine();
                pass.ShipModification(i, name);
                Console.WriteLine($"You have modified property of {pass.NameOfTheShip}");
            }


        }


        public void InterfaceForModificationOPfCargo(CargoShip pass)
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
                Console.WriteLine("Print the new parameter of property:");
                string name = Console.ReadLine();
                pass.ShipModification(i, name);
                Console.WriteLine($"You have modified property of {pass.NameOfTheShip}");
            }
        }

        public void InterfaceforRemovingSips()
        {

            Ship templateShip = new PassengerShip();
            if (templateShip.Ships.Count == 0)
            {
                Console.WriteLine("------There are not ships in the port system------");
            }
            else
            {
                Console.WriteLine("Choose mechanism by means of which you will detect the ship you want to remove");
                Console.WriteLine("1. By the name of the ship");
                Console.WriteLine("2. By the individual index of your ship");
                int k = Convert.ToInt32(Console.ReadLine());

                switch (k)
                {
                    case 1:
                        {
                            Console.WriteLine("Print the name of your ship");
                            string name = Console.ReadLine();
                            int[] count = templateShip.RemoveShipByname(name);
                            if (count[0] == 1)
                            {
                                templateShip.Ships.RemoveAt(count[1]-1);
                            }
                            else if (count[0] == 0)
                            {
                                Console.WriteLine("There are not such ship in the port system");
                            }
                            else
                            {
                                Console.WriteLine("There are several ships with the same name");
                                Console.WriteLine("Print the individual index of your ship");
                                int index = Convert.ToInt32(Console.ReadLine());
                                if ((templateShip.RemoveShipByIndex(index)))
                                {
                                    Console.WriteLine("You have successfully removed a ship from the port");
                                }
                                else
                                {
                                    Console.WriteLine("There are noy such ship in the port system");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Print the individual index of your ship");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if ((templateShip.RemoveShipByIndex(index)))
                            {
                                Console.WriteLine("You have successfully removed a ship from the port");
                            }
                            else
                            {
                                Console.WriteLine("There are noy such ship in the port system");
                            }
                            break;
                        }
                }
            }
        }
            
            }
    }


    

