using System;

namespace TaxiManagementAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxiManager taxiMgr = new TaxiManager();
            RankManager rankMgr = new RankManager();
            TransactionManager transactionMgr = new TransactionManager();

            UserUI user = new UserUI(rankMgr, taxiMgr, transactionMgr);

            Console.WriteLine("Welcome to the Taxi Management Programme!\n");

            while (true) {
                Console.WriteLine("\nPlease select one of these options below:\n" + "1. Add Taxi \n" + "2. Leave Rank \n" + "3. Drop Fare \n" + "4. View Financial Report \n" + "5. View Transaction Log \n" + "6. View Taxi Location \n" + "7. End Programme \n\n");
                Console.Write("Enter a number from 1 to 6 and 7 to end programme: ");
                int userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput <= 0 || userInput > 7)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                } else
                {
                    if (userInput == 1)
                    {
                        Console.Write("Please input taxi number: ");
                        int tNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Please input rank ID: ");
                        int rkId = Convert.ToInt32(Console.ReadLine());

                        foreach (string joinLogs in user.TaxiJoinsRank(tNum, rkId))
                        {
                            Console.WriteLine(joinLogs);
                        }
                    }
                    else if (userInput == 2)
                    {
                        Console.Write("Please input rank ID: ");
                        int rkId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Please input the destination: ");
                        string des = Console.ReadLine();

                        Console.Write("Please input your agreed price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        foreach (string leaveLogs in user.TaxiLeavesRank(rkId, des, price))
                        {
                            Console.WriteLine(leaveLogs);
                        }
                    }
                    else if (userInput == 3)
                    {
                        Console.Write("Please input taxi number: ");
                        int tNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Have you paid? ");
                        string pricePaid = Console.ReadLine();

                        if (pricePaid == "yes" || pricePaid == "Yes")
                        {
                            bool prPaid = true;
                            foreach (string dropLogs in user.TaxiDropsFare(tNum, prPaid))
                            {
                                Console.WriteLine(dropLogs);
                            }
                        } 
                        else if (pricePaid == "no" || pricePaid == "No")
                        {
                            bool prPaid = false;
                            foreach (string dropLogs in user.TaxiDropsFare(tNum, prPaid))
                            {
                                Console.WriteLine(dropLogs);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                    else if (userInput == 4)
                    {
                        foreach (string financialReport in user.ViewFinancialReport())
                        {
                            Console.WriteLine(financialReport);
                        }
                    }
                    else if (userInput == 5)
                    {
                        foreach (string transactionLog in user.ViewTransactionLog())
                        {
                            Console.WriteLine(transactionLog);
                        }
                    }
                    else if (userInput == 6)
                    {
                        foreach (string taxiLocations in user.ViewTaxiLocations())
                        {
                            Console.WriteLine(taxiLocations);
                        }
                    }
                    else if (userInput == 7)
                    {
                        Console.WriteLine("End programme.");
                        break;
                    }
                }
            }
            
        }
    }
}