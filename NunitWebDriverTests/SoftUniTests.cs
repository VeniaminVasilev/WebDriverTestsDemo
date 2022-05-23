using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            // Add option to Chrome Browser Instance
            var options = new ChromeOptions();
            // options.AddArgument("--headless");
            this.driver = new ChromeDriver(options);
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            // Act
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            // Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            // Act
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            // Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_Login_InvalidUsernameAndPassword()
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            // Locate username field by ID
            // var usernameField = driver.FindElement(By.Id("username"));

            // Locate username field by Name
            // var usernameField_ByName = driver.FindElement(By.Name("username"));
            // var var usernameField_CSSSelector = driver.FindElement(By.CssSelector("#username"));

            IWebElement usernameField = driver.FindElement(By.Id("username"));

            usernameField.Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".login-page-form-content-remember-me-checkbox")).Click();
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
        }

        [Test]
        public void Test_Search_PositiveResults()
        {
            driver.Url = "https://softuni.bg";
            // Click on search button
            driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search")).Click();

            // Type search value and hit enter
            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");
            searchBox.SendKeys("Keys.Enter");

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedValue = "Резултати от търсене на 'QA'";

            Assert.That(resultField, Is.EqualTo(expectedValue));
        }
        
    }
}