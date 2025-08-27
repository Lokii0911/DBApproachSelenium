using NUnit.Framework;
using DBApproachSelenium.DDT;
using DBApproachSelenium.Setup;
using DBApproachSelenium.DBApproach.TestCase;
using DBApproachSelenium.TestCase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApproachSelenium.Testcall
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class Test:Base
    {
        [Test, TestCaseSource(typeof(Dbreader), nameof(Dbreader.GetLoginData))]
        public void TC001_Logincheck(string testCase, string username, string password, string expected)
        {
            Login log = new Login(driver, wait);
            log.DoLogin(username, password);
            bool result = log.IsLoginSuccessful();

            if (expected == "pass")
            {
                Assert.That(result, Is.True, $"Expected login to succeed but it failed for {username}/{password}");
            }
            else
            {
                Assert.That(result, Is.False, $"Expected login to fail but it succeeded for {username}/{password}");
            }
        }


        [Test, TestCaseSource(typeof(Dbreader), nameof(Dbreader.GetEmployeeData))]
        public void TC003_AddEmployeeVerfication(string tcid, string login_id, string password, string firstName, string middleName, string lastName, string empId, string username, string emppass, string conpass, string expected)
        {
            Login log = new Login(driver, wait);
            AddEmployee add = new AddEmployee(driver, wait);
            log
                .DoLogin(login_id, password);
            add
                .Emp()
                .AddButton(firstName, middleName, lastName, empId)
                .logincredetials(username, emppass, conpass)
                .VerifyEmployeeSave(expected);
        }

        [Test, TestCaseSource(typeof(Dbreader),nameof(Dbreader.GetAdminData))]
        public void TC005_AdminAddVerification(string test_id, string login_id, string password, string empname, string username, string pass, string confpass, string expected)
        {
            AddAdmin adminadd = new AddAdmin(driver, wait);
            Login log = new Login(driver, wait);
            log
                .DoLogin(login_id, password);
            adminadd
                    .adminadd()
                    .detailsenroll(empname)
                    .enterpass(username, pass, confpass)
                    .VerifyAdminSave(expected);
        }

        [Test, TestCaseSource(typeof(Dbreader), nameof(Dbreader.DeleteEmployeeData))]
        public void TC005_DeleteEmployeeVerificatin(string login_id, string password, string empname, string expected)
        {
            DeleteEmpverification deleteemp = new DeleteEmpverification(driver, wait);
            Login log = new Login(driver, wait);
            log
                .DoLogin(login_id, password);
            deleteemp
                    .DeleteEmployee(empname)
                    .Verifydelete(expected);
        }

        [Test, TestCaseSource(typeof(Dbreader), nameof(Dbreader.DeleteAdminData))]
        public void TC005_DeleteAdminVerificatin(string login_id, string password, string empname, string expected)
        {
            DeleteAdminVerification deleteemp = new DeleteAdminVerification(driver, wait);
            Login log = new Login(driver, wait);
            log
                .DoLogin(login_id, password);
            deleteemp
                    .DeleteAdmin(empname)
                    .Verifydelete(expected);
        }

    }
}
