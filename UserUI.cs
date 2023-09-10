using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        public TaxiManager taxiMgr;
        public RankManager rankMgr;
        public TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> joinLogs = new List<string>();
            Taxi t = taxiMgr.CreateTaxi(taxiNum);

            if (rankMgr.AddTaxiToRank(t, rankId) == false)
            {
                joinLogs.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
            }
            else
            {
                rankMgr.AddTaxiToRank(t, rankId);
                joinLogs.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
            }

            return joinLogs;
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> leaveLogs = new List<string>();
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);

            if (t == null)
            {
                leaveLogs.Add($"Taxi has not left rank {rankId}.");
            }
            else
            {
                transactionMgr.RecordLeave(rankId, t);
                leaveLogs.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            }

            return leaveLogs;
        }

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> dropLogs = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxiNum);
            t.DropFare(pricePaid);

            if (t.Location == "in rank")
            {
                dropLogs.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            else
            {
                if (pricePaid == false)
                {
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    dropLogs.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                }
                else
                {
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                    dropLogs.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
                }

            }

            return dropLogs;
        }

        public List<string> ViewTaxiLocations()
        {
            List<string> taxiLocations = new List<string>();
            SortedDictionary<int, Taxi> allTaxis = taxiMgr.GetAllTaxis();

            taxiLocations.Add("Taxi locations");
            taxiLocations.Add("==============");

            if (allTaxis.Count == 0)
            {
                taxiLocations.Add("No taxis");
            }
            else
            {
                foreach (Taxi t in allTaxis.Values)
                {
                    if (t.Destination.Length > 0)
                    {
                        taxiLocations.Add($"Taxi {t.Number} is on the road to {t.Destination}");
                    }
                    else
                    {
                        if (t.Location == "in rank")
                        {
                            taxiLocations.Add($"Taxi {t.Number} is in rank {t.Rank.Id}");
                        }
                        else
                        {
                            taxiLocations.Add($"Taxi {t.Number} is on the road");
                        }
                    }

                }
            }
            return taxiLocations;
        }

        public List<string> ViewFinancialReport()
        {
            List<string> financialReport = new List<string>();
            SortedDictionary<int, Taxi> allTaxis = taxiMgr.GetAllTaxis();
            double totalPrice = 0;

            financialReport.Add("Financial report");
            financialReport.Add("================");

            if (allTaxis.Count == 0)
            {
                financialReport.Add("No taxis, so no money taken");
            }
            else
            {
                foreach (Taxi t in allTaxis.Values)
                {
                    financialReport.Add(string.Format($"Taxi {t.Number}      {t.TotalMoneyPaid:0.00}"));
                    totalPrice += t.TotalMoneyPaid;

                }
                financialReport.Add("           ======");
                financialReport.Add(string.Format($"Total:       {totalPrice:0.00}"));
                financialReport.Add("           ======");
            }

            return financialReport;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> transactionLog = new List<string>();
            List<Transaction> allTransaction = transactionMgr.GetAllTransactions();

            transactionLog.Add("Transaction report");
            transactionLog.Add("==================");

            if (allTransaction.Count == 0)
            {
                transactionLog.Add("No transactions");
            }
            else
            {
                foreach (Transaction tr in allTransaction)
                {
                    transactionLog.Add(tr.ToString());
                }
            }

            return transactionLog;
        }
    }
}
