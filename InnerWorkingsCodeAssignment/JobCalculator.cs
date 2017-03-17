using InnerWorkingsCodeAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerWorkingsCodeAssignment
{
    public class JobCalculator : IJobCalculator
    {
        private readonly JobProperties JobProperties;
        private readonly IEnumerable<JobItem> Items;

        public JobCalculator(JobProperties jobProperties)
        {
            if (jobProperties == null)
                throw new ArgumentNullException(nameof(jobProperties));

            JobProperties = jobProperties;
            Items = JobProperties.Items;
        }

        public decimal Total
        {
            get
            {
                var totalItemCost = Items.Sum(x => x.Cost);
                var totalItemPrice = Items.Sum(x => x.Price);

                var margin = totalItemCost * JobProperties.EffectiveMarginRate;

                var result = Math.Round((totalItemPrice + margin) / 2m, 2) * 2m;

                return result;
            }
        }

        public string Output
        {
            get
            {
                return string.Concat(Items.Select(x => $"{x.Description}: ${x.Price:F2}\n"))
                    + $"total: ${Total:F2}";
            }
        }
    }
}
