using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerMobile
{
    class AccountCore
    {

        public async Task<List<Account>> GetAccounts()
        {
            List<Account> accounts;
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetAccounts/Json";
            string results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            if(results != null)
            {
                accounts = JsonConvert.DeserializeObject<List<Account>>(results);
                return accounts;
            }

            return null;
        }

        public async Task<Account> GetAccount(int accountId)
        {
            Account account;
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetAccount/Json?accountId=" + accountId;
            string results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            if (results != null)
            {
                account = JsonConvert.DeserializeObject<Account>(results);
                return account;
            }

            return null;
        }

        public async Task<AccountType> GetAccountType(int accountTypeId)
        {
            AccountType accountType = new AccountType();
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetAccountTypes";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<AccountType> test = results.ToObject<List<AccountType>>();

            if (results != null)
            {
                foreach(var item in test)
                {
                    if(item.Id == accountTypeId)
                    {
                        accountType.Id = item.Id;
                        accountType.Name = item.Name;
                    }
                }

                return accountType;
            }

            return null;
        }

        public async Task<Household> GetHousehold(int householdId)
        {
            Household household = new Household();
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetHousehold?householdId=" + householdId;
            JObject results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            if (results != null)
            {
                household = results.ToObject<Household>();
                return household;
            }

            return null;
        }

        public async Task<List<AccountType>> GetAccountTypes()
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetAccountTypes";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            List<AccountType> test = results.ToObject<List<AccountType>>();

            if (results != null)
            {
                return test;
            }

            return null;
        }

        public async Task<List<Household>> GetHouseholds()
        {
            List<Household> household = new List<Household>();
            string apiString = "http://jmplannerapi.azurewebsites.net:80/GetHouseholds";
            JArray results = await DataService.getDataFromService(apiString).ConfigureAwait(false);

            if (results != null)
            {
                household = results.ToObject<List<Household>>();
                return household;
            }

            return null;
        }

        public async Task<int> CreateAccount(string name, float balance, decimal interestRate, int typeId, int householdId)
        {
            string apiString = "http://jmplannerapi.azurewebsites.net:80/AddAccount?name=" + name + "&balance=" + balance + "&interestRate=" + interestRate + "&accountTypeId=" + typeId + "&householdId=" + householdId;
            var result = await DataService.setDataFromService(apiString).ConfigureAwait(false);

            if(result == true)
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
