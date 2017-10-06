using HotelBookingServer.Implementations;
using HotelBookingServer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cache.Tests
{
    [TestClass]
    public class CacheTest
    {
        [TestMethod]
        public void Check_If_Add_To_Cache_Is_Working_Or_Not()
        {
            InMemorySearchCache inMemorySearchCache = new InMemorySearchCache(3);
            string id1 = inMemorySearchCache.AddToCache(new SearchObject());
            string id2 = inMemorySearchCache.AddToCache(new SearchObject());
            Assert.IsTrue(inMemorySearchCache.IsPresent(id1));
        }
    }
}
