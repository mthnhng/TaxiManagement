using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        public Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

        public RankManager()
        {
            ranks.Add(1, new Rank(1, 5));
            ranks.Add(2, new Rank(2, 2));
            ranks.Add(3, new Rank(3, 4));
        }

        public Rank FindRank(int rankId)
        {
            if (ranks.ContainsKey(rankId) == true)
            {
                return ranks[rankId];
            }
            else
            {
                return null;
            }
        }

        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            if (ranks.ContainsKey(rankId) == false)
            {
                return false;
            }
            else if (ranks.ContainsValue(t.Rank) == true)
            {
                return false;
            }
            else if (t.Rank == ranks[rankId])
            {
                return false;
            }
            else if (t.Destination.Length > 0)
            {
                return false;
            }
            else
            {
                return ranks[rankId].AddTaxi(t);
            }
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {

            if (ranks.ContainsKey(rankId) == false)
            {
                return null;
            } else if (ranks[rankId].taxiSpace.Count == 0)
            {
                return null;
            } else
            {
                return ranks[rankId].FrontTaxiTakesFare(destination, agreedPrice);
            }
        }
    }
}
