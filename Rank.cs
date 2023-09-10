using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        public int Id;
        public int numberOfTaxiSpaces;
        public List<Taxi> taxiSpace;

        public Rank(int rankId, int numberOfTaxiSpaces) 
        {
            Id = rankId;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;
            taxiSpace = new List<Taxi>(numberOfTaxiSpaces);
        }

        public bool AddTaxi(Taxi t)
        {
            if (numberOfTaxiSpaces == 0)
            {
                return false;
            } else
            {
                t.Rank = this;
                taxiSpace.Add(t);
                numberOfTaxiSpaces--;
                return true;
            }
        }

        public Taxi FrontTaxiTakesFare(string destination, double argeedPrice)
        {
            if (taxiSpace.Count == 0)
            {
                return null;
            } else
            {
                Taxi t = taxiSpace[0];
                t.AddFare(destination, argeedPrice);
                taxiSpace.RemoveAt(0);
                numberOfTaxiSpaces++;
                return t;
            }
            
        }
    }
}
