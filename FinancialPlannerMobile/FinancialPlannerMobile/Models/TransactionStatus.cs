using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile.Models
{
    class TransactionStatus
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public TransactionStatus()
        {
            this.Id = 0;
            this.Name = "";
        }

    }
}
