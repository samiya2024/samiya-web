using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Ticket_Booking.User_Section
{
    public class User_Access
    {
        static Railway_reservationEntities1 RR = new Railway_reservationEntities1();


        public static void U_Logged()
        {
            Console.WriteLine("Press 1 for Existing User:- ");
            Console.WriteLine("Press 2 new User:- ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("\t\t\t\t\t\tLogIn Your Account\t\t\t\t\t");
                    Console.WriteLine("Enter Id:- ");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Password:- ");
                    string Pass = Console.ReadLine();
                    var uid = RR.user_login.FirstOrDefault(ud => ud.user_Code == i1);
                    var upass = RR.user_login.FirstOrDefault(Upass => Upass.password == Pass);

                    if (uid != null && upass != null)
                    {
                        Console.WriteLine("\t\t\t\t\tYou have Logged In Successfully");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press Any key to Enter User Section.. :- ");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Choose between 1 to 4...");
                        Console.WriteLine("Press (1) for Book_Ticket ");
                        Console.WriteLine("Press (2) for  Ticket Cancell ");
                        Console.WriteLine("Press (3) for Train_detailss ");
                        Console.WriteLine("Press (4) for Available Seats");
                        Console.WriteLine("Press (5) for Exit");
                        int val = Convert.ToInt32(Console.ReadLine());
                        switch (val)
                        {
                            case 1:
                                Show_TrainData();
                                Console.WriteLine("\n");
                              
                                Console.WriteLine("\t\t\t\t\tSeat Details\t\t\t\t\t\n");
                                Avail_Seats();
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                                Console.WriteLine("Enter the number of Ticket...Maximum you can book (5)");
                                int Ntkt = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n");
                                Console.WriteLine("\t\t\t\t\t.......Ticket Booking Portal....\n");
                                if (Ntkt < 6 && Ntkt >= 1)
                                {
                                    for (int i = 1; i <= Ntkt; i++)
                                    {
                                        Book_Tickets();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter Correct Ticket Numbers");
                                }
                                Reaverse_val();
                                break;

                            case 2:
                                Ticket_Cancellation();
                                printCancelledTickets();
                                Reaverse_val();
                                break;
                            case 3:
                                Show_TrainData();
                                Reaverse_val();
                                break;
                            case 4:
                                Avail_Seats();
                                break;
                            case 5:
                                Console.WriteLine("You have been Logged Out from the Application..");
                                break;
                            default:
                                Console.WriteLine("Wrong Input");
                                break;


                        }
                    }
                    else
                    {
                        Console.Write("(Error): This account doesn't Exist... To login Again press=>(a) and Enter ");
                        Console.WriteLine("Or press=>(b) for Create your Account");
                        Console.Write("Choice:> ");
                        string New_u_or_Ext = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("=====================================================================================================>");

                        switch (New_u_or_Ext)
                        {
                            case "a":
                                Console.WriteLine("\n");
                                L_Again();
                                break;

                            case "b":
                                Account_Creation();
                                Console.WriteLine("\n");
                                Console.WriteLine("=====================================================================================================>");
                                L_Again();
                                break;
                            default:
                                Console.WriteLine("Invalid Input...");
                                break;
                        }
                    }
                    break;

                case 2:
                    Account_Creation();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    L_Again();

                    break;

                default:
                    Console.WriteLine("Wrong Input....");
                    break;


            }

        }

        public static void Book_Tickets()
        {
            Booked_Tickets BT1 = new Booked_Tickets();
            Console.Write("Enter Name: ");
            string PName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Gender: ");
            string PGn = Console.ReadLine() + "\n";
            Console.WriteLine("Enter Train_No Which You want for Booking: ");
            int PId = Convert.ToInt32(Console.ReadLine() + "\n");
            Console.WriteLine("Enter Your Class((1AC/2AC/SL)):");
            String CL = Console.ReadLine();


            var T_book = RR.Trains.FirstOrDefault(Ad => Ad.Train_no == PId);

            Random Rn = new Random();

            int Tkt_id = Rn.Next(2000, 11500) + 102;
            if (T_book != null)
            {
                if (T_book.Train_Status == true)
                {
                    BT1.Ticket_Id = Tkt_id;
                    BT1.Train_no = PId;
                    BT1.Passenger_Name = PName;
                    BT1.Gender = PGn;
                    BT1.Class = CL;


                    RR.Booked_Tickets.Add(BT1);

                    RR.SaveChanges();

                    Console.WriteLine("\t\t\t\t......Your Ticket is Successfully Booked......");
                    RR.RemoveSeat(PId, CL);
                    //Now update Fare and availabilty
                    var Fdetail = RR.Fare_S;
                    Fare_S f_det = new Fare_S();

                    Console.WriteLine("\t\t\t\t>>>..Detail of the Ticket..<<<\n");
                    Console.WriteLine($"Train_Id:- {PId}");
                    Console.WriteLine($"Name:- {PName} ");
                    Console.WriteLine($"Gender:- {PGn}");
                    Console.WriteLine($"Ticket_Id:- {Tkt_id} ");
                    Console.WriteLine($"PNR_Number:- {Rn.Next(14450, 60450)}");
                    foreach (var Fn in Fdetail)
                    {
                        if (Fn.Train_id == PId)
                        {

                            if (CL == "1ac" || CL == "1AC" || CL == "1Ac")
                            {
                                Console.WriteLine($"Price_of_Ticket: {Fn.First_ACf}");
                            }
                            if (CL == "2ac" || CL == "2AC" || CL == "2Ac")
                            {
                                Console.WriteLine($"Price_of_Ticket: {Fn.Second_ACf}");
                            }
                            if (CL == "sl" || CL == "SL" || CL == "Sl")
                            {
                                Console.WriteLine($"Price_of_Ticket: {Fn.Sleeperf}");
                            }

                        }
                    }
                }
                else
                {
                    Console.Write("You Cannot Book this ticket,It's Inactive Currently!!!");

                }
            }

            else
            {
                Console.WriteLine("You can't Book the Ticket...because Trainno doesn't Exist ");
            }

        }



        public static void Show_TrainData()
        {
            Console.WriteLine("\t\t\t\t\t\t---------------Train Details-----------------------------\n\n");
            var Std = RR.Trains;
            int k = 1;

            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("|    Train No.   |    Train Name   |    Source    |    Destination    |    Status        |");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (var B in Std)
            {
                if (B.Train_Status == true)
                {
                    Console.WriteLine($"|      {B.Train_no,-10} | {B.Train_name,-19} | {B.Source_loc,-14} | {B.Destination,-14} | {B.Train_Status,-10} |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");

                    k++;
                }
            }
        }



        public static void Ticket_Cancellation()
        {
            

            var Prt = RR.Booked_Tickets;
            foreach (var T in Prt)
            {
                Console.WriteLine("=>");

                Console.WriteLine($"Train_No:- {T.Train_no}");
                Console.WriteLine($"Ticket Id:- {T.Ticket_Id}");
                Console.WriteLine($"Passenger Name:- {T.Passenger_Name}");
                Console.Write($"Gender:- {T.Gender}");
                Console.WriteLine($"Berth_Class:- {T.Class}");

                Console.WriteLine("-----------------------------------------------");
            }



            Fare_S fs = new Fare_S();

            Cancellation_Data cd = new Cancellation_Data();
            Console.WriteLine("\t\t\t\t\t\t*Ticket Cancellation" + "*\n\n");
            Console.Write("Enter Train Number: ");
            int PId = Convert.ToInt32(Console.ReadLine() + "\n");
            Console.Write("Enter your Ticket_Id: ");
            int Tkt_id = Convert.ToInt32(Console.ReadLine() + "\n");
            Console.WriteLine("Enter Your Class:- ");
            string Cl = Console.ReadLine();
            Random Tc = new Random();
            int cid = Tc.Next(7000, 10000);
            String sts = "Canceled";


            var VCl = RR.Booked_Tickets.FirstOrDefault(vc => vc.Class == Cl);

            var Tkt_Cancel1 = RR.Booked_Tickets.Where(m => m.Ticket_Id == Tkt_id).Select(t => t.Class).FirstOrDefault();
            var Tkt_Cancel2 = RR.Booked_Tickets.FirstOrDefault(m1 => m1.Ticket_Id == Tkt_id);


            if (Tkt_Cancel1 != null && VCl != null)
            {
                cd.Canc_ID = cid;
                cd.Train_no = PId;
                cd.Ticket_ID = Tkt_id;
                cd.Canc_Date = DateTime.Now;
                cd.Status = sts;


                var FareS = RR.Fare_S;

                foreach (var RAmt in FareS)


                    if (RAmt.Train_id == PId)
                    {

                        if (Cl == "1ac" || Cl == "1AC" || Cl == "1Ac")
                        {
                            cd.Refund_Amount = (int)RAmt.First_ACf - 500;
                        }
                        if (Cl == "2ac" || Cl == "2AC" || Cl == "2Ac")
                        {
                            cd.Refund_Amount = (int)RAmt.Second_ACf - 500;
                        }
                        if (Cl == "sl" || Cl == "SL" || Cl == "Sl")
                        {
                            cd.Refund_Amount = (int)RAmt.Sleeperf;
                        }

                    }

                RR.Cancellation_Data.Add(cd);
                RR.Booked_Tickets.Remove(Tkt_Cancel2);
                Console.WriteLine("\t\t\t\t**Your Ticket has been Canceled successfully.**\n");

                RR.SaveChanges();
                RR.AddSeat(PId, Cl);
                RR.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ticket Cannot be cancelled,You entered wrong Information");
            }


        }

        public static void Avail_Seats()
        {
            var Aseat = RR.Available_Seats;
            
            //var Ts = RR.Trains;
            
                foreach (var st in Aseat)
                {
                    

                        Console.WriteLine($"T number : {st.Train_No}\t FirstAc_Seat count: {st.First_AC}\t\tSecondAc_Seat count :{st.Second_AC} \t Sleeper Seat_count :{st.Sleeper}");
                        Console.WriteLine("\n");
                }


        }

        public static void Account_Creation()
        {
            user_login ut1 = new user_login();
            Console.WriteLine("Enter new user Id: ");
            ut1.user_Code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password:- ");
            ut1.password = Console.ReadLine();


            RR.user_login.Add(ut1);
            RR.SaveChanges();
            Console.WriteLine("Account is Created Successfully..............");

        }

        public static void L_Again()
        {
            Console.WriteLine("\t\t\t\t\t\tLogIn Your Account");
            Console.WriteLine("Enter Id:- ");
            int i1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password:- ");
            string Pass = Console.ReadLine();
            var uid = RR.user_login.FirstOrDefault(ud => ud.user_Code == i1);
            var upass = RR.user_login.FirstOrDefault(Upass => Upass.password == Pass);

            if (uid != null && upass != null)
            {
                Console.WriteLine("\t\t\t\t\tYou have Logged In Successfully");
                Console.WriteLine("Press Any key to Enter User Section.. :- ");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Choose between 1 to 4...");
                Console.WriteLine("Press (1) for Book_Ticket ");
                Console.WriteLine("Press (2) for  Ticket Cancell ");
                Console.WriteLine("Press (3) for Train_detailss ");
                Console.WriteLine("Press (4) for Available Seats");
                Console.WriteLine("Press (5) for Exit");
                int val = Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        Show_TrainData();
                        Console.WriteLine("\n");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                        Console.WriteLine("Seat Details....\n");
                        Avail_Seats();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                        Console.WriteLine("Enter the number of Ticket...Maximum you can book (5)");
                        int Ntkt = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\t\t\t\t\t.......Ticket Booking Portal....\n");
                        if (Ntkt < 6 && Ntkt >= 1)
                        {
                            for (int i = 1; i <= Ntkt; i++)
                            {
                                Book_Tickets();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter Correct Ticket Numbers");
                        }
                        break;

                    case 2:
                        Ticket_Cancellation();
                        
                        break;
                    case 3:
                        Show_TrainData();
                        break;
                    case 4:
                        Avail_Seats();
                        break;
                    case 5:
                        Console.WriteLine("You have been Logged out from The Application....");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;


                }
            }
            else
            {
                Console.Write("(Error): This account doesn't Exist... To login Again press=>(a) and Enter ");
                Console.WriteLine("Or press=>(b) for Create your Account");
                Console.Write("Choice:> ");
                string New_u_or_Ext = Convert.ToString(Console.ReadLine());
                Console.WriteLine("=====================================================================================================>");

                switch (New_u_or_Ext)
                {
                    case "a":
                        Console.WriteLine("\n");
                        L_Again();
                        break;

                    case "b":
                        Account_Creation();
                        Console.WriteLine("\n");
                        Console.WriteLine("=====================================================================================================>");
                        L_Again();
                        break;
                    default:
                        Console.WriteLine("Invalid Input...");
                        break;
                }
            }


        }

        public static void printCancelledTickets()
        {
            var cancelledTickets = RR.Cancellation_Data;

            Console.WriteLine("===========================================================================================");
            Console.WriteLine("| Cancellation ID | Train Number | Ticket ID | Cancellation Date | Status | Refund Amount |");
            Console.WriteLine("===========================================================================================");

            foreach (var ticket in cancelledTickets)
            {
                Console.WriteLine($"| {ticket.Canc_ID,-16} | {ticket.Train_no,-12} | {ticket.Ticket_ID,-9} | {ticket.Canc_Date,-18} | {ticket.Status,-6} | {ticket.Refund_Amount,-13} |");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public static void Reaverse_val()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Choose between 1 to 4...");
            Console.WriteLine("Press (1) for Book_Ticket ");
            Console.WriteLine("Press (2) for  Ticket Cancell ");
            Console.WriteLine("Press (3) for Train_detailss ");
            Console.WriteLine("Press (4) for Available Seats ");
            Console.WriteLine("Press (5) for Exit");
            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    Show_TrainData();
                    Console.WriteLine("\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                    Console.WriteLine("Seat Details....\n");
                    Avail_Seats();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                    Console.WriteLine("Enter the number of Ticket...Maximum you can book (5)");
                    int Ntkt = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\t\t\t\t\t.......Ticket Booking Portal....\n");
                    if (Ntkt < 6 && Ntkt >= 1)
                    {
                        for (int i = 1; i <= Ntkt; i++)
                        {
                            Book_Tickets();
                        }
                       

                    }
                    else
                    {
                        Console.WriteLine("Enter Correct Ticket Numbers");
                            

                    }
                    Reaverse_val();
                    break;

                case 2:
                    Ticket_Cancellation();
                    Reaverse_val();
                    break;
                case 3:
                    Show_TrainData();
                    Reaverse_val();
                    break;
                case 4:
                    Avail_Seats();
                    break;
                case 5:
                    Console.WriteLine("You have been Logged Out from the Application..");
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;


            }
        }
        }
    }
