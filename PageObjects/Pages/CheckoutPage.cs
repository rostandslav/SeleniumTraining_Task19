using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Pages
{
    class CheckoutPage : Page
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal CheckoutPage Open()
        {
            driver.Url = "http://litecart/en/checkout";
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "#box-checkout-cart")]
        IList<IWebElement> boxCheckoutCart;

        internal bool CheckIfAtLeastOneElementExists()
        {
            return boxCheckoutCart.Count > 0;
        }

        private const string cartFormSelector = "#box-checkout-cart form[name='cart_form']";

        [FindsBy(How = How.CssSelector, Using = (cartFormSelector + " input[name='quantity']"))]
        IWebElement quantity;

        internal void StopCarousel()
        {
            quantity.Click();
        }

        [FindsBy(How = How.CssSelector, Using = (cartFormSelector + " div a strong"))]
        IWebElement currentProduct;

        internal string GetCurrentProduct()
        {
            return currentProduct.Text;
        }

        [FindsBy(How = How.CssSelector, Using = (cartFormSelector + " button[name='remove_cart_item']"))]
        IWebElement removeBtn;

        internal void Remove()
        {
            removeBtn.Click();
        }

        private IWebElement productInOrderSummary
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='order_confirmation-wrapper']/table/tbody/tr/td[contains(text(), '" + GetCurrentProduct() + "')]"));
            }
        }

        internal void WaitUntilProductRemoved()
        {
            wait.Until(ExpectedConditions.StalenessOf(productInOrderSummary));
        }
    }
}
