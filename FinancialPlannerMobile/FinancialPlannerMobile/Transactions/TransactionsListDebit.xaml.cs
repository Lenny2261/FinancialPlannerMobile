using FinancialPlannerMobile.ViewModels;
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
	public partial class TransactionsListDebit : ContentPage
	{
        private int accountId = 0;

		public TransactionsListDebit (int accountId)
		{
			InitializeComponent ();

            this.accountId = accountId;

            var refreshViewModel = new TransactionRefreshViewModel(accountId, 0);
            this.BindingContext = refreshViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var nextPage = new TransactionList(accountId);
            await this.Navigation.PushAsync(nextPage);
            this.Navigation.RemovePage(this);
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            var nextPage = new TransactionListCredit(accountId);
            await this.Navigation.PushAsync(nextPage);
            this.Navigation.RemovePage(this);
        }

        private async void Button_Clicked3(object sender, EventArgs e)
        {
            var nextPage = new TransactionListVoid(accountId);
            await this.Navigation.PushAsync(nextPage);
            this.Navigation.RemovePage(this);
        }

        private async void MnuItemTransactions_Activated(object sender, EventArgs e)
        {
            var nextPage = new CreateTransaction(accountId);
            await this.Navigation.PushAsync(nextPage);
        }
    }
}