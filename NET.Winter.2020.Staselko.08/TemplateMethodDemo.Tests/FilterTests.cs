using NUnit.Framework;
using Moq;
using Moq.Protected;
using System.Linq;

namespace TemplateMethodDemo.Tests
{
    public class FilterTests
    {
        [Test]
        public void FilterStateTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.Is<int>(i => i.ToString().Contains("1")))
                .Returns(true);

            Filter filter = mockFilter.Object;

            var source = new[] { 11, 121, 31, 20, 33, 56, 234, -233323124, 648 };

            var expected = new[] { 11, 121, 31, -233323124 };

            var actual = filter.FilterByKey(source);

            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void FilterBehaviourTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.IsAny<int>())
                .Returns(true);

            Filter filter = mockFilter.Object;

            int count = 1000;

            var source = Enumerable.Range(1, count).ToArray();

            filter.FilterByKey(source);

            mockFilter.Protected().Verify("IsMatch", Times.Exactly(count), ItExpr.IsAny<int>());
        }
    }
}