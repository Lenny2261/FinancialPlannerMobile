using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace FinancialPlannerMobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        private async void MnuItemAccounts_Activated(object sender, EventArgs e)
        {
            var nextPage = new AccountList();
            await this.Navigation.PushAsync(nextPage);
        }
    }
}
