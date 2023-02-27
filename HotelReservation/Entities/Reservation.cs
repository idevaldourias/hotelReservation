using HotelReservation.Entities.Exceptions;

namespace HotelReservation.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            if (checkin <= DateTime.Now)
            {
                throw new DomainException("The check-in date cannot be earlier than the current date");
            } 
            else if (checkout <= checkin)
            {
                throw new DomainException("The check-out date must be after the check-in date");
            }
            RoomNumber = roomNumber;
            Checkin = checkin;
            Checkout = checkout;
        }

        public int Duration()
        {
            TimeSpan duration = Checkout.Subtract(Checkin);
            return duration.Days;
        }

        public void UpdateDates(DateTime chekin, DateTime checkout)
        {
            if (chekin <= Checkin || checkout <= Checkout)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            if (checkout <= chekin)
            {
                throw new DomainException("Check-out date must be after check-in date");
            }
            Checkin = chekin;
            Checkout = checkout;
        }

        public override string ToString()
        {
            return "Room " + RoomNumber 
                + "; Check-In: " 
                + Checkin.ToString("dd/MM/yyyy") + "; Check-Out: "
                + Checkout.ToString("dd/MM/yyyy") + "; " + Duration() + " nights.";
        }
    }
}
