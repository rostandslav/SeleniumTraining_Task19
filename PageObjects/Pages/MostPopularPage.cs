using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Pages
{
    class MostPopularPage : Page
    {
        public MostPopularPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-most-popular li a.link")]
        IWebElement firstPopular;

        internal void OpenProductPage()
        {
            firstPopular.Click();
        }
    }
}
