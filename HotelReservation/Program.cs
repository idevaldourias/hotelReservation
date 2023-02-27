using HotelReservation.Entities;
using HotelReservation.Entities.Exceptions;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room number: ");
                int roomNumber = int.Parse(Console.ReadLine());

                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkin = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkout = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomNumber, checkin, checkout);

                Console.Write("Reservation: " + reservation);
                Console.WriteLine();

                Console.WriteLine("Enter data to update the reservation:");

                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkin = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkout = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkin, checkout);

                Console.Write("Reservation: " + reservation);
            } catch (DomainException ex)
            {
                Console.WriteLine("Error in reservation: " + ex.Message);
            }
        }
    }
}