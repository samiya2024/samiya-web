using System;
using System.Linq;
using Train_Ticket_Booking.Admin_Section;

namespace Train_Ticket_Booking.Admin_Section
{
    public class Admin_Access
    {
        static Railway_reservationEntities1 RR = new Railway_reservationEntities1();

        public static void Adm_Logged()
        {
            Console.WriteLine("\t\t\t\t\t\tAdmin Section");
            AdminLogin();
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("\t\t\t\t-------Welcome to Admin Page-------\n");

            Console.WriteLine("Choose the Following Option:");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Modify Train");
            Console.WriteLine("3. Delete Train (Soft delete)");
            Console.WriteLine("4. Activate Train");
            Console.WriteLine("5. Show all Trains");
            Console.WriteLine("6.. Exit");
            Console.WriteLine("\n");
        }

        public static void ExecuteMenuChoice(int choice)
        {
            switch (choice)
            {

                case 1:
                    Console.Write("Enter Train Number: ");
                    int trainId = Convert.ToInt32(Console.ReadLine());
                    Add_Train(trainId);
                    ReverseValue();

                    break;
                case 2:
                    Modify_Train();
                    ReverseValue();
                    break;
                case 3:
                    DeActivate_Train();
                    ReverseValue();
                    break;
                case 4:
                    Activate_Train();
                    ReverseValue();
                    break;

                case 5:
                    Train_Details();
                    ReverseValue();
                    break;

                case 6:
                    Ex();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }

        public static void Add_Train(int trainId)
        {
            Train newTrain = new Train();

            var existingTrain = RR.Trains.FirstOrDefault(train => train.Train_no == trainId);

            if (existingTrain == null)
            {
                newTrain.Train_no = trainId;
                Console.Write("Enter Train Name: ");
                newTrain.Train_name = Console.ReadLine();
                Console.Write("Enter The Departure City: ");
                newTrain.Source_loc = Console.ReadLine();
                Console.Write("Enter Arrival City: ");
                newTrain.Destination = Console.ReadLine();
                newTrain.Train_Status = true;

                RR.Trains.Add(newTrain);
                RR.SaveChanges();

                // Add seats

                Console.Write("Enter No. of Seats of 1AC: ");
                int fac = int.Parse(Console.ReadLine());
                Console.Write("Enter No. of Seats of 2AC: ");
                int sac = int.Parse(Console.ReadLine());
                Console.Write("Enter No. of Seats of SL: ");
                int tac = int.Parse(Console.ReadLine());
                RR.Add_Seatdet(trainId, fac, sac, tac);


                // Add fares
                Console.Write("Enter the price of 1AC Ticket: ");
                int facf = int.Parse(Console.ReadLine());
                Console.Write("Enter the price of 2AC Ticket: ");
                int sacf = int.Parse(Console.ReadLine());
                Console.Write("Enter the price of 3AC Ticket: ");
                int tacf = int.Parse(Console.ReadLine());
                RR.Add_FairDet(trainId, facf, sacf, tacf);

                Console.WriteLine("\n\n\t\t\t\t**Train has been Added to the Railway Database.**");
            }
            else
            {
                Console.WriteLine($"Train no. {trainId} is already running. Press (*) to add another or (3) to exit.");
                Console.Write("Choice:> ");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");
                switch (choice)
                {
                    case "*":
                        Add_Train(trainId);
                        break;
                    case "3":
                        Console.WriteLine("You have been Logged out from the Admin Section.");
                        break;
                }
            }
        }

        public static void Modify_Train()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Modifying Train Details:");
            Console.Write("Enter Train Number to modify: ");
            int trainNo;
            while (!int.TryParse(Console.ReadLine(), out trainNo))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer Train Number.");
                Console.Write("Enter Train Number to modify: ");
            }
            var train = RR.Trains.FirstOrDefault(t => t.Train_no == trainNo);
            if (train != null)
            {
                Console.WriteLine("Enter New Train Name (Press Enter to keep the existing value): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                    train.Train_name = newName;

                // Similarly, you can add prompts for other properties like source, destination, and date of travel

                RR.SaveChanges();
                Console.WriteLine("Train details modified successfully!");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Train not found!");
            }
            Console.WriteLine("\n");
        }



