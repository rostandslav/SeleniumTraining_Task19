using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Pages
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal MainPage Open()
        {
            driver.Url = "http://litecart/en/";
            return this;
        }
    }
}
