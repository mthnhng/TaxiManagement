using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();


        public Taxi FindTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum) == false)
            {
                return null;
            } else
            {
                return taxis[taxiNum];
            }
        }

        public Taxi CreateTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum) == true)
            {
                return taxis[taxiNum];
            } else
            {
                Taxi t = new Taxi(taxiNum);
                taxis.Add(taxiNum, t);
                return t;
            }
            
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
    }
}
