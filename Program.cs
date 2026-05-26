using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ship: ");
            Ship ship = new Ship(230, "Alex", 345, "Parus");

            ship.ShipModification();

            Ship ship1 = new CargoShip(123,"h",345,"234234", 34567);

            CrewMember member = new CrewMember("Ivanov", "captain", 34, 5);
            CrewMember member1 = new CrewMember("Sergey", "Janitor", 45, 4);
            CrewMember member2 = new CrewMember("Alex", "Chef", 19, 3);
            CrewMember member3 = new CrewMember("Ksenia", "Pilot", 22, 2);

           // ship.AddMembers(member);

            ship1.AddMembers(member1);
            ship1.AddMembers(member2);
            ship1.AddMembers(member3);
            ship1.AddMembers(member);

            Console.WriteLine(ship1.IshasCaptain());


            Console.WriteLine("Passenger ship: ");

            PassengerShip pass = new PassengerShip(12, "Pass", 345, "Port1", 23, 35, 2);

            pass.ShipModification();

            PassengerShip pass1 = new PassengerShip(12, "Passenger Sip", 35, "Port2", 24, 46, 2);

            pass.AddShips(pass1);

            pass.ShipModification();

            Console.WriteLine("Cargo ship: ");

            Ship ship3 = new CargoShip(123, "h", 345, "234234", 34567);

            ship3.ShipModification();




        }
    }
}
