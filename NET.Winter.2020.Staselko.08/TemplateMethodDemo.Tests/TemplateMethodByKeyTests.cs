using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TemplateMethodDemo;

namespace TemplateMethodDemo.Tests
{
    class TemplateMethodByKeyTests
    {
        [TestCase(new[] { 2212332, 1405644, 1236674 }, 0, new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, new int[0])]

        public void FilterByKey_WithPossitivePowers_ExpectedResults(int[] array, int digit, int[] expected)
        {
            TemplateMethodByKey temp = new TemplateMethodByKey(digit);
             
            Assert.AreEqual(expected, temp.FilterByKey(array));
        }

        [Test]
        public void FilterByKey_WithEmptyArray_ArgumentException()
        {
            TemplateMethodByKey temp = new TemplateMethodByKey();
            Assert.Throws<ArgumentException>(() => temp.FilterByKey(new int[0]),
             message: "Array cannot be empty!");
        }
        [Test]
        public void FilterByKey_WithNullArray_ArgumentNullException()
        {
            TemplateMethodByKey temp = new TemplateMethodByKey();
            Assert.Throws<ArgumentNullException>(() => temp.FilterByKey(null),
                message: "Array cannot be null");
        }

        [Test]
        public void FilterByKey_WithNegativeDigit_ArgumentOutOfRangeException()
        {
            
            
            Assert.Throws<ArgumentOutOfRangeException>(() => TemplateMethodByKey.Digit = -1,
                message: "digit must be >=0 and <=9");

        }
    }
}
