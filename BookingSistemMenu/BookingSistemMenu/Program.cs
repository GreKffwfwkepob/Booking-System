namespace BookingSystem.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    public class BookingObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public BookingObject(string name, string type, int capacity)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
        }
    }

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