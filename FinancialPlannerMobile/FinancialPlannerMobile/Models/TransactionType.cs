using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile.Models
{
    class TransactionType
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public TransactionType()
        {
            this.Id = 0;
            this.Name = "";
        }

    }
}
