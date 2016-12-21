using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects.App;


namespace PageObjects.Tests
{
    public class TestBase
    {
        public Application app;

        [TestInitialize]
        public void AppStart()
        {
            app = new Application();
        }

        [TestCleanup]
        public void AppStop()
        {
            app.Quit();
            app = null;
        }
    }
}
