using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class DropTransaction : Transaction
    {
        public int taxiNum;
        public bool priceWasPaid;

        public DropTransaction(DateTime transactionDatetime, int taxiNum, bool priceWasPaid) : base("Drop fare", transactionDatetime)
        {
            this.taxiNum = taxiNum;
            this.priceWasPaid = priceWasPaid;
        }

        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            if (priceWasPaid == true)
            {
                return ($"{dateStr} Drop fare - Taxi {taxiNum}, price was paid");
            } else
            {
                return ($"{dateStr} Drop fare - Taxi {taxiNum}, price was not paid");
            }
        }
    }
}
