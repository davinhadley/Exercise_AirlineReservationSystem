using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deitel_AirlineReservationSystem
{
    class Flight
    {
        //initialize constants for class Flight
        public const int TOTAL_CAPACITY = FIRSTCLASS_CAPACITY + ECONOMYCLASS_CAPACITY;
        public const int FIRSTCLASS_CAPACITY = 5;
        public const int ECONOMYCLASS_CAPACITY = 5;

        //initialize private instance variables and properties for class Flight
        private bool[] seats = new bool[11];
        private int seatAvailability = TOTAL_CAPACITY;
        private int firstClassCounter = 1; //starting first class seat
        private int economyClassCounter = 6;  //starting economy class seat
        public int FlightNumber { get; set; }

        public Flight(int flight)
        {
            FlightNumber = flight;
        }

        public void DisplayFlightDetails()
        {
            Console.WriteLine("Flight #{0}", FlightNumber);
            Console.WriteLine("Avaialble seats: {0} out of {1}", seatAvailability, TOTAL_CAPACITY);
        }

        public void AssignSeat()
        {
            //user prompt and data validation
            int input;
            Console.WriteLine("[1] First Class Ticket\n[2] Economy Class Ticket");
            Console.Write("Option: ");
            input = Convert.ToInt32(Console.ReadLine());
            if (input < 1 || input > 2)
            {
                Console.WriteLine("Invalid Entry.");
                AssignSeat();
            }

            //determine whether to process the purchasing of 
            //a first class seat or an economy class seat based on user input
            switch (input)
            {
                case 1:
                    AssignFirstClassSeat();
                    break;
                case 2:
                    AssignEconomySeat();
                    break;
                default:
                    break;
            }
        }
        private void AssignFirstClassSeat()
        {
            //determine if first class is full and prompt user to buy an economy class seat
            if (firstClassCounter > FIRSTCLASS_CAPACITY)
            {
                int input;
                Console.WriteLine("There are no more seats in first class. " +
                    "Would you like to buy an economy class seat?\n[1] Yes\n[2]No");
                Console.Write("Option: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                    AssignEconomySeat();
                return;
            }

            //fill open seat and print seat to user
            if (seats[firstClassCounter] == false)
            {
                seats[firstClassCounter] = true;
                Console.WriteLine("First class seat {0} purchased", firstClassCounter);
            }

            firstClassCounter++; //increment firstClassCounter by 1 to indicate the next open seat
            seatAvailability--; // decrement seatAvailability by 1 to indicate 1 less avaialble seat
        }

        private void AssignEconomySeat()
        {
            //determine if economy class is full and prompt user to buy a first class seat
            if (economyClassCounter > TOTAL_CAPACITY)
            {
                int input;
                Console.WriteLine("There are no more seats in economy class. " +
                    "Would you like to buy a first class seat?\n[1] Yes\n[2]No");
                Console.Write("Option: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                    AssignFirstClassSeat();
                return;
            }

            //fill open seat and print seat to user
            if (seats[economyClassCounter] == false)
            {
                seats[economyClassCounter] = true;
                Console.WriteLine("Economy class seat {0} purchased", economyClassCounter);
            }

            economyClassCounter++; //increment economyClassCounter by 1 to indicate the next open seat
            seatAvailability--; // decrement seatAvailability by 1 to indicate 1 less avaialble seat
        }

    }
}
