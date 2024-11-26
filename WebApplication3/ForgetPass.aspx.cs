using System;
using con;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class ForgetPass : System.Web.UI.Page
    {




        protected void Page_Load(object sender, EventArgs e)
        {
            verficationbtn.Visible = false;
            verficationtxt.Visible = false;
            lblpassword.Visible = false;
            editgmailbtn.Visible = false;
            alert_dan.Visible = false;
        }
        public class myclass
        {
            public static Random code = new Random();
            public static int vcode = code.Next(100000, 999999);

        }


        protected void Sendbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gmailtxt.Text))
            {
                Label1.Text = "يرجى ملء جميع الحقول.";
                Label1.Visible = true;
                alert_dan.Visible = true;
                return;
            }


            connection con = new connection();
            connection con1 = new connection();
            string to, from, pass, mail;
            to = gmailtxt.Text;
            from = "theyementraffic@gmail.com";
            mail = myclass.vcode.ToString();
            pass = "tguo givc jqvq mbvl";

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            SqlConnection sqlConnection1 = con1.con();
            sqlConnection1.Open();

            string query1 = "SELECT Name FROM users WHERE Email=@gmail";

            using (SqlCommand command1 = new SqlCommand(query1, sqlConnection1))
            {
                command1.Parameters.AddWithValue("@gmail", gmailtxt.Text);
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        message.Body = "  , مرحبًا " + name + "\n\nتم اكتشاف أنك قد نسيت كلمة المرور الخاصة بك في نظام Mrour Care. يرجى استخدام الكود التحقق لإعادة تعيين كلمة المرورالخاصة بك: \n \n\t\t\t\t\t\t\t\t\t   " + mail + "      \n\n1. Mrour Care. قم بزيارة صفحة استعادة كلمة المرور على  \n2. اتبع التعليمات لإعادة تعيين كلمة المرور الخاصة بك.\n\n.إذا كنت لم تقم بإجراء أي طلب لإعادة تعيين كلمة المرور فيرجى تجاهل هذه الرسالة \n\n\t\t\t .Mrour Care شكرًا لاستخدامك نظام ";
                        string passwordResetUrl = "https://localhost:44321/ForgetPass.aspx";
                        message.Body += "\n\n:يرجى زيارة الرابط التالي لإعادة تعيين كلمة المرور\n " + passwordResetUrl;
                        message.Subject = "Mrour Care - استعادة كلمة المرور";
                        message.Body += "  " + DateTime.Now.ToString() + " : تاريخ الإرسال";
                        string username = "العقيد شفيق";
                        string contactInfo = "Phone: 772466738\nEmail: theyementraffic@gmail.com";
                        message.Body += "\n\n ـــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ\n";
                        message.Body += "اسم المدير: " + username + "\n";
                        message.Body += " :معلومات الاتصال" + "\n" + contactInfo;
                    }

                }
            }
            sqlConnection1.Close();
           // string imagePath = "h:\\root\\home\\mrourcare-001\\www\\mrourcare\\Documents\\Prints\\\\images\\care.jpg"; // تحديد مسار الصورة


            //Attachment attachment = new Attachment(imagePath);
           // message.Attachments.Add(attachment);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                SqlConnection sqlConnection = con.con();
                sqlConnection.Open();
                string query = "SELECT * FROM users WHERE Email=@gmail";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@gmail", gmailtxt.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                verficationbtn.Visible = true;
                                Sendbtn.Visible = false;
                                verficationtxt.Visible = true;
                                lblpassword.Visible = true;
                                lblusername.Visible = false;
                                gmailtxt.Visible = false;
                                editgmailbtn.Visible = true;

                                smtp.Send(message);
                                string script = "alert('تم إرسال رمز التحقق بنجاح! يرجى التحقق من بريدك الإلكتروني.');";
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                                gmailtxt.Visible = false;
                                lblusername.Visible = false;
                                editgmailbtn.Visible = true;
                                Sendbtn.Visible = false;
                                txtconfnewpass.Visible = false;
                                TextBoxnewpass.Visible = false;
                                Labelnewpass.Visible = false;
                                Labelnewpass2.Visible = false;
                                taked.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                string error = ex.ToString();
                            }
                        }
                        else
                        {
                            string script = "alert('لا يوجد بريد إلكتروني مطابق!!');";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                            gmailtxt.Visible = true;
                            lblusername.Visible = true;
                            Sendbtn.Visible = true;

                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void verficationbtn_Click(object sender, EventArgs e)
        {

            if (verficationtxt.Text == myclass.vcode.ToString())
            {
                gmailtxt.Visible = false;
                lblusername.Visible = false;
                editgmailbtn.Visible = false;
                Sendbtn.Visible = false;
                txtconfnewpass.Visible = true;
                TextBoxnewpass.Visible = true;
                Labelnewpass.Visible = true;
                Labelnewpass2.Visible = true;
                taked.Visible = true;
                string script = "alert('تم التحقق بنجاح!');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);



            }
            else
            {
                gmailtxt.Visible = false;
                lblusername.Visible = false;
                verficationtxt.Visible = true;
                Sendbtn.Visible = false;
                txtconfnewpass.Visible = false;
                TextBoxnewpass.Visible = false;
                Labelnewpass.Visible = false;
                Labelnewpass2.Visible = false;
                taked.Visible = false;
                verficationbtn.Visible = true;
                verficationbtn.Visible = true;
                Sendbtn.Visible = false;
                verficationtxt.Visible = true;
                lblpassword.Visible = true;
                lblusername.Visible = false;
                gmailtxt.Visible = false;
                editgmailbtn.Visible = true;
            }
            string scrip = "alert('رمز التحقق غير صحيح، يرجى التحقق من البريد الإلكتروني مرة أخرى!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", scrip, true);
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (txtconfnewpass.Text == TextBoxnewpass.Text)
            {
                connection con = new connection();
                string connectionString = con.SQL();
                string newPassword = TextBoxnewpass.Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Email = @Email";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@Email", gmailtxt.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // تم تحديث كلمة المرور بنجاح
                        Label1.Text = "تم تغيير كلمة المرور بنجاح";
                        Label1.Visible = true;
                        alert_dan.Visible = true;
                    }
                    else
                    {
                        // لم يتم العثور على المستخدم أو حدث خطأ في التحديث
                        Label1.Text = "فشل في تغيير كلمة المرور";
                        Label1.Visible = true;
                        alert_dan.Visible = true;
                    }
                    connection.Close();
                }
            }
            else
            {
                // إظهار رسالة خطأ بعدم تطابق كلمة المرور
                Label1.Text = "كلمة المرور غير متطابقة";
                Label1.Visible = true;
                alert_dan.Visible = true;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void editgmailbtn_Click(object sender, EventArgs e)
        {
            gmailtxt.Visible = true;
            lblusername.Visible = true;
            editgmailbtn.Visible = false;
            Sendbtn.Visible = true;
        }

        private bool CheckEmailExists(string email)
        {
            connection con = new connection();
            SqlConnection sqlConnection = new SqlConnection(con.SQL());
            sqlConnection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email = @Email";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Email", email);
            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                verficationbtn.Visible = false;
                verficationtxt.Visible = false;
                lblpassword.Visible = false;
                editgmailbtn.Visible = false;
                alert_dan.Visible = true;
                return false;
            }
        }

        private void ShowErrorMessage(string message)
        {
            Label1.Visible = true;
            Label1.Text = message;
            alert_dan.Visible = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int vcode = Convert.ToInt32(vcodeHiddenField.Value);

            vcode += 3524;
            if (vcode == 99999)
            {
                vcode = 3524;
            }

            vcodeHiddenField.Value = vcode.ToString();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}