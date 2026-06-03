using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Programming
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {


                Ship ship1 = new CargoShip(123, "h", 345, "234234", 34567, 354);

                CrewMember member = new CrewMember("Ivanov Sergey Sergeyevich", "captain", 34, 5);
                CrewMember member1 = new CrewMember("Sergey s s", "Janitor", 45, 4);
                CrewMember member2 = new CrewMember("Alex A A", "Chef", 19, 3);
                CrewMember member3 = new CrewMember("Ksenia B B", "Pilot", 22, 2);

                // ship.AddMembers(member);

                ship1.AddMembers(member1);
                ship1.AddMembers(member2);
                ship1.AddMembers(member3);
                ship1.AddMembers(member);

                Console.WriteLine(ship1.IshasCaptain());


                Console.WriteLine("Passenger ship: ");

                Ship pass = new PassengerShip(12, "Por", 345, "Port1", 23, 35, 2);

                //pass.ShipModification();

                Ship pass1 = new PassengerShip(12, "Passenger Sip", 35, "Port2", 24, 46, 2);

                pass.AddShips(pass1);
                pass.AddMembers(member1);
                Console.WriteLine(pass.IshasCaptain());
                //pass.ShipModification();

                Console.WriteLine("Cargo ship: ");

                Ship ship3 = new CargoShip(123, "h", 345, "234234", 34567, 8776554);

                //ship3.ShipModification();

                ship3.RemoveShipByname("1234");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message} ");
            }


        }
    }
}
