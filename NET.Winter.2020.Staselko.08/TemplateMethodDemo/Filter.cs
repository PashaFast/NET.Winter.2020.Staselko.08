using System;
using System.Collections.Generic;

namespace TemplateMethodDemo
{
    public abstract class Filter
    {
        public int[] FilterByKey(int[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            List<int> result = new List<int>();

            foreach (var t in source)
            {
                if (IsMatch(t))
                {
                    result.Add(t);
                }
            }

            return result.ToArray();
        }

        protected abstract bool IsMatch(int number);
    }
}
