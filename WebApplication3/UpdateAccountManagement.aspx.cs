using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using con;
using System.Net;
using System.Web.Caching;

namespace WebApplication3
{
    public partial class UpdateAccountManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnsign1.Visible = false;
            if (Session["userEmail"] == null)
            {
                string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
            }
            else
            {
               
            }

        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlOptions.SelectedValue == "1")
            {
                btnsign1.Visible = true;
                Label4.Text = "ادخل كلمة المرور الجديدة";
                txtpass.Visible = true;
                txtpass.Text = "";
                alert_suc.Visible = false;
                alert_dan.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                

            }

            /*
            if (ddlOptions.SelectedValue == "2")
            {
                Label4.Text = "ادخل الايميل الجديد";
                txtpass.Visible = true;
                txtpass.Text = "";
                alert_suc.Visible = false;
                alert_dan.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;

            }*/
            if (ddlOptions.SelectedValue == "3")
            {
                btnsign1.Visible = true;
                Label4.Text = "ادخل رقم الهاتف الجديد";
                txtpass.Visible = true;
                txtpass.Text = "";
                alert_suc.Visible = false;
                alert_dan.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;

            }
            if (ddlOptions.SelectedValue == "0")
            {
                btnsign1.Visible = false;
                Label4.Text = "";
                txtpass.Visible = false;
                txtpass.Text = "";
                alert_suc.Visible = false;
                alert_dan.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;

            }


        }

        protected void btnsign1_Click(object sender, EventArgs e)
        {
            try
            {

                // قراءة قيمة Session["userEmail"]
                string userEmail = Session["userEmail"] as string;
                string userIP = Session["userIP"] as string;
                if (string.IsNullOrEmpty(userEmail))
                {
                    Label1.Text = "قم بكتابة كلمة مرور ";
                    Label1.Visible = true;
                    alert_suc.Visible = true;
                }
                else
                {
                    connection conn = new connection();
                    SqlConnection sqlConnection = conn.con();
                    sqlConnection.Open();
                    if (ddlOptions.SelectedValue == "1")
                    {
                        // تحديث كلمة المرور
                        string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Email = @Email";
                        SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
                        command.Parameters.AddWithValue("@NewPassword", txtpass.Text);
                        command.Parameters.AddWithValue("@Email", userEmail);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // تم تحديث كلمة المرور بنجاح
                            Label1.Text = "تم تغيير كلمة المرور بنجاح";
                            Label1.Visible = true;
                            alert_suc.Visible = true;
                            txtpass.Text = "";
                        }
                        else
                        {
                            // لم يتم العثور على المستخدم أو حدث خطأ في التحديث
                            Label2.Text = "فشل في تغيير كلمة المرور";
                            Label2.Visible = true;
                            alert_dan.Visible = true;
                            txtpass.Text = "";
                        }

                        sqlConnection.Close();
                     
                    }
                   
               

/*
                    if (ddlOptions.SelectedValue == "2")
                    {
                        try
                        {
                            // التحقق مما إذا كان البريد الإلكتروني الجديد قد استخدم بالفعل
                            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, sqlConnection);
                            checkCommand.Parameters.AddWithValue("@Email", txtpass.Text);

                            int emailCount = (int)checkCommand.ExecuteScalar();

                            if (emailCount > 0)
                            {
                                // تم استخدام البريد الإلكتروني بالفعل
                                Label2.Text = "عذرًا، البريد الإلكتروني المستخدم قد تم استخدامه بالفعل!";
                                Label2.Visible = true;
                                alert_dan.Visible = true;
                                txtpass.Text = "";
                            }
                            else
                            {
                                string updateQuery = "UPDATE Users SET Email = @NewEmail WHERE IP = @userIP";
                                SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
                                command.Parameters.AddWithValue("@NewEmail", txtpass.Text);
                                command.Parameters.AddWithValue("@userIP", userIP);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // تم تحديث البريد الإلكتروني بنجاح
                                    Label1.Text = "تم تغيير البريد الإلكتروني بنجاح";
                                    Label1.Visible = true;
                                    alert_suc.Visible = true;
                                    txtpass.Text = "";
                                }
                                else
                                {
                                    // لم يتم العثور على المستخدم أو حدث خطأ في التحديث
                                    Label2.Text = "فشل في تغيير البريد الإلكتروني";
                                    Label2.Visible = true;
                                    alert_dan.Visible = true;
                                    txtpass.Text = "";
                                }

                                sqlConnection.Close();
                            }
                        }
                        catch (Exception er)
                        {
                            // حدث خطأ أثناء التحقق من البريد الإلكتروني أو تحديثه
                            Label2.Text = "حدث خطأ أثناء تغيير البريد الإلكتروني: " + er.Message;
                            Label2.Visible = true;
                            alert_dan.Visible = true;
                            txtpass.Text = "";
                        }
                    }
*/
                    if (ddlOptions.SelectedValue == "3")
                    {


                        string updateQuery = "UPDATE Users SET Phone = @NewPhone WHERE IP = @userIP";
                        SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
                        command.Parameters.AddWithValue("@NewPhone", txtpass.Text);
                        command.Parameters.AddWithValue("@userIP", userIP);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // تم تحديث كلمة المرور بنجاح
                            Label1.Text = "تم تغيير رقم الهاتف بنجاح";
                            Label1.Visible = true;
                            alert_suc.Visible = true;
                            txtpass.Text = "";
                        }
                        else
                        {
                            // لم يتم العثور على المستخدم أو حدث خطأ في التحديث
                            Label2.Text = "فشل في تغيير رقم الهاتف";
                            Label2.Visible = true;
                            alert_dan.Visible = true;
                            txtpass.Text = "";
                        }
                        sqlConnection.Close();
                    }
                    if (ddlOptions.SelectedValue == "0")
                    {
                        Label4.Text = "";
                        txtpass.Visible = false;
                        sqlConnection.Close();
                        txtpass.Text = "";
                    }
                }

            }
            catch (Exception er)
            {
                string errorMessage = "  هناك عدة اخطاء يرجى التحقق من المدخلات وانهاتستخدم اول مرة ";
                string script = "alert('" + errorMessage + "\\n" + er.Message.Replace("'", "\\'") + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            btnsign1.Visible = false;

        }
    }
}
