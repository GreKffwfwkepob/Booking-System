using BookingSystem.Models;

namespace BookingSystem.Services
{
    public class BookingService
    {
        public List<User> Users { get; private set; } = new List<User>();
        public List<BookingObject> Objects { get; private set; } = new List<BookingObject>();
        public List<Booking> Bookings { get; private set; } = new List<Booking>();

        public void SeedData()
        {
            Objects.Add(new BookingObject("Hilton Hotel", "Hotel", 10));
            Objects.Add(new BookingObject("Coldplay Concert", "Event", 50));
            Objects.Add(new BookingObject("Flight A123", "Ticket", 100));
        }

        public void AddUser(User user) => Users.Add(user);
        public User Authenticate(string username, string password) =>
            Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        public void AddBooking(string username, BookingObject obj, DateTime date)
        {
            Bookings.Add(new Booking(username, obj.Name, date));
            obj.Capacity--;
        }
    }
}