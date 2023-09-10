using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
     public class TransactionManager
    {
        public List<Transaction> transactions = new List<Transaction>();

        public void RecordJoin(int taxiNum, int rankId)
        {
            Transaction joinTransaction = new JoinTransaction(DateTime.Now, taxiNum, rankId);
            transactions.Add(joinTransaction);
        }

        public void RecordLeave(int rankId, Taxi t)
        {
            Transaction leaveTransaction = new LeaveTransaction(DateTime.Now, rankId, t);
            transactions.Add(leaveTransaction);
        }

        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            Transaction dropTransaction = new DropTransaction(DateTime.Now, taxiNum, pricePaid);
            transactions.Add(dropTransaction);
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
    }
}