        public static void Exit()
        {
            Console.WriteLine("Thank you. Exiting...");
            Environment.Exit(0);
        }
        public static void Train_Details()
        {
            Console.WriteLine("\t\t\t\t\t\t*Train Details*\n\n");

            var Show = RR.Trains;
            int i = 1;

            Console.WriteLine("+=====+=============+======================+================+================+======================+");
            Console.WriteLine("| No. | Train ID    | Train Name           | Departure City | Arrival City   | Status               |");
            Console.WriteLine("+=====+=============+======================+================+================+======================+");

            foreach (var td in Show)
            {
                Console.WriteLine($"| {i,-4} | {td.Train_no,-11} | {td.Train_name,-20} | {td.Source_loc,-14} | {td.Destination,-14} | {td.Train_Status,-20} |");
                Console.WriteLine("+-----+-------------+----------------------+----------------+----------------+----------------------+");

                i++;
            }
        }

  

        public static void AdminLogin()
        {
            Console.WriteLine("\t\t\t\tHello Admin!!!, To login please enter....\n");


            // For simplicity, let's assume a hardcoded admin username and password
            Admin_Login Ar = new Admin_Login();
            Console.WriteLine("Enter code: ");
            int code = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine("\n");

            var ACode = RR.Admin_Login.FirstOrDefault(ac => ac.Admin_Code == code);
            var AUserName = RR.Admin_Login.FirstOrDefault(ac1 => ac1.Admin_userName == username);
            var APass = RR.Admin_Login.FirstOrDefault(ac2 => ac2.Admin_pass == password);


            if (ACode != null && AUserName != null && APass != null)
            {
                // Authentication successful
                DisplayMenu();
                Console.Write("Enter your choice (1-5): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                ExecuteMenuChoice(choice);
            }
            else
            {
                Console.WriteLine("Login Details are not correct");
                Console.WriteLine("Press {a} for login again... or {b} for Exit....");
                string da = Console.ReadLine();
                switch (da)
                {
                    case "a":
                        AdminLogin();
                        break;

                    case "b":
                        Ex();
                        break;
                    default:
                        Console.WriteLine("Wrong Input...");
                        break;
                }
            }
        }

        public static void Ex()
        {
            Console.WriteLine("You have been Logged out from The Device...");
        }

        public static void DeActivate_Train()
        {
            Console.Write("Enter Train_no for DeActivation: ");
            int no = Convert.ToInt32(Console.ReadLine());
            var ActTrain = RR.Trains.FirstOrDefault(tp => tp.Train_no == no);
            if (ActTrain != null)
            {
                if (ActTrain.Train_Status == true)
                {
                    ActTrain.Train_Status = false;
                    RR.SaveChanges();
                    Console.WriteLine($"\n=>Train_no {no} DeActivated...");
                }
                else
                {
                    Console.WriteLine($"\n=>Train_no {no} is already DeActivated...");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"\n=>Train_no {no} does not exist. So you can't Activate...");
            }

        }
        public static void Activate_Train()
        {
            Console.Write("Enter Train_no(Id) you want to Activate: ");
            int no = Convert.ToInt32(Console.ReadLine());

            var DeAct = RR.Trains.FirstOrDefault(td => td.Train_no == no);
            if (DeAct != null)
            {
                if (DeAct.Train_Status == false)
                {
                    DeAct.Train_Status = true;
                    RR.SaveChanges();
                    Console.WriteLine($"\n=>Train_no {no} Activated");

                }
                else
                {
                    Console.WriteLine($"\n=>Train_no {no} is already Activated...So you Can't Activate");
                }
               Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"Train_no {no} does not exist.........");
            }
        }
        public static void ReverseValue()
        {
            Console.WriteLine("Choose the Following Option:");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Modify Train");
            Console.WriteLine("3. Delete Train (Soft delete)");
            Console.WriteLine("4. Activate Train");
            Console.WriteLine("5.Show all Trains");
            Console.WriteLine("6.. Exit");
          
            int value = int.Parse(Console.ReadLine());
            
            ExecuteMenuChoice(value);


        }
    }
}
