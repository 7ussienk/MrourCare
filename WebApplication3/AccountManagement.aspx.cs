using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using con;
using System.Data.SqlClient;
using System.Web.Security;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Web.Routing;
using System.Data;
using NPOI.SS.Formula.Functions;


namespace WebApplication3
{
    public partial class AccountManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sql_ = sql.Text;
                connection cn = new connection();
                //myListView.DataSource = cn.table(sql_).DefaultView;
                //myListView.DataBind();


                if (!IsPostBack)
                {
                    ListView1.DataSource = cn.table(sql_);
                    ListView1.DataBind();
                    // قراءة قيمة Session["userEmail"]
                    string userEmail = Session["userEmail"] as string;

                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        // استدعاء الدالة GetUserKindFromDatabase() للحصول على نوع المستخدم
                        int userKind = GetUserKindFromDatabase(userEmail);

                        if (userKind == 1) // المستخدمون الآخرون
                        {
                            btn_Emp.Visible = false;
                            btn_Mang.Visible = false;
                            bnt_Show_all.Visible = false;
                            // Button3.Visible = false;


                        }
                        else if (userKind == 2) // الموظفون
                        {

                        }


                        // استخدم قيمة نوع المستخدم بالطريقة التي تحتاجها
                        // ...
                    }
                    else
                    {
                        // البريد الإلكتروني غير متاح في الجلسة، قم باتخاذ إجراء مناسب
                        // ...
                    }
                }
                else
                {
                    ListView1.Items.Clear();
                    ListView1.DataSource = cn.table(sql_);
                    ListView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //Response.Redirect("~/Error404.aspx");
            }
        }
        private int GetUserKindFromDatabase(string userEmail)
        {
            int userKind = 0; // القيمة الافتراضية لنوع المستخدم

            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // استعلام SQL لاسترجاع نوع المستخدم
                    string query = "SELECT Kind FROM Users WHERE Email = @Email"; // استبدل "Email" بحقل البريد الإلكتروني في جدول المستخدمين
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", userEmail); // استخدام قيمة البريد الإلكتروني المقدمة
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        userKind = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //  Response.Redirect("~/Error404.aspx");
            }

            return userKind;
        }

        public bool power()
        {
            string kind;

            try { kind = Session["kind"].ToString(); }
            catch { kind = ""; }

            if (kind == "2") { return true; }
            else { return false; }
        }



        protected void bnt_Show_all_Click(object sender, EventArgs e)
        {
            sql.Text = "SELECT * FROM Users";
            string sql_ = sql.Text;
            connection cn = new connection();
            //myListView.DataSource = cn.table(sql_).DefaultView;
            //myListView.DataBind();
            ListView1.DataSource = cn.table(sql_);
            ListView1.DataBind();
        }

        protected void btnUp(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Button btnUp = (System.Web.UI.WebControls.Button)sender;
                DataListItem item = (DataListItem)btnUp.NamingContainer;
                System.Web.UI.WebControls.Label id_ = (System.Web.UI.WebControls.Label)item.FindControl("IP");
                System.Web.UI.WebControls.Label power = (System.Web.UI.WebControls.Label)item.FindControl("power");
                System.Web.UI.WebControls.Label lblSuss = (System.Web.UI.WebControls.Label)item.FindControl("lblSuss");
                System.Web.UI.WebControls.DropDownList ddl = (System.Web.UI.WebControls.DropDownList)item.FindControl("DropDownList1");
                string selectedValue = ddl.SelectedValue;
                lblSuss.Visible = true;
                lblSuss.Text = UpdateUser(id_.Text, selectedValue.ToString());
                if (selectedValue.ToString() == "0")
                {
                    power.Text = "عضو";
                }
                else if (selectedValue.ToString() == "1")
                {
                    power.Text = "موظف";

                }
                else if (selectedValue.ToString() == "2")
                {
                    power.Text = "مدير";

                }
                else if (selectedValue.ToString() == "3")
                {
                    power.Text = "أدمن";

                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //Response.Redirect("~/Error404.aspx");
            }


        }

        protected void btnUp_(object sender, EventArgs e)
        {
            try
            {

                System.Web.UI.WebControls.Button btnUp = (System.Web.UI.WebControls.Button)sender;

                System.Web.UI.WebControls.ListViewItem item = (System.Web.UI.WebControls.ListViewItem)btnUp.NamingContainer;
                System.Web.UI.WebControls.Label id_ = (System.Web.UI.WebControls.Label)item.FindControl("IP");
                System.Web.UI.WebControls.Label power = (System.Web.UI.WebControls.Label)item.FindControl("power");
                System.Web.UI.WebControls.Label lblSuss = (System.Web.UI.WebControls.Label)item.FindControl("lblSuss");
                System.Web.UI.WebControls.DropDownList ddl = (System.Web.UI.WebControls.DropDownList)item.FindControl("DropDownList1");
                string selectedValue = ddl.SelectedValue;
                lblSuss.Visible = true;
                if (selectedValue.ToString() != "-1")
                {
                    lblSuss.Text = UpdateUser(id_.Text, selectedValue.ToString());
                    lblSuss.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblSuss.Text = "قم بتحديد الصلاحية اولاً";
                    lblSuss.ForeColor = System.Drawing.Color.Red;



                }
                if (selectedValue.ToString() == "0")
                {
                    power.Text = "عضو";
                }
                else if (selectedValue.ToString() == "1")
                {
                    power.Text = "موظف";

                }
                else if (selectedValue.ToString() == "2")
                {
                    power.Text = "مدير";

                }
                else if (selectedValue.ToString() == "3")
                {
                    power.Text = "أدمن";

                }

                ListView1.DataBind();
                ListView1.DataBind();
                string script = @"<script>Swal.fire({ title: '! ترقية / تخفيض', text: 'تم التعديل بنجاح.', icon: 'success'});</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }


        }
        public string UpdateUser(string Ip, string Kind)
        {

            connection cn = new connection();
            string connectionString = cn.SQL();

            string query = "UPDATE Users SET Kind = @Kind WHERE IP = @Ip";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Kind", Kind);
                command.Parameters.AddWithValue("@Ip", Ip.ToString());

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0) { return "تم العملية بنجاح"; }
                else
                { return "حدث حطأ"; }
            }



        }

        protected void btn_Emp_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Text = "SELECT * FROM  Users where Kind =1";
                string sql_ = sql.Text;
                connection cn = new connection();
                //myListView.DataSource = cn.table(sql_).DefaultView;
                //myListView.DataBind();
                ListView1.DataSource = cn.table(sql_);
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void btn_Mang_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Text = "SELECT * FROM  Users where Kind =2";
                string sql_ = sql.Text;
                connection cn = new connection();
                //myListView.DataSource = cn.table(sql_).DefaultView;
                //myListView.DataBind();
                ListView1.DataSource = cn.table(sql_);
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
                Response.Redirect("~/Error404.aspx");
            }
        }

        protected void ByName_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Text = "select * from Users where Name like N'%" + searchBox.Text + "%'";
                string sql_ = sql.Text;
                connection cn = new connection();
                //myListView.DataSource = cn.table(sql_).DefaultView;
                //myListView.DataBind();
                ListView1.DataSource = cn.table(sql_);
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void ByEmail_Click(object sender, EventArgs e)
        {
            try
            {

                sql.Text = "select * from Users where Email like '%" + searchBox.Text + "%'";
                string sql_ = sql.Text;
                connection cn = new connection();
                //myListView.DataSource = cn.table(sql_).DefaultView;
                //myListView.DataBind();
                ListView1.DataSource = cn.table(sql_);
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }

        }
    }
}