using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApproachSelenium.DDT
{
    public class Dbreader
    {
        public static IEnumerable<object[]> GetLoginData()
        {
            string query = "SELECT TC_ID,Username, Password,Expected FROM LoginCheck;";
            DataTable dt = DBHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                yield return new object[] { row["TC_ID"].ToString(), row["Username"].ToString(), row["Password"].ToString(), row["Expected"].ToString() };
            }
        }

        public static IEnumerable<object[]> GetEmployeeData()
        {
            string query = "SELECT TC_ID,Username, Password,First_name,Middle_name,Last_name,Employee_id,u_name,Acc_pass,Confirm_pass,Expected FROM  EmployeeDetails;";
            DataTable dt = DBHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                yield return new object[] { row["TC_ID"].ToString(), row["Username"].ToString(), row["Password"].ToString(), row["First_name"].ToString() , row["Middle_name"].ToString(), row["Last_name"].ToString(), row["Employee_id"].ToString(), row["u_name"].ToString(), row["Acc_pass"].ToString(), row["Confirm_pass"].ToString(), row["Expected"].ToString() };
            }
        }
    }
}

