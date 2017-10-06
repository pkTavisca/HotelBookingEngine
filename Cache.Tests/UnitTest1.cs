using HotelBookingServer.Implementations;
using HotelBookingServer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cache.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InMemorySearchCache inMemorySearchCache = new InMemorySearchCache(3);
            string id1 = inMemorySearchCache.AddToCache(new SearchObject());
            string id2 = inMemorySearchCache.AddToCache(new SearchObject());
            Assert.IsTrue(inMemorySearchCache.IsPresent(id1));
        }
    }
}
