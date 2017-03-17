using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InnerWorkingsCodeAssignment.Tests
{
    [TestClass]
    public class JobItemTests
    {
        [TestMethod]
        public void JobItem_NotTaxExempt_AddSalesTaxAndRoundToNearestCent()
        {
            var actual = new JobItem(string.Empty, 100.08m, false).Price;

            Assert.AreEqual(107.09m, actual);
        }

        [TestMethod]
        public void JobItem_GivenCostOf100AndTaxExempt_ReturnPriceOf100()
        {
            var actual = new JobItem(string.Empty, 100, true).Price;

            Assert.AreEqual(100m, actual);
        }
    }
}
