using con;
using System;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class login : System.Web.UI.Page
    {
        protected void Signinbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                Label1.Text = "يرجى ملء جميع الحقول.";
                alert_dan.Visible = true;
                return;
            }

            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string username = txtUserName.Text;
                string password = txtPassword.Text;
      
                // إنشاء استعلام SQL للحصول على المستخدم المطابق لاسم المستخدم وكلمة المرور
                string query = "SELECT * FROM Users where Email=@username and Password=@Password ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("username", username);
                        command.Parameters.AddWithValue("Password", password);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // تم العثور على المستخدم المطابق

                            // احتفظ بمعلومات التسجيل في جلسة المستخدم
                            while (reader.Read())
                            {
                                Response.Write(reader["Email"].ToString());
                                Response.Write(reader["Password"].ToString());
                                //string kind = reader["Kind"].ToString();
                                Session["userIP"] = reader["IP"].ToString();
                                //string userEmail = reader["Email"].ToString();
                                Session["userEmail"] = reader["Email"].ToString();
                                Session["user"] = "yes";
                                Session["kind"] = reader["Kind"].ToString();
                         
                            }
                            reader.Close();

                            // انتقل إلى صفحة أخرى بعد تسجيل الدخول بنجاح
                            Response.Redirect("~/Main.aspx");
                        }
                        else
                        {
                            // لم يتم العثور على المستخدم المطابق
                            Label1.Text = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                            alert_dan.Visible = true;
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Label1.Text = error+"هناك خطا ما.";
                alert_dan.Visible = true;
            }
             
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
    }
}