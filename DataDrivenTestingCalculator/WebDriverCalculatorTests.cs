using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverCalculatorTests
{
    public class Tests
    {
        private ChromeDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Calculator()
        {
            // Arrange
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));

            // Act
            field1.SendKeys("5");
            operation.SendKeys("+");
            field2.SendKeys("6");

            calculate.Click();

            string expectedValue = "Result: 11";

            Assert.That(expectedValue, Is.EqualTo(resultField.Text));

            clearField.Click();
        }


        // Data Driven Test:
        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("alabala", "alabala", "-", "Result: invalid input")]
        public void Test_Calculator(string num1, string num2, string operato, string result)
        {
                // Arrange
                field1 = driver.FindElement(By.Id("number1"));
                field2 = driver.FindElement(By.Id("number2"));
                operation = driver.FindElement(By.Id("operation"));
                calculate = driver.FindElement(By.Id("calcButton"));
                resultField = driver.FindElement(By.Id("result"));
                clearField = driver.FindElement(By.Id("resetButton"));

                // Act
                field1.SendKeys(num1);
                operation.SendKeys(operato);
                field2.SendKeys(num2);

                calculate.Click();


                Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click();
        }
        
    }
}