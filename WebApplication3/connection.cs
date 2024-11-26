using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApplication3;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace con
{

    public class connection
    {

        public string SQL()
        {

            //mrourcare            mrourcare-001      772466738Aa_
            string str;

            //فقيه
           str = "Data Source=REDMI8;Initial Catalog=MrourCare;Integrated Security=True;Encrypt=false;";

            //عطاس
            //str = "Data Source=ABOOOODI740;Initial Catalog=MrourCare;Integrated Security=True;Encrypt=false";

            //سليم
            //str = "Data Source=ABDULLAH\\SQLEXPRESS;Initial Catalog=MrourCare;Integrated Security=True;Encrypt=False";

            // server
          //  str = "Data Source=SQL8010.site4now.net;Initial Catalog=db_aa9556_mrourcare;User Id=db_aa9556_mrourcare_admin;Password=mrourcare-001;";

            return str; 
        }
        public SqlConnection con()
        {
            SqlConnection connection = new SqlConnection(SQL());
            return connection;
        }

        public System.Data.DataTable table(String sql)
        {
            SqlConnection con = new SqlConnection(SQL());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Close();
            da.Fill(dt);
            return dt;
        }
        public string updoc(string Typeofdoc, string TypeofRequet, string IdofReques)
        {
            string query = $"select Path from Documents where Type = '{Typeofdoc}' and TypeofRequet = N'{TypeofRequet}' and IdofRequest = '{IdofReques}'";
            using (SqlConnection connection = new SqlConnection(SQL()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string path = reader["Path"].ToString();
                        return path;
 
                    }
                    else
                    {
                        return "لا يوجد";
                    }
                }
            }
        }
        public void UpdateOrderStatus(int orderId, string orderType, string status, string id)
        { 
            using (SqlConnection connection = new SqlConnection(SQL()))
            {
                connection.Open();

                // تحديث حالة الطلب في الجدول المحدد
                string query = $"UPDATE {orderType} SET Status = @Status WHERE {id} = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@OrderID", orderId);

                command.ExecuteNonQuery();
            }
        }
        public void WriteNotes(int orderId, string orderType, string note, string id)
        {
            using (SqlConnection connection = new SqlConnection(SQL()))
            {
                connection.Open();

                // تحديث حالة الطلب في الجدول المحدد
                string query = $"UPDATE {orderType} SET Notes = @Notes WHERE {id} = @OrderID"; ;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Notes", note);
                command.Parameters.AddWithValue("@OrderID", orderId);

                command.ExecuteNonQuery();
            }
        }
        public void WriteAdmin(int orderId, string orderType, string email, string id)
        {
            using (SqlConnection connection = new SqlConnection(SQL()))
            {
                connection.Open();

                // تحديث حالة الطلب في الجدول المحدد
                string query = $"UPDATE {orderType} SET EmailofAdmin = @EmailofAdmin WHERE {id} = @OrderID"; ;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmailofAdmin", email);
                command.Parameters.AddWithValue("@OrderID", orderId);
                 
                command.ExecuteNonQuery();
            }
        }

        public string get_Email_of_user(string table_name ,string key_of_table , string order_id)
        {
            
            using (SqlConnection connection = new SqlConnection(SQL()))
            {
                string query = $"select Emailofuser from {table_name} where Status= N'تعديل'  and {key_of_table} =N'{order_id}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Emailofuser"].ToString();
                    }
                    else
                    {
                        return "0";

                    }
                }


            }
        }

    }
}