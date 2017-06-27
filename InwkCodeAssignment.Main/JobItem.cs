using System;

namespace InnerWorkingsCodeAssignment
{
    public class JobItem
    {
        public string Description { get; private set; }
        public decimal Cost { get; private set; }
        public bool IsTaxExempt { get; private set; }
        public decimal SalesTaxRate { get; private set; }

        public decimal Price
        {
            get
            {
                return IsTaxExempt 
                    ? Cost 
                    : Math.Round(Cost.AddPercentage(SalesTaxRate), 2);
            }
        }

        public JobItem(string description, decimal cost, bool isTaxExempt)
        {
            Description = description;
            Cost = cost;
            IsTaxExempt = isTaxExempt;
            SalesTaxRate = 0.07m;
        }
    }
}
