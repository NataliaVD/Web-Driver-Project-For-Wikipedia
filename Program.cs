using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var driver = new ChromeDriver();
driver.Url = "https://wikipedia.org";

Console.WriteLine(driver.Title);

var searchedField = driver.FindElement(By.Id("searchInput"));
searchedField.Click();
searchedField.SendKeys("QA" + Keys.Enter);

Console.WriteLine(driver.Title);

driver.Quit();

