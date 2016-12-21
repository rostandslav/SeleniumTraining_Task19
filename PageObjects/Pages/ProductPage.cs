using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Pages
{
    class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "form[name='buy_now_form'] select[required='required']")]
        IList<IWebElement> requiredSelects;

        internal void SelectFirstOption()
        {
            for (int i = 0; i < requiredSelects.Count; i++)
            {
                requiredSelects[i].SendKeys(Keys.ArrowDown);
            }
        }

        [FindsBy(How = How.CssSelector, Using = "form[name='buy_now_form'] input[name='quantity']")]
        IWebElement quantity;

        internal int GetQuantity()
        {
            return Convert.ToInt32(quantity.GetAttribute("value"));
        }

        [FindsBy(How = How.CssSelector, Using = "button[name='add_cart_product']")]
        IWebElement addToCartBtn;

        internal void AddToCart()
        {
            addToCartBtn.Click();
        }
    }
}
