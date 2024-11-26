using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using con;

namespace WebApplication3
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnsign_Click(object sender, EventArgs e)
        {
            alert_suc.Visible = false;
            alert_dan.Visible = false;

            connection conn = new connection();
            SqlConnection sqlConnection = conn.con();

            try
            {
                 
                sqlConnection.Open();

                 
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, sqlConnection);
                checkEmailCommand.Parameters.AddWithValue("@Email", txtemail.Text);

                int emailCount = (int)checkEmailCommand.ExecuteScalar();

                if (emailCount > 0)
                {
                    
                    Label2.Text = "البريد الإلكتروني مستخدم بالفعل. يرجى استخدام بريد إلكتروني آخر.";
                    alert_dan.Visible = true;
                    return;
                }

                 
                string insertQuery = "INSERT INTO Users ( Phone, Name, Identity_card, Identity_type, Email, Password, Kind) " +
                                     "VALUES ( @Phone,@NAME, @Identity_card, @Identity_type, @Email, @Password, @Kind)";

                 
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                 
                
                insertCommand.Parameters.AddWithValue("@Phone", txtphone.Text);
                insertCommand.Parameters.AddWithValue("@Identity_card", txtidentity.Text);
                insertCommand.Parameters.AddWithValue("@Identity_type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                insertCommand.Parameters.AddWithValue("@Email", txtemail.Text);
                insertCommand.Parameters.AddWithValue("@Password", txtpass.Text);
                insertCommand.Parameters.AddWithValue("@Kind", "0");
                insertCommand.Parameters.AddWithValue("@NAME", tdd.Text);


                insertCommand.ExecuteNonQuery();

                 
                sqlConnection.Close();

                
                Label1.Text = "تم إنشاء الحساب بنجاح.";
                alert_suc.Visible = true;
            }
            catch (Exception ex)
            {
               
                Label2.Text = "حدث خطأ أثناء إنشاء الحساب. يرجى المحاولة مرة أخرى." + "\n" + ex.ToString();
                alert_dan.Visible = true;
            }
        }
        protected void radiocard_CheckedChanged(object sender, EventArgs e)
        {
            if (radiocard.Checked)
            {
                txtidentity.MaxLength = 10; // تعيين الحد الأقصى لـ 10 أرقام
                txtidentity.Text = "";
            }
            else if (radiopassport.Checked)
            {
                txtidentity.MaxLength = 15; // تعيين الحد الأقصى لـ 9 أرقام
                txtidentity.Text = "";
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}