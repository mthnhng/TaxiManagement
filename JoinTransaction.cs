using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class JoinTransaction : Transaction
    {
        public int taxiNum;
        public int rankId;

        public JoinTransaction(DateTime transactionDatetime, int taxiNum, int rankId) : base("Join", transactionDatetime)
        {
            this.taxiNum = taxiNum;
            this.rankId = rankId;

        }

        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return ($"{dateStr} Join      - Taxi {taxiNum} in rank {rankId}");
        }
    }
}
