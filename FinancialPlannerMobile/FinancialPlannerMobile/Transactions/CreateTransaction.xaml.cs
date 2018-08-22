using FinancialPlannerMobile.Models;
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
	public partial class CreateTransaction : ContentPage
	{
        private int accountId = 0;
        private Dictionary<string, int> statuses = new Dictionary<string, int>();
        private Dictionary<string, int> types = new Dictionary<string, int>();
        private Dictionary<string, int> subCats = new Dictionary<string, int>();

        public CreateTransaction (int accountId)
		{
			InitializeComponent ();

            this.accountId = accountId;
            GetTransactionInfo();
		}

        private async void GetTransactionInfo()
        {
            var info = new TransactionViewModel();
            var transactionCore = new TransactionCore();

            List<string> typeName = new List<string>();
            List<string> statusName = new List<string>();
            List<string> subCatName = new List<string>();

            info.subCategories = await transactionCore.GetSubCategories();
            info.transactionStatuses = await transactionCore.GetTransactionStatus();
            info.transactionTypes = await transactionCore.GetTransactionType();

            foreach (var item in info.subCategories)
            {
                subCats.Add(item.Name, item.Id);
                subCatName.Add(item.Name);
            }

            foreach (var item in info.transactionStatuses.Where(s => s.Name != "Void"))
            {
                statuses.Add(item.Name, item.Id);
                statusName.Add(item.Name);
            }

            foreach (var item in info.transactionTypes)
            {
                types.Add(item.Name, item.Id);
                typeName.Add(item.Name);
            }

            subCat.ItemsSource = subCatName;
            status.ItemsSource = statusName;
            type.ItemsSource = typeName;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var transactionCore = new TransactionCore();

            if (type.SelectedItem != null && status.SelectedItem != null && amount.Text != null
                && subCat.SelectedItem != null && from.Text != null && date.Date != null)
            {
                int typeId = types.Where(t => t.Key == type.SelectedItem.ToString()).FirstOrDefault().Value;
                int statusId = statuses.Where(t => t.Key == status.SelectedItem.ToString()).FirstOrDefault().Value;
                int subCatId = subCats.Where(t => t.Key == subCat.SelectedItem.ToString()).FirstOrDefault().Value;

                int result = await transactionCore.CreateTransaction(des.Text, from.Text, float.Parse(amount.Text), date.Date.ToString(), accountId, typeId, statusId, subCatId);

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