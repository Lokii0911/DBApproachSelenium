using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBApproachSelenium.Setup;


namespace DBApproachSelenium.DBApproach.TestCase
{
    public class DeleteAdminVerification:Basefunction
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private static readonly By Admin = By.XPath("//ul/li/a/span[text()='Admin']");
        private static readonly By Empname = By.XPath("//label[normalize-space()='Employee Name']/ancestor::div[contains(@class,'oxd-input-group')]//input");
        private static readonly By Searchbtn = By.XPath("//button[@type='submit']");
        private static readonly By Deletebtn = By.XPath("//button[@type='button']//i[@class='oxd-icon bi-trash']");
        private static readonly By Delete = By.XPath("//button[@type='button' and contains(@class,'oxd-button--label-danger') and normalize-space()='Yes, Delete']");
        private static readonly By VerifytoastMessage = By.XPath("//div[contains(@class,'oxd-toast-content')]");

        public DeleteAdminVerification(IWebDriver driver, WebDriverWait wait):base(driver, wait)    
        {
            this.driver = driver;
            this.wait = wait;
        }

        public DeleteAdminVerification DeleteAdmin(string empname)
        {
            SafeClick(Admin);
            SafestClick(Empname);
            Sendvalues(Empname, empname);
            By element=(By.XPath($"//div[@role='listbox']//span[normalize-space()='{empname}' and not(contains(@class,'hidden'))]"));
            if (IsElementVisible(element))
            {
                SafeClick(element);
                SafestClick(Searchbtn);
                SafestClick(Deletebtn);
                SafestClick(Delete);

            }
            SafestClick(Searchbtn);
            SafestClick(Deletebtn);
            SafestClick(Delete);
            return this;
        }

        public DeleteAdminVerification Verifydelete(string expected)
        {
            VerifyDelete(expected, VerifytoastMessage);
            return this;
        }
    }
}
