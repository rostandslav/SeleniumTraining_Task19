using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.Pages;


namespace PageObjects.App
{
    public class Application
    {
        private IWebDriver driver;

        private CartPage cartPage;
        private CheckoutPage checkoutPage;
        private MainPage mainPage;
        private MostPopularPage mostPopularPage;
        private ProductPage productPage;

        public Application()
        {
            driver = new ChromeDriver();
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            mainPage = new MainPage(driver);
            mostPopularPage = new MostPopularPage(driver);
            productPage = new ProductPage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }

        internal void AddFirstMostPopularToCart()
        {
            mainPage.Open();
            mostPopularPage.OpenProductPage();
            int beforeAddItemsCount = cartPage.GetItemsCount();
            productPage.SelectFirstOption();
            int addedItemsCount = productPage.GetQuantity();
            int afterAddItemsCount = beforeAddItemsCount + addedItemsCount;
            productPage.AddToCart();
            cartPage.WaitUntilItemsCountChanged(afterAddItemsCount.ToString());
            mainPage.Open();
        }

        internal void AddFirstMostPopularToCart_N(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddFirstMostPopularToCart();
            }
        }

        internal void RemoveAllProductsFromCart()
        {
            checkoutPage.Open();
            while (checkoutPage.CheckIfAtLeastOneElementExists())
            {
                checkoutPage.StopCarousel();
                checkoutPage.Remove();
                checkoutPage.WaitUntilProductRemoved();
            }
        }
    }
}
