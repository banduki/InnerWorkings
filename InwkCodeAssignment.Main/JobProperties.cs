using System;
using System.Collections.Generic;

namespace InnerWorkingsCodeAssignment
{
    public class JobProperties
    {
        public decimal ExtraMarginRateAddend { get; private set; }
        public decimal StandardMarginRate { get; private set; }
        public decimal SalesTaxRate { get; private set; }
        public bool IsExtraMargin { get; private set; }
        public IEnumerable<JobItem> Items { get; set; }
        public decimal EffectiveMarginRate => 
            StandardMarginRate + (IsExtraMargin ? ExtraMarginRateAddend : 0m);

        public JobProperties(IEnumerable<JobItem> items, decimal salesTaxRate = 0.07m, decimal standardMarginRate = 0.11m, bool isExtraMargin = false, decimal extraMarginAddend = 0.05m)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            IsExtraMargin = isExtraMargin;
            ExtraMarginRateAddend = extraMarginAddend;
            StandardMarginRate = standardMarginRate;
            SalesTaxRate = salesTaxRate;
            Items = items;
        }
    }
}
