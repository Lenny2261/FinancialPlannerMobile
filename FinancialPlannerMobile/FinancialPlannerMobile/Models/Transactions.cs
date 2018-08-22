using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile.Models
{
    class Transactions
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Amount { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public int SubCategoryId { get; set; }
        public int TransactionStatusId { get; set; }
        public string TypeName { get; set; }
        public string StatusName { get; set; }

        public Transactions()
        {
            this.Id = 0;
            this.Description = "";
            this.From = "";
            this.Date = DateTimeOffset.Now;
            this.Amount = 0;
            this.AccountId = 0;
            this.TransactionTypeId = 0;
            this.TransactionStatusId = 0;
            this.SubCategoryId = 0;
            this.TypeName = "";
            this.StatusName = "";
        }

    }
}
