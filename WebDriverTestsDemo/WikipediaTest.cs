using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Create new Chrome browser instance
var driver = new ChromeDriver();

// Navigate to Wikipedia
driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

// Locate search field by Id
var searchField = driver.FindElement(By.Id("searchInput"));

// Click on element
searchField.Click();

// Fill QA and press Enter keyboard button
searchField.SendKeys("Quality Assurance" + Keys.Enter);

System.Console.WriteLine("TITLE AFTER SEARCH: " + driver.Title);

// Close browser
driver.Quit();