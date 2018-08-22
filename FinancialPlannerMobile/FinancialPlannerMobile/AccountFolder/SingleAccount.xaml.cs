using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialPlannerMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SingleAccount : ContentPage
	{
         private int accountId = 0; 

		public SingleAccount (int accountId)
		{
			InitializeComponent ();

            GetAccount(accountId);

            this.accountId = accountId;

		}

        private async void GetAccount(int accountId)
        {
            var accountViewModel = new AccountViewModel();
            var accountCore = new AccountCore();

            Account account = await accountCore.GetAccount(accountId);
            accountViewModel.Name = account.Name;
            accountViewModel.CurrentBalance = account.CurrentBalance;
            accountViewModel.InterestRate = account.InterestRate;

            AccountType accountType = await accountCore.GetAccountType(account.AccountTypeId);
            accountViewModel.AccountTypeName = accountType.Name;

            Household household = await accountCore.GetHousehold(account.HouseholdId);
            accountViewModel.HouseholdName = household.Name;

            BindingContext = accountViewModel;
        }

        private async void MnuItemTransactions_Activated(object sender, EventArgs e)
        {
            var nextPage = new TransactionList(accountId);
            await this.Navigation.PushAsync(nextPage);
        }
    }
}