using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deitel_AirlineReservationSystem
{
    class AirlineSystem
    {
        //initialize static variables for class AirlineSystem
        static int flightNumber;
        static int menuOption;
        private static Flight myFlight;

        public static void Main(string[] args)
        {
            InputFlightNumber();
            SelectMenuOption();

            while (menuOption != 3)
            {
                switch (menuOption)
                {
                    case 1:
                        myFlight.AssignSeat();
                        break;
                    case 2:
                        myFlight.DisplayFlightDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
                SelectMenuOption();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void InputFlightNumber()
        {
            //prompt user for input and validate flight number
            Console.Write("Please enter a 4-digit flight number: ");
            flightNumber = Convert.ToInt32(Console.ReadLine());
            if (flightNumber < 1000 || flightNumber > 9999)
            {
                Console.WriteLine("Invalid Entry");
                InputFlightNumber();
            }
            else
                myFlight = new Flight(flightNumber);
        }

        static void SelectMenuOption()
        {
            //display option menu and read user input
            Console.WriteLine("\n[1] Purchase a seat\n[2] Display flight details\n[3] Exit");
            Console.Write("Option: ");
            menuOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); //blank space
        }
    }
}
