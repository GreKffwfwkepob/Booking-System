using System;
using System.Collections.Generic;

namespace BookingSystem
{
    class Program
    {
        static List<User> Users = new List<User>();
        static List<BookingObject> Objects = new List<BookingObject>();
        static List<Booking> Bookings = new List<Booking>();

        static User CurrentUser = null;

        static void Main(string[] args)
        {
            SeedData();
            MainMenu();
        }

        static void SeedData()
        {
            Objects.Add(new BookingObject("Hilton Hotel", "Hotel", 10));
            Objects.Add(new BookingObject("Coldplay Concert", "Event", 50));
            Objects.Add(new BookingObject("Flight A123", "Ticket", 100));
            Objects.Add(new BookingObject("Love Bomb", "Hotel", 25));
            Objects.Add(new BookingObject("Dubai Moll", "Hotel", 400));
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в систему бронирования!");
                Console.WriteLine("1. Вход");
                Console.WriteLine("2. Регистрация");
                Console.WriteLine("3. Вход для администратора");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите опцию: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        AdminMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }

        static void Register()
        {
            Console.Clear();
            Console.WriteLine("Регистрация:");
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Users.Add(new User(username, password));
            Console.WriteLine("Регистрация прошла успешно!");
            Console.ReadKey();
        }

        // Авторизация пользователя
        static void Login()
        {
            Console.Clear();
            Console.WriteLine("Вход:");
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    CurrentUser = user;
                    Console.WriteLine("Вход выполнен успешно!");
                    Console.ReadKey();
                    UserMenu();
                    return;
                }
            }

            Console.WriteLine("Неверное имя пользователя или пароль.");
            Console.ReadKey();
        }

        // Меню пользователя
        static void UserMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать, {CurrentUser.Username}!");
                Console.WriteLine("1. Просмотр доступных объектов");
                Console.WriteLine("2. Забронировать объект");
                Console.WriteLine("3. Мои бронирования");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите опцию: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewObjects();
                        break;
                    case "2":
                        MakeBooking();
                        break;
                    case "3":
                        ViewBookings();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }

        // Просмотр доступных объектов
        static void ViewObjects()
        {
            Console.Clear();
            Console.WriteLine("Доступные объекты:");
            foreach (var obj in Objects)
            {
                Console.WriteLine($"{obj.Name} ({obj.Type}), Свободных мест: {obj.Capacity}");
            }
            Console.ReadKey();
        }

        // Создание бронирования
        static void MakeBooking()
        {
            Console.Clear();
            Console.WriteLine("Выберите объект для бронирования:");
            for (int i = 0; i < Objects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Objects[i].Name} ({Objects[i].Type}), Свободных мест: {Objects[i].Capacity}");
            }
            Console.Write("Введите номер объекта: ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < Objects.Count)
            {
                var obj = Objects[choice];
                if (obj.Capacity > 0)
                {
                    Console.Write("Введите дату бронирования (гггг-мм-дд): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Bookings.Add(new Booking(CurrentUser.Username, obj.Name, date));
                    obj.Capacity--;
                    Console.WriteLine("Бронирование успешно!");
                }
                else
                {
                    Console.WriteLine("Мест больше нет.");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
            Console.ReadKey();
        }

        // Просмотр бронирований пользователя
        static void ViewBookings()
        {
            Console.Clear();
            Console.WriteLine("Ваши бронирования:");
            foreach (var booking in Bookings)
            {
                if (booking.Username == CurrentUser.Username)
                {
                    Console.WriteLine($"{booking.ObjectName} на {booking.BookingDate.ToShortDateString()}");
                }
            }
            Console.ReadKey();
        }
        // Меню администратора
        static void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Админ-панель:");
            Console.WriteLine("1. Добавить объект");
            Console.WriteLine("2. Просмотреть бронирования");
            Console.WriteLine("3. Назад");
            Console.Write("Выберите опцию: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddObject();
                    break;
                case "2":
                    ViewAllBookings();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
            Console.ReadKey();
        }

        // Добавление нового объекта
        static void AddObject()
        {
            Console.Clear();
            Console.Write("Введите название объекта: ");
            string name = Console.ReadLine();
            Console.Write("Введите тип объекта (Hotel, Event, Ticket): ");
            string type = Console.ReadLine();
            Console.Write("Введите вместимость: ");
            int capacity = int.Parse(Console.ReadLine());

            Objects.Add(new BookingObject(name, type, capacity));
            Console.WriteLine("Объект добавлен!");
            Console.ReadKey();
        }

        // Просмотр всех бронирований
        static void ViewAllBookings()
        {
            Console.Clear();
            Console.WriteLine("Все бронирования:");
            foreach (var booking in Bookings)
            {
                Console.WriteLine($"{booking.Username} забронировал {booking.ObjectName} на {booking.BookingDate.ToShortDateString()}");
            }
            Console.ReadKey();
        }
    }

}
