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
        private readonly By _writeEmailButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By _senderField = By.XPath("//div[@class='aGb']//div[@class='afx']//input");
        private readonly By _subjectBox = By.XPath("//input[@name='subjectbox']");
        private readonly By _emailBox = By.XPath("//div[@class='Am Al editable LW-avf tS-tW']");
        private readonly By _sendEmailButton = By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        private readonly By _emailSentMessage = By.XPath("//span[@class='bAq']");

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
            wait.Until(ExpectedConditions.ElementIsVisible(_writeEmailButton));
            var writeEmailButton = driver.FindElement(_writeEmailButton);
            writeEmailButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_senderField));
            var senderField = driver.FindElement(_senderField);
            senderField.SendKeys("testingtester182@gmail.com");
            var subjectBox = driver.FindElement(_subjectBox);
            subjectBox.SendKeys("text");
            var emailBox = driver.FindElement(_emailBox);
            emailBox.SendKeys("full text");
            var sendEmailButton = driver.FindElement(_sendEmailButton);
            sendEmailButton.Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_sendEmailButton));
            var emailSentMessage = driver.FindElement(_emailSentMessage);
            Assert.IsTrue(emailSentMessage.Displayed && emailSentMessage.Enabled);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}