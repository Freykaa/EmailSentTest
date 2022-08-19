using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace EmailSentTest
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _email = By.Id("identifierId");
        private readonly By _nextButton = By.Id("identifierNext");
        private readonly By _password = By.XPath("//input[@type='password']");
        private readonly By _passwordNextButton = By.Id("passwordNext");
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.google.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void EmailSentTest()
        {
            var email = driver.FindElement(_email);
            email.SendKeys("testingaccep@gmail.com");
            var nextButton = driver.FindElement(_nextButton);
            nextButton.Click();
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_password));
            var password = driver.FindElement(_password);
            password.SendKeys("q6w5e4r3t2y1");
            var passwordNextButton = driver.FindElement(_passwordNextButton);
            passwordNextButton.Click();
            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}