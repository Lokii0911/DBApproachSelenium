using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DBApproachSelenium.DDT
{
    public static class DBHelper
    {
        private static string connectionString = "Server=DESKTOP-H7DJAQU\\SQLEXPRESS01;Database=TestAutomationDB;Integrated Security=True\"Server=DESKTOP-H7DJAQU\\\\SQLEXPRESS01;Database=TestAutomationDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        public static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

       /* public static void ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }*/
    }
}
