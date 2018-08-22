using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile
{
    class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AccountType()
        {
            this.Id = 0;
            this.Name = "";
        }
    }
}
