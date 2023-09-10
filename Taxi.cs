using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagementAssignment
    {
    public class Taxi
    {
        public int Number;
        public double CurrentFare = 0;
        public string Destination = "";
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        public string Location = ON_ROAD;
        public double TotalMoneyPaid = 0;

        private Rank rank = null;
        public Rank Rank { get { return rank; } 
            set
            {
                if (Destination.Length > 0)
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                else if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }
                else
                {
                    rank = value;
                    Location = IN_RANK;
                }
            }
        }

        public Taxi(int num)
        {
            Number = num;
        }

        public void AddFare(string destination, double agreePrice)
        {
            rank = null;
            Destination = destination;
            CurrentFare = agreePrice;
            Location = ON_ROAD;
        }

        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid == false)
            {
                TotalMoneyPaid = 0;
            } else {
                Destination = "";
                TotalMoneyPaid += CurrentFare;
                CurrentFare = 0;
            }
        }


    }
}
