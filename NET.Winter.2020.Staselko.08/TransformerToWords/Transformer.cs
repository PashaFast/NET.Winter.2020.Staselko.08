using System;
using System.Collections.Generic;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Abstract class Transformer.
    /// </summary>
    public abstract class Transformer
    {
        /// <summary>
        /// Gets property.
        /// </summary>
        /// <value>
        /// Dictionary.
        /// </value>
        protected abstract Dictionary<char, string> Dictionary { get; }

        /// <summary>
        /// Gets property.
        /// </summary>
        /// <value>
        /// SpecialDictionary.
        /// </value>
        protected abstract Dictionary<double, string> SpecialDictionary { get; }

        /// <summary>
        /// Method for translating a number into its verbal format.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>Verbal format of number.</returns>
        public string TransformToWords(double number)
        {
            if (double.IsNaN(number) || number == double.Epsilon || double.IsNegativeInfinity(number)
                || double.IsPositiveInfinity(number) || number == 0)
            {
                return this.SpecialDictionary[number];
            }

            StringBuilder sb = new StringBuilder();

            string stringNumber = number.ToString();

            for (int i = 0; i < stringNumber.Length; i++)
            {
                sb.Append(this.Dictionary[stringNumber[i]]);
                if (i < stringNumber.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}
