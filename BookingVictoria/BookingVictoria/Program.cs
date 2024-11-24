namespace BookingSystem
{
    public class Booking
    {
        public string Username { get; set; }
        public string ObjectName { get; set; }
        public DateTime BookingDate { get; set; }

        public Booking(string username, string objectName, DateTime bookingDate)
        {
            Username = username;
            ObjectName = objectName;
            BookingDate = bookingDate;
        }
    }
}