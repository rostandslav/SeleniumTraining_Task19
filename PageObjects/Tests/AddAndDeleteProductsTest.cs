using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects.App;


namespace PageObjects.Tests
{
    [TestClass]
    public class AddAndDeleteProductsTest : TestBase
    {
        [TestMethod]
        public void AddAndDeleteProducts()
        {
            const int testProductsCount = 3;
            app.AddFirstMostPopularToCart_N(testProductsCount);
            app.RemoveAllProductsFromCart();
        }
    }
}
