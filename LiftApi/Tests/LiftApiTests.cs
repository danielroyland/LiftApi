using LiftApi.ApiControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiftApi.Tests
{
    [TestClass]
    public class LiftApiTests
    {
        [TestMethod]
        public void BeregnTeoretiskMaksTest()
        {
            var teoretiskMaks = HelperMethods.BeregnTeoretiskMaks(100, 2);

            Assert.IsNotNull(teoretiskMaks);
        }
    }
}