using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialPlannerMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountList : ContentPage
	{

        public AccountList ()
		{
			InitializeComponent ();

            //GetAccounts();

            var refreshViewModel = new RefreshViewModel();
            this.BindingContext = refreshViewModel;

            //lstAccounts.IsPullToRefreshEnabled = true;
            //lstAccounts.RefreshCommand = refreshViewModel.RefreshCommand;

        }

        private async void GetAccounts()
        {
            var accountCore = new AccountCore();

            List<Account> accounts = await accountCore.GetAccounts();


            ObservableCollection<Account> accountList = new ObservableCollection<Account>();

            foreach(var item in accounts)
            {
                accountList.Add(item);
            }

            this.BindingContext = accountList;
            lstAccounts.ItemsSource = accountList;
        }


        async void RefreshAccounts()
        {
            var accountCore = new AccountCore();

            List<Account> accounts = await accountCore.GetAccounts();


            ObservableCollection<Account> accountList = new ObservableCollection<Account>();

            foreach (var item in accounts)
            {
                accountList.Add(item);
            }

            lstAccounts.ItemsSource = accountList;
        }


        private async void lstAccounts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var account = (Account)e.Item;
            var nextPage = new SingleAccount(account.Id);
            await this.Navigation.PushAsync(nextPage);
        }

        private async void MnuItemAccounts_Activated(object sender, EventArgs e)
        {
            var nextPage = new CreateAccount();
            await this.Navigation.PushAsync(nextPage);
        }
    }
}