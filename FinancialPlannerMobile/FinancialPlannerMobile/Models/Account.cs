using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile
{
    class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double CurrentBalance { get; set; }
        public DateTimeOffset Created { get; set; }
        public decimal InterestRate { get; set; }
        public int AccountTypeId { get; set; }
        public int BudgetId { get; set; }
        public int HouseholdId { get; set; }
        public bool IsDeleted { get; set; }

        public Account()
        {
            this.Id = 0;
            this.Name = "";
            this.Balance = 0;
            this.CurrentBalance = 0;
            this.Created = DateTime.Now;
            this.InterestRate = 0;
            this.AccountTypeId = 0;
            this.BudgetId = 0;
            this.HouseholdId = 0;
            this.IsDeleted = false;
        }
    }
}
