using System;

namespace TemplateMethodDemo
{
    /// <summary>
    /// Class TemplateMethodByKey inheritance from Filter.
    /// </summary>
    public class TemplateMethodByKey : Filter
    {
        private static int digit;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateMethodByKey"/> class.
        /// Contructor with one parametr.
        /// </summary>
        /// <param name="digit">The digit by which we will filter.</param>
        public TemplateMethodByKey(int digit)
        {
            Digit = digit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateMethodByKey"/> class.
        /// Constructor without parameters.
        /// </summary>
        public TemplateMethodByKey()
        {
            Digit = 0;
        }

        /// <summary>
        /// Gets or sets property.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when digit less 0 or more 9.</exception>
        /// <value>
        /// Digit.
        /// </value>
        public static int Digit
        {
            get
            {
                return digit;
            }

            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "digit must be >=0 and <=9");
                }
                else
                {
                    digit = value;
                }
            }
        }

        /// <summary>
        /// overridden method IsMatch.
        /// </summary>
        /// <param name="number">Number for filter.</param>
        /// <returns>Returns true if the digit is present in the number and false otherwise.</returns>
        protected override bool IsMatch(int number)
        {
            return IsDigitPresent(number);
        }

        private static bool IsDigitPresent(int number)
        {
            while (number / 10 != 0)
            {
                if (Math.Abs(number % 10) == Digit)
                {
                    return true;
                }

                number /= 10;
            }

            return Math.Abs(number % 10) == Digit;
        }
    }
}
