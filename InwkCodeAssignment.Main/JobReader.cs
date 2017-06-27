﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InnerWorkingsCodeAssignment
{
    public class JobReader
    {
        private List<string> _contents;

        public JobReader(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            try
            {
                _contents = File.ReadAllLines(fileName).ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to load input file {fileName}.", e);
            }
        }

        public JobProperties LoadProperties()
        {
            var isExtraMargin = false;
            var items = new List<JobItem>();

            foreach (var line in _contents)
            {
                if (string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line))
                    continue;

                if (line.Equals("extra-margin", StringComparison.CurrentCultureIgnoreCase))
                {
                    isExtraMargin = true;
                    continue;
                }

                var elements = line.Split(' ');

                var description = elements[0];
                var cost = Convert.ToDecimal(elements[1]);
                var isTaxExempt = elements.Length > 2 && elements[2].Equals("exempt", StringComparison.CurrentCultureIgnoreCase);
                var newItem = new JobItem(description, cost, isTaxExempt);

                items.Add(newItem);
            }

            return new JobProperties(items, isExtraMargin: isExtraMargin);
        }
    }
}
