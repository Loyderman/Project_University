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
                Console.WriteLine("\n\t+---------------------------------------------------------+");
                Console.WriteLine("\t| SYSTEM: You already don't have any ships in port.       |");
                Console.WriteLine("\t+---------------------------------------------------------+\n");
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
                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine("| SHIP SELECTION BOARD                                                      |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Print an individual index of your ship: ");
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
                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine($"| PASSENGER SHIP MANAGEMENT: {pass.NameOfTheShip,-46} |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.WriteLine("| 1. Modify a property of your ship                                         |");
                Console.WriteLine("| 2. Change number of sits of your ship                                     |");
                Console.WriteLine("| 3. Add members to your ship                                               |");
                Console.WriteLine($"| 4. Check if the {pass.NameOfTheShip} has captain                                           |");
                Console.WriteLine("| 5. Change profession of your crew member                                  |");
                Console.WriteLine("| 6. Exit                                                                   |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Enter a number to do something: ");

                string input = Console.ReadLine();
                if (input == "6")
                    break;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n[Modifying property...]");
                        InterfaceForModificationOPfPass(pass);
                        break;

                    case "2":
                        Console.WriteLine("\n[Changing number of seats...]");
                        pass.ChangeNumberOfSits();
                        break;

                    case "3":
                        Console.WriteLine("\n[Adding members...]");
                        Console.WriteLine("  Print with separating by ',' characteristics of your member:");
                        Console.WriteLine("  SNP, age, term of work, proffesion");
                        Console.Write("  -> ");
                        string str = Console.ReadLine();
                        pass.AddMembers(str);
                        break;

                    case "4":
                        Console.WriteLine("\n[Checking for captain...]");
                        if (pass.IshasCaptain())
                        {
                            Console.WriteLine("\n\t=== Your ship have captain ===");
                        }
                        else
                        {
                            Console.WriteLine("\n\t=== Your ship don`t have captain ===");
                        }
                        break;

                    case "5":
                        {
                            Console.WriteLine("\n[Changing profession...]");
                            InterfaceForChangingProfession(pass);
                            break;
                        }
                    default:
                        Console.WriteLine("\n[!] Invalid input. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        public void ModifyCargoShip(CargoShip pass1)
        {
            while (true)
            {
                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine($"| CARGO SHIP MANAGEMENT: {pass1.NameOfTheShip,-50} |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.WriteLine("| 1. Modify a property of your ship                                         |");
                Console.WriteLine("| 2. Check if your ship is overloaded                                       |");
                Console.WriteLine("| 3. Add members to your ship                                               |");
                Console.WriteLine($"| 4. Check if the {pass1.NameOfTheShip} has captain                        |");
                Console.WriteLine("| 5. Change proffesion of your crew member                                  |");
                Console.WriteLine("| 6. Exit                                                                   |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Enter a number to do something: ");

                string input = Console.ReadLine();
                if (input == "6")
                    break;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n[Modifying property...]");
                        InterfaceForModificationOPfCargo(pass1);
                        break;

                    case "2":
                        Console.WriteLine("\n[Checking...]");
                        if(pass1.IsOverloading())
                        {
                            Console.WriteLine("Your ship is overloaded");
                        }
                        else
                        {
                            Console.WriteLine("Yoyr ship is not overloaded");
                        }
                            break;

                    case "3":
                        {
                            Console.WriteLine("\n[Adding members...]");
                            Console.WriteLine("  Print with separating by ',' characteristics of your member:");
                            Console.WriteLine("  SNP, age, term of work, proffesion");
                            Console.Write("  -> ");
                            string str = Console.ReadLine();
                            pass1.AddMembers(str);
                            break;
                        }

                    case "4":
                        Console.WriteLine("\n[Checking for captain...]");
                        if (pass1.IshasCaptain())
                        {
                            Console.WriteLine("\n\t=== Your ship have captain ===");
                        }
                        else
                        {
                            Console.WriteLine("\n\t=== Your ship don`t have captain ===");
                        }
                        break;

                    case "5":
                        {
                            Console.WriteLine("\n[Changing proffession...]");
                            InterfaceForChangingProfession(pass1);
                            Console.WriteLine("\n\t=== Your proffession was successfully changed ===");
                            break;
                        }

                    default:
                        Console.WriteLine("\n[!] Invalid input. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        public bool InterfaceForChangingProfession(Ship ship)
        {
            if (ship.Crew.Count == 0)
            {
                Console.WriteLine("\n\t+---------------------------------------------------------+");
                Console.WriteLine("\t| ------- This ship has not members -------               |");
                Console.WriteLine("\t+---------------------------------------------------------+\n");
                return false;
            }
            else
            {
                Console.Write("\n  Print SNP of member which profession you want to change: ");
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
                    Console.WriteLine("\n\t[!] There are not such crew member");
                    return false;
                }
                Console.Write($"  Print a profession which will be owned by {currentMember.SNP}: ");
                string prof = Console.ReadLine();
                currentMember.Change_profession(prof);
                Console.WriteLine("\n\t+---------------------------------------------------------+");
                Console.WriteLine("\t| --------- Successfuly changed profession ---------       |");
                Console.WriteLine("\t+---------------------------------------------------------+\n");
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
                    Console.WriteLine("\n+---------------------------------------------------------------------------+");
                    Console.WriteLine("| Do you want to modify another property?                                   |");
                    Console.WriteLine("+---------------------------------------------------------------------------+");
                    Console.WriteLine("| 1. Yes                                                                    |");
                    Console.WriteLine("| 2. No                                                                     |");
                    Console.WriteLine("+---------------------------------------------------------------------------+");
                    Console.Write("  Choose option: ");
                    int j = Convert.ToInt32(Console.ReadLine());
                    if (j == 2)
                        break;
                }
                k++;

                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine("| CHARACTERISTIC OF YOUR PASSENGER SHIP TO MODIFY                           |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.WriteLine("| 1. Engine power (in watts)                                                |");
                Console.WriteLine("| 2. Displacement                                                           |");
                Console.WriteLine("| 3. Name of the ship                                                       |");
                Console.WriteLine("| 4. Number of passengers                                                   |");
                Console.WriteLine("| 5. Number of sits                                                         |");
                Console.WriteLine("| 6. Capacity of sit                                                        |");
                Console.WriteLine("| 7. Quit                                                                   |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Enter parameter index: ");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 7)
                    break;

                Console.Write("  Print the new parameter of property: ");
                string name = Console.ReadLine();
                pass.ShipModification(i, name);
                Console.WriteLine($"\n\t=== You have modified property of {pass.NameOfTheShip} ===");
            }
        }

        public void InterfaceForModificationOPfCargo(CargoShip pass)
        {
            int k = 0;
            while (true)
            {
                if (k > 0)
                {
                    Console.WriteLine("\n+---------------------------------------------------------------------------+");
                    Console.WriteLine("| Do you want to modify another property?                                   |");
                    Console.WriteLine("+---------------------------------------------------------------------------+");
                    Console.WriteLine("| 1. Yes                                                                    |");
                    Console.WriteLine("| 2. No                                                                     |");
                    Console.WriteLine("+---------------------------------------------------------------------------+");
                    Console.Write("  Choose option: ");
                    int j = Convert.ToInt32(Console.ReadLine());
                    if (j == 2)
                        break;
                }
                k++;

                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine("| CHARACTERISTIC OF YOUR CARGO SHIP TO MODIFY                               |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.WriteLine("| 1. Engine power (in watts)                                                |");
                Console.WriteLine("| 2. Displacement                                                           |");
                Console.WriteLine("| 3. Name of the ship                                                       |");
                Console.WriteLine("| 4. Load Capacity                                                          |");
                Console.WriteLine("| 5. Current load                                                           |");
                Console.WriteLine("| 6. Quit                                                                   |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Enter parameter index: ");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 6)
                    break;

                Console.Write("  Print the new parameter of property: ");
                string name = Console.ReadLine();
                pass.ShipModification(i, name);
                Console.WriteLine($"\n\t=== You have modified property of {pass.NameOfTheShip} ===");
            }
        }

        public void InterfaceforRemovingSips()
        {
            Ship templateShip = new PassengerShip();
            if (templateShip.Ships.Count == 0)
            {
                Console.WriteLine("\n\t+---------------------------------------------------------+");
                Console.WriteLine("\t| ------ There are not ships in the port system ------    |");
                Console.WriteLine("\t+---------------------------------------------------------+\n");
            }
            else
            {
                Console.WriteLine("\n+---------------------------------------------------------------------------+");
                Console.WriteLine("| SHIP REMOVAL WIZARD                                                       |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.WriteLine("| 1. By the name of the ship                                                |");
                Console.WriteLine("| 2. By the individual index of your ship                                   |");
                Console.WriteLine("+---------------------------------------------------------------------------+");
                Console.Write("  Choose mechanism: ");
                int k = Convert.ToInt32(Console.ReadLine());

                switch (k)
                {
                    case 1:
                        {
                            Console.Write("\n  Print the name of your ship: ");
                            string name = Console.ReadLine();
                            int[] count = templateShip.RemoveShipByname(name);
                            if (count[0] == 1)
                            {
                                templateShip.Ships.RemoveAt(count[1] - 1);
                                Console.WriteLine("\n\t=== Ship removed successfully ===");
                            }
                            else if (count[0] == 0)
                            {
                                Console.WriteLine("\n\t[!] There are not such ship in the port system");
                            }
                            else
                            {
                                Console.WriteLine("\n\t[!] There are several ships with the same name");
                                Console.Write("  Print the individual index of your ship: ");
                                int index = Convert.ToInt32(Console.ReadLine());
                                if ((templateShip.RemoveShipByIndex(index)))
                                {
                                    Console.WriteLine("\n\t=== You have successfully removed a ship from the port ===");
                                }
                                else
                                {
                                    Console.WriteLine("\n\t[!] There are noy such ship in the port system");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("\n  Print the individual index of your ship: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if ((templateShip.RemoveShipByIndex(index)))
                            {
                                Console.WriteLine("\n\t=== You have successfully removed a ship from the port ===");
                            }
                            else
                            {
                                Console.WriteLine("\n\t[!] There are noy such ship in the port system");
                            }
                            break;
                        }
                }
            }
        }
    }
}


    

