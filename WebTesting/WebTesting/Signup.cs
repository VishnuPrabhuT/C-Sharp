using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace seleniumTest
{
    [TestFixture]
    public class Signup
    {
        static IWebDriver driverChrome = new ChromeDriver();

        //static IWebDriver driverFirefox;
        static string id;
        static string[][] data;
        public static string[][] SignupData()
        {

            return data;
        }

        /// <summary>
        /// Add data for test case
        /// </summary>
        [SetUp]
        public void Setup()
        {
            int counter = Convert.ToInt32(File.ReadAllText(@"C:\Users\vishnu\source\repos\WebTesting\WebTesting\ID\Counter.txt").Replace(" ", "")) + 1;
            id = counter.ToString();
            File.WriteAllText(@"C:\Users\vishnu\source\repos\WebTesting\WebTesting\ID\Counter.txt", id);
            data = new string[1][];
            data[0] = new string[] {
                "teststore"+id,
                "testUser"+id,
                "vishnu@cstorepro.com",
                "281-265-2245",
                "testUser"+id,
                "welcome"
            };
            //driverFirefox = new FirefoxDriver();
        }

        /// <summary>
        /// Test case for Signup till .exe download
        /// </summary>
        [Test]
        public void SignupRegister()
        {
            driverChrome.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/login.aspx");
            driverChrome.Manage().Window.Maximize();
            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driverChrome.FindElement(By.XPath("//a[contains(text(),'free trial')]")).Click();


            string storeName = data[0][0].ToString();
            string name = data[0][1].ToString();
            string email = data[0][2].ToString();
            string phoneNumber = data[0][3].ToString();
            string userName = data[0][4].ToString();
            string password = data[0][5].ToString();

            //Input resigter details
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtStoreName']")).SendKeys(storeName);
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtName']")).SendKeys(name);
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtEmailID']")).SendKeys(email);
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtPhoneNumber']")).SendKeys(phoneNumber);
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtUserName']")).SendKeys(userName);
            driverChrome.FindElement(By.XPath("//input[@id='SignUp_Form_txtPassword']")).SendKeys(password);
            driverChrome.FindElement(By.XPath("//button[@id='btnSignup']")).Click();

            //Get details from landing page and move to Manage my store page
            string actualStoreName = driverChrome.FindElement(By.XPath("//strong[@id='cspStoreName']")).Text;
            driverChrome.FindElement(By.XPath("//li[@class='dropdown user-profile']//a[@class='dropdown-toggle']")).Click();
            string actualUserName = driverChrome.FindElement(By.XPath("//div[@class='user-profile-data user-profile-title']")).Text;
            driverChrome.FindElement(By.XPath("//a[contains(text(),'Manage my store')]")).Click();

            string actualEmail = driverChrome.FindElement(By.XPath("//section[@class='panel panel-default EnetUI-MarginAll']//div[2]//div[1]//fieldset[1]//div[2]//div[2]//div[2]")).Text;
            string actualPhoneNumber = driverChrome.FindElement(By.XPath("//section[@class='panel panel-default EnetUI-MarginAll']//div[2]//div[1]//fieldset[1]//div[2]//div[1]//div[2]")).Text;
            string actualName = driverChrome.FindElement(By.XPath("/html[1]/body[1]/section[1]/section[1]/section[1]/section[1]/div[1]/div[2]/section[1]/div[2]/div[1]/fieldset[1]/div[1]/div[1]/div[2]")).Text;
            string actualcurrentPlan = driverChrome.FindElement(By.XPath("/html[1]/body[1]/section[1]/section[1]/section[1]/section[1]/div[1]/div[2]/section[1]/div[2]/div[1]/fieldset[1]/div[1]/div[2]/div[2]")).Text;


            Assert.AreEqual(actualStoreName, storeName);
            Assert.AreEqual(actualUserName, userName);

            Assert.AreEqual(actualEmail, email);
            Assert.AreEqual(actualPhoneNumber, phoneNumber.Replace("-", ""));
            Assert.AreEqual(actualName, name);
            Assert.AreEqual(actualcurrentPlan, "Trial version");

            //Move back to landing page and download .exe
            driverChrome.FindElement(By.XPath("/html[1]/body[1]/aside[1]/div[1]/div[1]/ul[1]/li[14]/a[1]")).Click();
            driverChrome.FindElement(By.XPath("//div[contains(text(),'Connect with your point of sale register')]")).Click();
            driverChrome.FindElement(By.XPath("//div[@id='ofmodal-body']//a[@id='lnkDownloadUtility']")).Click();
            driverChrome.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
        }

        [TearDown]
        public void CleanUp()
        {
            //driverChrome.Close();
            //driverFirefox.Close();
        }





    }
}
