using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Pages
{
    class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#header #cart .quantity")]
        IWebElement cartItemsCount;

        internal int GetItemsCount()
        {
            return Convert.ToInt32(cartItemsCount.Text);
        }

        internal void WaitUntilItemsCountChanged(string expectedCount)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(cartItemsCount, expectedCount));
        }
    }
}
