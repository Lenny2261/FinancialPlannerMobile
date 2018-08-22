using FinancialPlannerMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile.ViewModels
{
    class TransactionViewModel
    {
        public List<TransactionType> transactionTypes { get; set; }
        public List<TransactionStatus> transactionStatuses { get; set; }
        public List<SubCategories> subCategories { get; set; }
    }
}
