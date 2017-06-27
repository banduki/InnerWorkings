using Xunit;

namespace InnerWorkingsCodeAssignment.Tests
{
    public class JobItemTests
    {
        [Fact]
        public void JobItem_NotTaxExempt_AddSalesTaxAndRoundToNearestCent()
        {
            var actual = new JobItem(string.Empty, 100.08m, false).Price;

            Assert.Equal(107.09m, actual);
        }

        [Fact]
        public void JobItem_GivenCostOf100AndTaxExempt_ReturnPriceOf100()
        {
            var actual = new JobItem(string.Empty, 100, true).Price;

            Assert.Equal(100m, actual);
        }
    }
}
