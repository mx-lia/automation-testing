using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace automation_testing
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver
            {
                Url = "http://www.google.by"
            };
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("iTechArt");
            element.Submit();
        }

        [Test]
        public void FirstResultIsITechArtTest()
        {
            IWebElement element = driver.FindElement(By.ClassName("g"));
            Assert.IsTrue(element.Text.Contains("iTechArt"), "First result doesn't contain 'iTechArt'");
        }

        [Test]
        public void TitleContainsITechArtTest()
        {
            Assert.IsTrue(driver.Title.Contains("iTechArt"), "Title doesn't contain 'iTechArt'");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}