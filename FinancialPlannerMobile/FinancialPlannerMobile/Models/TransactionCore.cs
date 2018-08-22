using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerMobile.Models
{
    class TransactionCore
    {

        public async Task<List<Transactions>> GetTransactions(int accountId)
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetTransactions?accountID=" + accountId;
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<Transactions> transactions = results.ToObject<List<Transactions>>();

            if (results != null)
            {
                return transactions;
            }

            return null;
        }

        public async Task<List<TransactionType>> GetTransactionType()
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetTransactionTypes";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<TransactionType> transactionType = results.ToObject<List<TransactionType>>();

            if (results != null)
            {
                return transactionType;
            }

            return null;
        }

        public async Task<List<TransactionStatus>> GetTransactionStatus()
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetTransactionStatuses";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<TransactionStatus> transactionStatus = results.ToObject<List<TransactionStatus>>();

            if (results != null)
            {
                return transactionStatus;
            }

            return null;
        }

        public async Task<List<SubCategories>> GetSubCategories()
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetSubCategories";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<SubCategories> transactionStatus = results.ToObject<List<SubCategories>>();

            if (results != null)
            {
                return transactionStatus;
            }

            return null;
        }

        public async Task<int> CreateTransaction(string des, string from, float amount, string date, int accountId, int typeId, int statusId, int subCatId)
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/AddTransaction?description=" + des + "&from=" + from + "&date=" + date + "&amount=" + amount + "&accountId=" + accountId + "&transactionTypeId=" + typeId + "&subCategoryId=" + subCatId + "&transactionStatusId=" + statusId;
            var result = await DataService.setDataFromService(apiString).ConfigureAwait(false);

            if (result == true)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
