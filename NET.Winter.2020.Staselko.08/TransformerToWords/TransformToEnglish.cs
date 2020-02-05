using System;
using System.Collections.Generic;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Class TransformToEnglish inheritor of Transformer.
    /// </summary>
    public class TransformToEnglish : Transformer
    {
        /// <summary>
        /// Gets property.
        /// </summary>
        protected override Dictionary<char, string> Dictionary { get; } = new Dictionary<char, string>
                {
                { '-', "minus" },
                { '.', "point" },
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { 'E', "E" },
                { '+', "plus" },
                };

        /// <summary>
        /// Gets property.
        /// </summary>
        protected override Dictionary<double, string> SpecialDictionary { get; } = new Dictionary<double, string>
                {
                { double.NaN, "Not a number" },
                { double.Epsilon, "Epsilon" },
                { double.NegativeInfinity, "Negative infinity" },
                { double.PositiveInfinity, "Positive infinity" },
                { 0, "zero" },
                };
    }
}
