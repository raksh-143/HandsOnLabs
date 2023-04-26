using MovieRecommendation.BusinessLayer;
using MovieRecommendation.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.UILayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Movie Ticket Booking System!");
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose one of the following operations:");
                    Console.WriteLine("1. Add User\n2. Update User\n3. Delete User\n" +
                        "4. Book a show\n5. Cancel a booking");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Username, First Name and Last Name of the user (each on a different line): ");
                            User user = new User();
                            user.LoginName = Console.ReadLine();
                            user.FirstName = Console.ReadLine();
                            user.LastName = Console.ReadLine();
                            UserAccountManager uam = new UserAccountManager();
                            int userid = uam.AddUser(user);
                            Console.WriteLine($"User insertion Successful!\nYou're User ID is {userid}");
                            break;
                        case 2:
                            Console.WriteLine("Enter new Username, First Name and Last Name of the user along with the User ID (each on a different line): ");
                            user = new User();
                            user.LoginName = Console.ReadLine();
                            user.FirstName = Console.ReadLine();
                            user.LastName = Console.ReadLine();
                            user.UserID = int.Parse(Console.ReadLine());
                            uam = new UserAccountManager();
                            bool res = uam.UpdateUser(user);
                            if (res) { Console.WriteLine("User updation Successful!"); }
                            break;
                        case 3:
                            Console.WriteLine("Enter User ID of the user to be deleted: ");
                            user = new User();
                            user.UserID = int.Parse(Console.ReadLine());
                            uam = new UserAccountManager();
                            res = uam.DeleteUser(user);
                            if (res) { Console.WriteLine("User deletion Successful!"); }
                            break;

                        case 4: PerformBooking pb = null;
                            Console.WriteLine("Enter user id: ");
                            Booking booking = new Booking();
                            booking.User = new User();
                            booking.User.UserID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the show ID that you want to book for: ");
                            ShowInfo showInfo = new ShowInfo();
                            List<Show> availableShows = showInfo.GetShows();
                            if (availableShows.Count > 0)
                            {
                                Console.WriteLine("Show ID\tShow Time\t Show Cost");
                                foreach(var show in availableShows)
                                {
                                    Console.WriteLine($"{show.ShowId}\t{show.ShowTime}\t{show.Cost}");
                                }
                                booking.Show = new Show();
                                booking.Show.ShowId = int.Parse(Console.ReadLine());
                                pb = new PerformBooking();
                                int bookingid = pb.Book(booking);
                                Console.WriteLine($"Booking Successful!\nYou're booking id is {bookingid}");
                            }
                            else
                            {
                                Console.WriteLine("No shows available! Try again later!");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Enter Booking ID to be cancelled: ");
                            booking = new Booking();
                            booking.BookingId = int.Parse(Console.ReadLine());
                            pb = new PerformBooking();
                            res = pb.Cancel(booking);
                            if (res) { Console.WriteLine("Booking cancellation Successful!"); }
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
