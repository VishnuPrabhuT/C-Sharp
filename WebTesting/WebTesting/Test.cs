using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebTesting
{
    [TestFixture]
    public class Test : ITest
    {

        IWebDriver driver;
        //static IWebDriver driverFirefox;
        static int counter = Convert.ToInt32(File.ReadAllText(@"C:\Users\vishnu\source\repos\WebTesting\WebTesting\ID\Counter.txt").Replace(" ", ""));
        static string id = counter.ToString();
        static string[][] signupData;
        static string[] taxTabData;
        static string[] departmentData;
        static string[] priceGroupData;
        static string[] ageRestrictionData;
        static string[] categoryData;
        static string[] singleItemData;
        static string bulkUploadFilePath;
        static string[] singleItemUpdateData;
        static string[] searchItemData;
        static string[] deptbulkUpdateData;
        static string[] taxBulkUpdateSearchData;
        static string[] nameBulkUpdateSearchData;
        static string[] promotionsData;

        string currUserName = "";
        string currPassword = "";
        /// <summary>
        /// Add data for test case
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            signupData = new string[1][];
            signupData[0] = new string[] {
                "teststore"+id,
                "testUser"+id,
                "test@cstorepro.com",
                "281-265-2245",
                "testUser"+id,
                "welcome"
            };

            currUserName = "testUser" + (Convert.ToInt32(id) - 1).ToString();
            currPassword = "welcome";

            taxTabData = new string[] {
                "101,Taxable,8.25",
                "99,Non-Tax,0"
            };

            departmentData = new string[]
            {
                "200,Beer,Taxable,101",
                "300,Soda,Taxable,101",
                "400,Cigs,Taxable,101",
                "500,Non Taxable Items,Non-Tax,99",
                "600,General Merchandise,Taxable,101"
            };

            priceGroupData = new string[]
            {
                "Premium Cigs,2"
            };

            ageRestrictionData = new string[]
            {
                "100,18 and over"
            };

            singleItemData = new string[]
            {
                "02820013630,MARLB 100 BOX CT,55,Cigs,Taxable,Premium Cigs,18 and over",
                "283632,MARLBORO 100 BOX PACK,5.99,Cigs,Taxable,Premium Cigs,18 and over",
                "02820000943,MARL SKYLINE BX,3.99,Cigs,Taxable,Premium Cigs,18 and over",
                "02820000376,MARLBORO BLU BX,5.49,Cigs,Taxable,Premium Cigs,18 and over",
                "02820014780,MARL SLVR 100 BX CT,55.99,Cigs,Taxable,Premium Cigs,18 and over"
            };

            bulkUploadFilePath = @"C:\Users\vishnu\source\repos\WebTesting\WebTesting\Data\TestPricebook.csv";

            singleItemUpdateData = new string[]
            {
                "02820013630,MARLB 100 BOX CT,69.99,Beer,Taxable,Premium Cigs,None,Bimbo Bakeries,60,3,5,3,10",
                "028200136305,MARLBORO,59.99,Cigs,Taxable,Premium Cigs,18 and over,Core Mart,50,0,50,30,100",
                "283632,MARLBORO 100 BOX-,5.99,Beer,Taxable,Marlboro Black,None,Bimbo Bakeries,4.5,1.23,5,3,10",
                "2836328,MARLBORO 100 BOX-,6.19,Cigs,Taxable,MARLBORO,18 and over,Bimbo Bakeries,4.5,1.23,500,300,1000",
                "028200003638,MARLBORO 100 BOX,6.19,Cigs,Taxable,MARLBORO,18 and over,Bimbo Bakeries,4.5,1.23,500,300,1000"
            };

            //Department
            deptbulkUpdateData = new string[]
            {
                "Premium Cigs,Cigs,Beer",
                "Premium Cigs,Beer,Cigs"
            };

            //Tax Group
            taxBulkUpdateSearchData = new string[]
            {
                "Premium Cigs,Taxable,Non-Tax",
                "Premium Cigs,Non-Tax,Taxable",
            };

            //Category
            categoryData = new string[]
            {
                "Beer,Taxable,5",
                "Soda,Taxable,5",
            };

            //Item Name
            nameBulkUpdateSearchData = new string[]
            {
                "COKE ALUMINUM",
                "COKE ALU",
                "KE ALU",
                "MINUM"
            };

            //Search Scan Codes
            searchItemData = new string[]
            {
                "02820000954",
                "028200009548",
                "289542",
                "2895428"
            };

            //Promotions
            promotionsData = new string[]
            {
                "Free,5,Mix Match,Coke Aluminum,"+DateTime.Today.Date.ToString().Replace("/","-")+","+DateTime.Today.AddDays(7).Date.ToString().Replace("/","-")+",4"
            };

        }

        /// <summary>
        /// Test case for Signup till .exe download
        /// </summary>
        [Test]
        public void A_SignUp()
        {
            File.WriteAllText(@"C:\Users\vishnu\source\repos\WebTesting\WebTesting\ID\Counter.txt", (counter + 1).ToString());
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/login.aspx");
            driver.FindElement(By.XPath("//a[contains(text(),'free trial')]")).Click();


            string storeName = signupData[0][0].ToString();
            string name = signupData[0][1].ToString();
            string email = signupData[0][2].ToString();
            string phoneNumber = signupData[0][3].ToString();
            string userName = signupData[0][4].ToString();
            string password = signupData[0][5].ToString();

            //Input register details
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtStoreName']")).SendKeys(storeName);
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtName']")).SendKeys(name);
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtEmailID']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtPhoneNumber']")).SendKeys(phoneNumber);
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtUserName']")).SendKeys(userName);
            driver.FindElement(By.XPath("//input[@id='SignUp_Form_txtPassword']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@id='btnSignup']")).Click();

            //Get details from landing page and move to Manage my store page
            string actualStoreName = driver.FindElement(By.XPath("//strong[@id='cspStoreName']")).Text;
            driver.FindElement(By.XPath("//li[@class='dropdown user-profile']//a[@class='dropdown-toggle']")).Click();
            string actualUserName = driver.FindElement(By.XPath("//div[@class='user-profile-data user-profile-title']")).Text;
            driver.FindElement(By.XPath("//a[contains(text(),'Manage my store')]")).Click();

            string actualEmail = driver.FindElement(By.XPath("//section[@class='panel panel-default EnetUI-MarginAll']//div[2]//div[1]//fieldset[1]//div[2]//div[2]//div[2]")).Text;
            string actualPhoneNumber = driver.FindElement(By.XPath("//section[@class='panel panel-default EnetUI-MarginAll']//div[2]//div[1]//fieldset[1]//div[2]//div[1]//div[2]")).Text;
            string actualName = driver.FindElement(By.XPath("/html[1]/body[1]/section[1]/section[1]/section[1]/section[1]/div[1]/div[2]/section[1]/div[2]/div[1]/fieldset[1]/div[1]/div[1]/div[2]")).Text;
            string actualcurrentPlan = driver.FindElement(By.XPath("/html[1]/body[1]/section[1]/section[1]/section[1]/section[1]/div[1]/div[2]/section[1]/div[2]/div[1]/fieldset[1]/div[1]/div[2]/div[2]")).Text;


            Assert.AreEqual(actualStoreName, storeName);
            Assert.AreEqual(actualUserName, userName);

            Assert.AreEqual(actualEmail, email);
            Assert.AreEqual(actualPhoneNumber, phoneNumber.Replace("-", ""));
            Assert.AreEqual(actualName, name);
            Assert.AreEqual(actualcurrentPlan, "Trial version");

            //Check if link works
            var request = (HttpWebRequest)WebRequest.Create("https://s3.amazonaws.com/CSPPOS/AgentSetup/setup.exe");
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            var success = response.StatusCode == HttpStatusCode.OK;
            Assert.AreEqual(true, success);
            //Move back to landing page and download .exe
            driver.FindElement(By.XPath("/html[1]/body[1]/aside[1]/div[1]/div[1]/ul[1]/li[14]/a[1]")).Click();
            driver.FindElement(By.XPath("//div[contains(text(),'Connect with your point of sale register')]")).Click();
            driver.FindElement(By.XPath("//div[@id='ofmodal-body']//a[@id='lnkDownloadUtility']")).Click();
            driver.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
        }


        [Test]
        public void B_PriceBookSetup()
        {
            //Login
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/login.aspx");
            driver.FindElement(By.Id("EWFLogin_Form_txtUserName")).SendKeys(currUserName);
            driver.FindElement(By.Id("EWFLogin_Form_txtPassword")).SendKeys(currPassword);
            driver.FindElement(By.CssSelector(".btn.btn-lg.btn-primary.btn-block")).Click();
            driver.FindElement(By.Id("ofmodal-cancel-btn")).Click();
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/Content/Tasks/TaskDashboard.aspx");
            driver.FindElement(By.XPath("//li[@id='EWF-Menu-LI-2029']")).Click();
            driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-2032']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Tax')]")).Click();

            //PriceBook Setup
            for (int i = 0; i < taxTabData.Length; i++)
            {
                //Click hidden element and Set line items under tax tab
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.Id("EWF-Grid-AddNew")));
                driver.FindElement(By.XPath("//input[@id='TaxGroupUpdate_Form_txtTaxTypeID']")).SendKeys(taxTabData[i].Split(',')[0]);
                driver.FindElement(By.XPath("//input[@id='TaxGroupUpdate_Form_txtTaxName']")).SendKeys(taxTabData[i].Split(',')[1]);
                driver.FindElement(By.XPath("//input[@id='TaxGroupUpdate_Form_txtTaxPercent']")).SendKeys(taxTabData[i].Split(',')[2]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
            }

            //Department Tab
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector(".nav-tabs li:nth-child(2) a")));

            for (int i = 0; i < departmentData.Length; i++)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#divUserSettingTabTab_Departments #frmRegisterKeyListOpForm_enetTable_gridHeader #EWF-Grid-AddNew")));
                driver.FindElement(By.CssSelector("#RegisterKeyAddUpdate_Form_txtDeptID")).Clear();
                driver.FindElement(By.CssSelector("#RegisterKeyAddUpdate_Form_txtDeptID")).SendKeys(departmentData[i].Split(',')[0]);
                driver.FindElement(By.CssSelector("#RegisterKeyAddUpdate_Form_txtDeptName")).Clear();
                driver.FindElement(By.CssSelector("#RegisterKeyAddUpdate_Form_txtDeptName")).SendKeys(departmentData[i].Split(',')[1]);
                driver.FindElement(By.XPath("//select[@id='RegisterKeyAddUpdate_Form_txtTaxType']/option[text() = '" + departmentData[i].Split(',')[2] + "']")).Click();
                //driver.FindElement(By.CssSelector("#RegisterKeyAddUpdate_Form_txtTaxType")).FindElement(By.XPath("//option[@value='" + departmentData[i].Split(',')[3] + "']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("#ofmodal-submit-btn")).Click();
            }

            //Price Group Tab
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector(".nav-tabs li:nth-child(10) a")));

            for (int i = 0; i < priceGroupData.Length; i++)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#divUserSettingTabTab_PriceGroups #EWF-Grid-AddNew")));
                driver.FindElement(By.CssSelector("#ItemPriceGroupUpdate_Form_txtPriceGroupName")).SendKeys(priceGroupData[i].Split(',')[0]);
                driver.FindElement(By.XPath("//select[@id='ItemPriceGroupUpdate_Form_txtPriceGroupType']//option[contains(@value,'" + priceGroupData[i].Split(',')[1] + "')][contains(text(),'Search group')]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("#ofmodal-submit-btn")).Click();
            }

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector(".nav-tabs li:nth-child(1) a")));

            driver.Navigate().Refresh();
            driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtdefaultDeptID']/option[text() = 'General Merchandise']")).Click();
            driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtdefaultTaxTypeID']/option[text() = 'Taxable']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtisInventoryEnabled']/option[text() = 'Yes']")).Click();
            driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtisLogUnScannedItems']/option[text() = 'No']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnSubmit_ID")).Click();


            Assert.AreEqual(driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtdefaultDeptID']/option[text() = 'General Merchandise']")).Text, "General Merchandise");
            Assert.AreEqual(driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtdefaultTaxTypeID']/option[text() = 'Taxable']")).Text, "Taxable");
            Thread.Sleep(1000);
            Assert.AreEqual(driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtisInventoryEnabled']/option[text() = 'Yes']")).Text, "Yes");
            Assert.AreEqual(driver.FindElement(By.XPath("//select[@id='POSConnectionUpdate_Form_txtisLogUnScannedItems']/option[text() = 'No']")).Text, "No");

            //Age-restriction tab
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector(".nav-tabs li:nth-child(9) a")));

            for (int i = 0; i < ageRestrictionData.Length; i++)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#divUserSettingTabTab_AgeRestriction #EWF-Grid-AddNew")));
                driver.FindElement(By.CssSelector("#AgeRestrictionAddUpdate_Form_txtAgeRestrictCodeID")).SendKeys(ageRestrictionData[i].Split(',')[0]);
                driver.FindElement(By.CssSelector("#AgeRestrictionAddUpdate_Form_txtAgeRestictCodeDesc")).SendKeys(ageRestrictionData[i].Split(',')[1]);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#ofmodal-submit-btn")));
            }

            //Add items Single upload Price book
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1690']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1607']")));
            Thread.Sleep(1000);
            //driver.FindElement(By.CssSelector(".btn.btn-primary.EWF-EmptyGrid-Addnew")).Click();
            for (int i = 0; i < singleItemData.Length; i++)
            {
                Thread.Sleep(5000);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#frmPOSItemListOpForm_enetTable_gridHeader #EWF-Grid-AddNew")));
                //driver.FindElement(By.CssSelector("#frmPOSItemListOpForm_enetTable_gridHeader #EWF-Grid-AddNew")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPOSCode']")).SendKeys(singleItemData[i].Split(',')[0]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@id='cmdLookup']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtDescription']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtDescription']")).SendKeys(singleItemData[i].Split(',')[1]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPrice']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPrice']")).SendKeys(singleItemData[i].Split(',')[2]);
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtDepartment']/option[text() = '" + singleItemData[i].Split(',')[3] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtTaxGroup']/option[text() = '" + singleItemData[i].Split(',')[4] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtPriceGroup']/option[text() = '" + singleItemData[i].Split(',')[5] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtIsAgeRestriction']/option[text() = '" + singleItemData[i].Split(',')[6] + "']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
            }

            //Bulk upload
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1175']")));
            driver.FindElement(By.CssSelector(".task-list #modalLauncher")).Click();
            driver.FindElement(By.XPath("//div[@id='ofmodal-body']//div[@id='uploader-container']//a[@href='#']")).Click();
            driver.FindElement(By.CssSelector("#flPricebookUpload")).SendKeys(bulkUploadFilePath);
            string totalItems = driver.FindElement(By.CssSelector(".analize-view .h4.text-center strong")).Text;
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".modal-footer-button.right")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.CssSelector(".modal-footer-button.right")).Click();

            //Check Footer in Price Book -> Items
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1690']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1607']")));
            Thread.Sleep(6000 * 10);
            driver.FindElement(By.CssSelector(".btn.btn-sm.btn-default.ENETOpFilter.autofocus.EWF-btnLoad.OF-full-wide-mob.ewf-focus-onkeydown")).Click();
            string actualNumber = driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text;
            //Assert.Contains("4325", actualNumber.Split(' '));

            //Setup Category
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1322']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1726']")));
            Thread.Sleep(1000);
            for(int i = 0; i < categoryData.Length; i++)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//div[@class='EnetUI-FloatRight']//a[1]")));
                //driver.FindElement(By.XPath("//div[@class='EnetUI-FloatRight']//a[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='ManageStoreCategoriesAddUpdate_Form_txtCategoryName']")).SendKeys(categoryData[i].Split(',')[0]);
                driver.FindElement(By.XPath("//select[@id='ManageStoreCategoriesAddUpdate_Form_txtIsTaxable']/option[text() = '" + categoryData[i].Split(',')[1] + "']")).Click();
                driver.FindElement(By.XPath("//input[@id='ManageStoreCategoriesAddUpdate_Form_txtMarkup']")).SendKeys(categoryData[i].Split(',')[2]);
                driver.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
            }
        }

        [Test]
        public void C_PriceBookCheck()
        {
            //Login
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/login.aspx");
            driver.FindElement(By.Id("EWFLogin_Form_txtUserName")).SendKeys(currUserName);
            driver.FindElement(By.Id("EWFLogin_Form_txtPassword")).SendKeys(currPassword);
            driver.FindElement(By.CssSelector(".btn.btn-lg.btn-primary.btn-block")).Click();
            driver.FindElement(By.Id("ofmodal-cancel-btn")).Click();
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/Content/Tasks/TaskDashboard.aspx");
            driver.FindElement(By.XPath("//li[@id='EWF-Menu-LI-2029']")).Click();
            driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-2032']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Tax')]")).Click();

            //Search Items
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1690']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1607']")));
            for (int i = 0; i < searchItemData.Length; i++)
            {
                driver.FindElement(By.Id("POSItemList_Form_POSCode")).Clear();
                driver.FindElement(By.Id("POSItemList_Form_POSCode")).SendKeys(searchItemData[i]);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector(".btn.btn-sm.btn-default.ENETOpFilter.autofocus.EWF-btnLoad.OF-full-wide-mob.ewf-focus-onkeydown")).Click();
                Thread.Sleep(2000);

                //Result count
                int resultCount = Convert.ToInt32(driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text.Replace(" Matches found", ""));
                Assert.That(resultCount > 0);
            }

            //Update single item
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#frmPOSItemListOpForm_enetTable_gridHeader #EWF-Grid-AddNew")).Click();
            for (int i = 0; i < singleItemUpdateData.Length; i++)
            {
                if (i > 0)
                {
                    Thread.Sleep(5000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("#frmPOSItemListOpForm_enetTable_gridHeader #EWF-Grid-AddNew")));
                }
                else
                {
                    Thread.Sleep(2000);
                }
                //IWebElement element = (new WebDriverWait(driverChrome, TimeSpan.FromSeconds(10))).Until(ExpectedConditions.ElementToBeClickable(By.Id("cmdLookup")));
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPOSCode']")).SendKeys(singleItemUpdateData[i].Split(',')[0]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@id='cmdLookup']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtDescription']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtDescription']")).SendKeys(singleItemUpdateData[i].Split(',')[1]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPrice']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtPrice']")).SendKeys(singleItemUpdateData[i].Split(',')[2]);
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtDepartment']/option[text() = '" + singleItemUpdateData[i].Split(',')[3] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtTaxGroup']/option[text() = '" + singleItemUpdateData[i].Split(',')[4] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtPriceGroup']/option[text() = '" + singleItemUpdateData[i].Split(',')[5] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtIsAgeRestriction']/option[text() = '" + singleItemUpdateData[i].Split(',')[6] + "']")).Click();
                driver.FindElement(By.XPath("//select[@id='POSItemAddNew_Form_txtPrimaryVendor']/option[text() = '" + singleItemUpdateData[i].Split(',')[7] + "']")).Click();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtItemGrossCost']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtItemGrossCost']")).SendKeys(singleItemUpdateData[i].Split(',')[8]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtItemDiscount']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtItemDiscount']")).SendKeys(singleItemUpdateData[i].Split(',')[9]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtCurrInventory']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtCurrInventory']")).SendKeys(singleItemUpdateData[i].Split(',')[10]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtReOrderQty']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtReOrderQty']")).SendKeys(singleItemUpdateData[i].Split(',')[11]);
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtReStockQty']")).Clear();
                driver.FindElement(By.XPath("//input[@id='POSItemAddNew_Form_txtReStockQty']")).SendKeys(singleItemUpdateData[i].Split(',')[12]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@id='ofmodal-submit-btn']")).Click();
            }

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1690']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1615']")));

            //Department Search
            for (int i = 0; i < deptbulkUpdateData.Length; i++)
            {
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//select[@id='PriceChange_Form_PriceGrpID']/option[text() = '" + deptbulkUpdateData[i].Split(',')[0] + "']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//select[@id='PriceChange_Form_DeptID']/option[text() = '" + deptbulkUpdateData[i].Split(',')[1] + "']")).Click();
                driver.FindElement(By.Id("btnPriceChange_Filter_Search")).Click();
                Thread.Sleep(3000);

                //Result count
                int resultCount = Convert.ToInt32(driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text.Replace(" Matches found", ""));
                Assert.That(resultCount > 0);

                driver.FindElement(By.XPath("//select[@id='EWF-txtFillParent-txtDeptID_ID']/option[text() = '" + deptbulkUpdateData[i].Split(',')[2] + "']")).Click();
                driver.FindElement(By.Id("EWF-txtFillParent-txtDeptID_Apply")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnPriceChangeNowTop")).Click();
            }

            driver.Navigate().Refresh();

            //Tax Search
            for (int i = 0; i < taxBulkUpdateSearchData.Length; i++)
            {
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//select[@id='PriceChange_Form_PriceGrpID']/option[text() = '" + taxBulkUpdateSearchData[i].Split(',')[0] + "']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//select[@id='PriceChange_Form_TaxTypeID']/option[text() = '" + taxBulkUpdateSearchData[i].Split(',')[1] + "']")).Click();
                driver.FindElement(By.Id("btnPriceChange_Filter_Search")).Click();
                Thread.Sleep(3000);

                //Result count
                int resultCount = Convert.ToInt32(driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text.Replace(" Matches found", ""));
                Assert.That(resultCount > 0);

                driver.FindElement(By.XPath("//select[@id='EWF-txtFillParent-txtTaxTypeID_ID']/option[text() = '" + taxBulkUpdateSearchData[i].Split(',')[2] + "']")).Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.Id("EWF-txtFillParent-txtTaxTypeID_Apply")));
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnPriceChangeNowTop")).Click();
            }

            driver.Navigate().Refresh();
            //driver.FindElement(By.XPath("//select[@id='PriceChange_Form_PriceGrpID']//option[1]")).Click();
            //Name Search
            for (int i = 0; i < nameBulkUpdateSearchData.Length; i++)
            {
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id='PriceChange_Form_ItemName']")).Clear();
                driver.FindElement(By.XPath("//input[@id='PriceChange_Form_ItemName']")).SendKeys(nameBulkUpdateSearchData[i]);
                driver.FindElement(By.Id("btnPriceChange_Filter_Search")).Click();
                Thread.Sleep(3000);

                int resultCount = Convert.ToInt32(driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text.Replace(" Matches found", ""));
                Assert.That(resultCount > 0);
            }
        }

        [Test]
        public void D_Promotions()
        {
            //Login
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/login.aspx");
            driver.FindElement(By.Id("EWFLogin_Form_txtUserName")).SendKeys(currUserName);
            driver.FindElement(By.Id("EWFLogin_Form_txtPassword")).SendKeys(currPassword);
            driver.FindElement(By.CssSelector(".btn.btn-lg.btn-primary.btn-block")).Click();
            driver.FindElement(By.Id("ofmodal-cancel-btn")).Click();
            driver.Navigate().GoToUrl("http://localhost/EmagineNETCOSM/Content/Tasks/TaskDashboard.aspx");
            driver.FindElement(By.XPath("//li[@id='EWF-Menu-LI-2029']")).Click();

            driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-2032']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Tax')]")).Click();

            driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1690']")).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1612']")));
            //driver.FindElement(By.XPath("//a[@id='EWF-Menu-Link-1612']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary EWF-EmptyGrid-Addnew']")).Click();
            Thread.Sleep(1000);
            for (int i = 0; i < promotionsData.Length; i++)
            {
                driver.FindElement(By.XPath("//div[@class='promo-field']//input[@type='text']")).SendKeys(promotionsData[i].Split(',')[0]);
                driver.FindElement(By.XPath("//input[@placeholder='$0']")).SendKeys(promotionsData[i].Split(',')[1]);
                driver.FindElement(By.XPath("//option[contains(text(),'" + promotionsData[i].Split(',')[2] + "')]")).Click();
                driver.FindElement(By.XPath("//div[@id='ofmodal-footer']//div[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[@class='promo-form-row']//input[@type='text']")).SendKeys(promotionsData[i].Split(',')[0]);
                driver.FindElement(By.XPath("//input[@id='POSPromoItemListCreation_Form_txtSearchScanCodeName']")).SendKeys(promotionsData[i].Split(',')[3]);
                driver.FindElement(By.XPath("//button[contains(text(),'Search')]")).Click();
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath("//div[@id='ofmodal-footer']//div[2]")));
                //driver.FindElement(By.XPath("//div[@id='ofmodal-footer']//div[2]")).Click();
                driver.FindElement(By.XPath("//input[@id='promoStartDate']")).SendKeys(promotionsData[i].Split(',')[4]);
                driver.FindElement(By.XPath("//input[@id='promoEndDate']")).SendKeys(promotionsData[i].Split(',')[5]);
                driver.FindElement(By.XPath("//section[@class='promo-screen ng-scope']//div[3]//div[1]//input[1]")).SendKeys(promotionsData[i].Split(',')[6]);
                driver.FindElement(By.XPath("//div[@id='ofmodal-content']//div[3]//div[3]")).Click();
                Thread.Sleep(2000);

                //Result Count
                int resultCount = Convert.ToInt32(driver.FindElement(By.XPath("//small[@class='text-muted inline m-t-sm m-b-sm']")).Text.Replace(" Matches found", ""));
                Assert.That(resultCount > 0);
            }
        }

        [Test]
        public void E_Purchasing()
        {

        }

        [TearDown]
        public void CleanUp()
        {
            //driverChrome.Close();
            //driverFirefox.Close();
        }
    }
}

