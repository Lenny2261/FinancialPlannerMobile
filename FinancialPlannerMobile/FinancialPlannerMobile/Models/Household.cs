using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlannerMobile
{
    class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Household()
        {
            this.Id = 0;
            this.Name = "";
        }
    }
}
