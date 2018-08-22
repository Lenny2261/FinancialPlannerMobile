using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile
{
    class AccountViewModel
    {
        public string Name { get; set; }
        public double CurrentBalance { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountTypeName { get; set; }
        public string HouseholdName { get; set; }
    }

    class CreateAccountViewModel
    {
        public List<AccountType> accountTypes { get; set; }
        public List<Household> households { get; set; }
    }
}
