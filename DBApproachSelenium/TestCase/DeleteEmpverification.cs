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
    public class DeleteEmpverification:Basefunction
    {
        private readonly IWebDriver driver; 
        private readonly WebDriverWait wait;

        private static readonly By PIM = By.XPath("//a[.//span[normalize-space()='PIM']]");
        private static readonly By Emplist = By.XPath("//a[contains(@class, 'nav-tab-item') and normalize-space()='Employee List']");
        private static readonly By Empname = By.XPath("//label[normalize-space()='Employee Name']/ancestor::div[contains(@class,'oxd-input-group')]//input");
        private static readonly By Searchbtn = By.XPath("//button[@type='submit']");
        private static readonly By Deletebtn = By.XPath("//button[@type='button']//i[@class='oxd-icon bi-trash']");
        private static readonly By Delete = By.XPath("//button[@type='button' and contains(@class,'oxd-button--label-danger') and normalize-space()='Yes, Delete']");
        private static readonly By VerifytoastMessage = By.XPath("//div[contains(@class,'oxd-toast-content')]");
        public DeleteEmpverification(IWebDriver driver, WebDriverWait wait):base(driver, wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public DeleteEmpverification DeleteEmployee(string empname)
        {
            SafestClick(PIM);
            SafestClick(Emplist);
            SafestClick(Empname);
            Sendvalues(Empname,empname);
            SafestClick(Searchbtn);
            SafestClick(Deletebtn);
            SafestClick(Delete);
            return this;
        }

        public DeleteEmpverification Verifydelete(string expected)
        {
            VerifyDelete(expected, VerifytoastMessage);
            return this;

        }
    }
}
