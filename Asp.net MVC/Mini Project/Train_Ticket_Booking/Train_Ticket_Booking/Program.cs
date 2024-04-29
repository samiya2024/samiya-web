using System;

namespace Train_Ticket_Booking
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("==========================================================================================");
            Console.WriteLine("\t\t\t\t Welcome to Train Ticket Booking System ");
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("\t\t\t\t 1.Admin ");
            Console.WriteLine("\t\t\t\t 2.User ");
            Console.WriteLine("\t\t\t\t 3.Exit ");


            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Admin_Section.Admin_Access.AdminLogin();
                    break;
                case 2:
                    User_Section.User_Access.U_Logged();
                    break;
                case 3:
                    Console.WriteLine("You have been Logged out from the Application...");

                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }

            Console.ReadLine(); // Keep the console window open
        }
    }
}
