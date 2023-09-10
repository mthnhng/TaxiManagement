using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime;
        public string TransactionType;

        public Transaction(string type, DateTime dt)
        {
            TransactionType = type;
            TransactionDatetime = dt;
        }
    }
}
