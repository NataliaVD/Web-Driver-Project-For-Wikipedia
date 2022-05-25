
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NUnitWebDriverTestsForWikipedia
{
    public class Wikipedia
    {
        private WebDriver driver;
        private IWebElement searchedElement;
        private string expectedResult;
        private WebDriverWait wait;


        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://wikipedia.org";
        }

        [TearDown]
        public void Shutdown()
        {
            this.driver.Quit();

        }

        [Test]
        public void TestMainPageTitle()
        {
            var expectedResult = "Wikipedia";

            Assert.That(expectedResult, Is.EqualTo(driver.Title));
        }

        [Test]
        public void TestChooseEnglish()
        {
            searchedElement = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/a/strong"));
            searchedElement.Click();
            expectedResult = "Wikipedia, the free encyclopedia";

            Assert.That(driver.Title, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestSearchField()
        {
            searchedElement = driver.FindElement(By.CssSelector("#searchInput"));
            searchedElement.Click();
            searchedElement.SendKeys("Червен бряг" + Keys.Enter);

            Assert.That(driver.Title, Is.EqualTo("Червен бряг - Search results - Wikipedia"));
        }

        [Test]

        public void TestChoosePolish()
        {
            searchedElement = driver.FindElement(By.CssSelector("#js-lang-list-button > span"));
            searchedElement.Click();


            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            var language = wait.Until(d =>
            {
                return d.FindElement(By.LinkText("Polski"));
            });

            language.Click();

            var expected = "Wikipedia, wolna encyklopedia";

            Assert.That(driver.Title, Is.EqualTo(expected));
        }

        /* public void TestChoosePolish()
         {
             searchedElement = driver.FindElement(By.CssSelector("#js-lang-list-button > span"));
             searchedElement.Click();


             this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

             var language = wait.Until(driver =>
             {
                 return driver.FindElement(By.XPath("/html/body/div[6]/div/div[1]/ul/li[1]/a"));
             });
             language.Click();

             var expected = "Wikipedia, wolna encyklopedia";

             Assert.That(driver.Title, Is.EqualTo(expected));
         }*/
    }
}