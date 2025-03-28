using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests
{
    public class SauceDemoTestSuite
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private int numberOfItemsInCart;
        private int numberOfItemsToBuy;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            numberOfItemsInCart = 3;
            numberOfItemsToBuy = 2;
        }

        [Test]
        public void Test1_VerifyLogin()
        {
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            Assert.That(driver.Url, Does.Contain("inventory.html"));
        }

        [Test]
        public void Test2_AddAndBuyItems()
        {
            Test1_VerifyLogin();

            var items = driver.FindElements(By.ClassName("btn_inventory")).Take(numberOfItemsInCart);
            foreach (var item in items)
            {
                item.Click();
            }

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElements(By.ClassName("cart_button")).First().Click();
            driver.FindElement(By.Id("checkout")).Click();
        }

        [Test]
        public void Test3_PurchaseWithinRange()
        {
            Test1_VerifyLogin();

            var items = driver.FindElements(By.ClassName("inventory_item_price"));
            decimal total = 0;
            foreach (var item in items)
            {
                decimal price = Convert.ToDecimal(item.Text.Replace("$", ""));
                if (total + price <= 60)
                {
                    item.FindElement(By.XPath("following-sibling::button")).Click();
                    total += price;
                }
            }

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
