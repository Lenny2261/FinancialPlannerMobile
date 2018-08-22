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
	public partial class CreateAccount : ContentPage
	{

        private Dictionary<string, int> accountTypes = new Dictionary<string, int>();
        private Dictionary<string, int> households = new Dictionary<string, int>();

        public CreateAccount ()
		{
			InitializeComponent ();

            GetAccountInfo();
		}

        private async void GetAccountInfo()
        {
            var info = new CreateAccountViewModel();
            var accountCore = new AccountCore();

            List<string> typeName = new List<string>();
            List<string> householdName = new List<string>();

            info.accountTypes = await accountCore.GetAccountTypes();
            info.households = await accountCore.GetHouseholds();

            foreach (var item in info.accountTypes)
            {
                accountTypes.Add(item.Name, item.Id);
                typeName.Add(item.Name);
            }

            foreach(var item in info.households)
            {
                households.Add(item.Name, item.Id);
                householdName.Add(item.Name);
            }

            accountType.ItemsSource = typeName;
            householdPicker.ItemsSource = householdName;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var accountCore = new AccountCore();

            if(accountType.SelectedItem != null && householdPicker.SelectedItem != null && balance.Text != null
                && accountName.Text != null && interestRate.Text != null)
            {
                int typeId = accountTypes.Where(t => t.Key == accountType.SelectedItem.ToString()).FirstOrDefault().Value;
                int householdId = households.Where(t => t.Key == householdPicker.SelectedItem.ToString()).FirstOrDefault().Value;

                int result = await accountCore.CreateAccount(accountName.Text, float.Parse(balance.Text), Convert.ToDecimal(interestRate.Text), typeId, householdId);

                if (result != -1)
                {
                    await DisplayAlert("Failed", "Account not added", "OK");
                }
                else
                {
                    await DisplayAlert("Success", "Account has been added", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Failed", "Account not added", "OK");
            }

        }
    }
}