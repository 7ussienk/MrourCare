using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using con;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WebApplication3
{
    public partial class bookappo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] == null)
            {
                string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
            }
            else
            {
                if (!IsPostBack)
                {
                    gen();
                }
            }


        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                FillDropDownList1();
                DropDownList1.Enabled = true;
                FillDropDownList1();
            }
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
        }

        protected void back_Click(object sender, EventArgs e)
        {
            DropDownList1.Enabled = true;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked == true)
            {
                DropDownList2.Enabled = true;
                FillDropDownList2();

            }
            DropDownList1.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioButton3.Checked == true)
            {
                DropDownList3.Enabled = true;
                FillDropDownList3();

            }
            DropDownList2.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioButton4.Checked == true)
            {
                DropDownList4.Enabled = true;
                FillDropDownList4();

            }
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList5.Enabled = false;
        }

        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioButton5.Checked == true)
            {
                DropDownList5.Enabled = true;
                FillDropDownList5();

            }
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList1.Enabled = false;
        }

        public void gen()
        {
            try
            {
                //string x = "  0  ";
                DateTime currentDate = DateTime.Now;
                DateTime startDate = currentDate.AddDays(1);

                List<DateTime> weekdays = new List<DateTime>();
                List<string> dayNames = new List<string>();

                while (weekdays.Count < 5)
                {
                    if (startDate.DayOfWeek != DayOfWeek.Friday && startDate.DayOfWeek != DayOfWeek.Saturday && CheckHoliday(startDate.ToString("yyyy-MM-dd")) == 0)
                    {

                        weekdays.Add(startDate);
                        dayNames.Add(GetArabicDayName(startDate.DayOfWeek));
                        int check = CheckResultsExist(startDate.ToString("yyyy-MM-dd"));

                        if (check == 0)
                        {
                            InsertData(startDate.ToString("yyyy-MM-dd"));

                        }

                    }
                    startDate = startDate.AddDays(1);
                }
                txt1.Text = dayNames[0];
                txt2.Text = dayNames[1];
                txt3.Text = dayNames[2];
                txt4.Text = dayNames[3];
                txt5.Text = dayNames[4];

                day1.Text = weekdays[0].ToString("yyyy-MM-dd");
                day2.Text = weekdays[1].ToString("yyyy-MM-dd");
                day3.Text = weekdays[2].ToString("yyyy-MM-dd");
                day4.Text = weekdays[3].ToString("yyyy-MM-dd");
                day5.Text = weekdays[4].ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
              
            }


        }
        private string GetArabicDayName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "الأحد";
                case DayOfWeek.Monday:
                    return "الاثنين";
                case DayOfWeek.Tuesday:
                    return "الثلاثاء";
                case DayOfWeek.Wednesday:
                    return "الأربعاء";
                case DayOfWeek.Thursday:
                    return "الخميس";
                default:
                    return "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             

                string order_id = Request.QueryString["id"];
                string order_type = Request.QueryString["type"];
                string name = "";
                string day = "";
                string Table_Name = "";

                string IPofBook = "";
                if (RadioButton1.Checked) { IPofBook = DropDownList1.SelectedValue; name = DropDownList1.SelectedItem.ToString(); day = day1.Text; }
                if (RadioButton2.Checked) { IPofBook = DropDownList2.SelectedValue; name = DropDownList2.SelectedItem.ToString(); day = day2.Text; }
                if (RadioButton3.Checked) { IPofBook = DropDownList3.SelectedValue; name = DropDownList3.SelectedItem.ToString(); day = day3.Text; }
                if (RadioButton4.Checked) { IPofBook = DropDownList4.SelectedValue; name = DropDownList4.SelectedItem.ToString(); day = day4.Text; }
                if (RadioButton5.Checked) { IPofBook = DropDownList5.SelectedValue; name = DropDownList5.SelectedItem.ToString(); day = day5.Text; }

                string updateQuery = "";
                string type_ = ""; //  نوع الطلب  باللغة العربية 
                string idT = "";
                if (order_type == "reNewLiesen") // تجديد رخصة
                {
                    type_ = "تجديد رخصة";
                    Table_Name = "Licen_Renew";
                    idT = "License_renew_IP";
                    updateQuery = "UPDATE  Licen_Renew SET IPofBook = @IPofBook WHERE License_renew_IP = @OrderId";
                }
                else if (order_type == "NewLiesen") // رخصة جديدة
                {
                    type_ = "إصدار رخصة";
                    Table_Name = "Licen_Request";
                    idT = "License_req_ip";
                    updateQuery = "UPDATE Licen_Request SET IPofBook = @IPofBook WHERE License_req_ip = @OrderId";

                }
                else if (order_type == "NewNumber") // 
                {
                    type_ = "رقم جديد";
                    Table_Name = "Owner";
                    idT = "Owner_IP";

                    updateQuery = "UPDATE Owner SET IPofBook = @IPofBook WHERE Owner_IP = @OrderId";

                }
                else if (order_type == "changeOnwer") // نقل ملكية 
                {
                    type_ = "نقل ملكية";
                    idT = "Property_ip";
                    Table_Name = "Property";
                    updateQuery = "UPDATE Property SET IPofBook = @IPofBook WHERE Property_ip = @OrderId";

                }

                connection x = new connection();
                string ss = x.SQL();
                using (SqlConnection connection = new SqlConnection(ss))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@IPofBook", IPofBook);
                    command.Parameters.AddWithValue("@OrderId", order_id);
                    command.ExecuteNonQuery();
                }

                using (SqlConnection connection = new SqlConnection(ss))
                {
                    Response.Write($"IPofBook - ايدي Timing  : {IPofBook} <br/>");
                    Response.Write($"order_id : {order_id} <br/>");
                    Response.Write($"الساعة : {name} <br/>");
                    Response.Write($"order_type : {order_type} <br/>");
                    string updateQuery_time = "UPDATE Timing SET Status =@Status WHERE ID = @ID ";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery_time, connection);
                    command.Parameters.AddWithValue("@Status", "1");

                    command.Parameters.AddWithValue("@ID", IPofBook);
                    command.ExecuteNonQuery();

                }
                string txt = $"تم الحجز في {day} - الساعة {name}";
                x.UpdateOrderStatus(Convert.ToInt32(order_id), Table_Name, txt, idT);
                Response.Redirect("~/requires.aspx");
            
             


        }


        public int CheckResultsExist(string date)
        {

            connection cn = new connection();
            string connectionString = cn.SQL();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID  FROM  Timing where Date = @Date";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);

                    object resultCount = command.ExecuteScalar();
                    int re = Convert.ToInt32(resultCount);
                    if (re > 0)
                    {
                        return 1;
                    }
                }
            }

            return 0;

        }
        public void InsertData(string data)
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "insert into Timing (Hours,Status,Date,Work_Status) VALUES ('8:00','0',@Data,'0'),('8:15','0',@Data,'0'),('8:30','0',@Data,'0'),('8:45','0',@Data,'0'),('9:00','0',@Data,'0'),('9:15','0',@Data,'0'),('9:30','0',@Data,'0'),('9:45','0',@Data,'0'),('10:00','0',@Data,'0'),('10:15','0',@Data,'0'),('10:30','0',@Data,'0'),('10:45','0',@Data,'0'),('11:00','0',@Data,'0'),('11:15','0',@Data,'0'),('11:30','0',@Data,'0'),('11:45','0',@Data,'0'),('12:00','0',@Data,'0')";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Data", data);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }

        }

        private void FillDropDownList1()
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string query = "SELECT ID, Hours  FROM  Timing where Date='" + day1.Text + "'and Status ='0' and Work_Status='0'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.DataSource = reader;
                        DropDownList1.DataTextField = "Hours"; // حقل النص الذي سيتم عرضه في DropDownList
                        DropDownList1.DataValueField = "ID"; // حقل القيمة الإضافي لكل عنصر في DropDownList
                        DropDownList1.DataBind();
                    }
                    else
                    {
                        DropDownList1.Items.Clear();
                        DropDownList1.Items.Insert(0, new ListItem("لاتوجد حجوزات  ، أختر يوم آخر", "0"));
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
        private void FillDropDownList2()
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string query = "SELECT ID, Hours  FROM  Timing where Date='" + day2.Text + "'and Status ='0' and Work_Status='0'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList2.Items.Clear();
                        DropDownList2.DataSource = reader;
                        DropDownList2.DataTextField = "Hours"; // حقل النص الذي سيتم عرضه في DropDownList
                        DropDownList2.DataValueField = "ID"; // حقل القيمة الإضافي لكل عنصر في DropDownList
                        DropDownList2.DataBind();
                    }
                    else
                    {
                        DropDownList2.Items.Clear();
                        DropDownList2.Items.Insert(0, new ListItem("لاتوجد حجوزات  ، أختر يوم آخر", "0"));
                    }



                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
        private void FillDropDownList3()
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string query = "SELECT ID, Hours  FROM  Timing where Date='" + day3.Text + "'and Status ='0' and Work_Status='0'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.DataSource = reader;
                        DropDownList3.DataTextField = "Hours"; // حقل النص الذي سيتم عرضه في DropDownList
                        DropDownList3.DataValueField = "ID"; // حقل القيمة الإضافي لكل عنصر في DropDownList
                        DropDownList3.DataBind();
                    }
                    else
                    {
                        DropDownList3.Items.Clear();
                        DropDownList3.Items.Insert(0, new ListItem("لاتوجد حجوزات  ، أختر يوم آخر", "0"));
                    }



                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //Response.Redirect("~/Error404.aspx");
            }
        }
        private void FillDropDownList4()
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string query = "SELECT ID, Hours  FROM  Timing where Date='" + day4.Text + "'and Status ='0' and Work_Status='0'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList4.Items.Clear();
                        DropDownList4.DataSource = reader;
                        DropDownList4.DataTextField = "Hours"; // حقل النص الذي سيتم عرضه في DropDownList
                        DropDownList4.DataValueField = "ID"; // حقل القيمة الإضافي لكل عنصر في DropDownList
                        DropDownList4.DataBind();
                    }
                    else
                    {
                        DropDownList4.Items.Clear();
                        DropDownList4.Items.Insert(0, new ListItem("لاتوجد حجوزات  ، أختر يوم آخر", "0"));
                    }



                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
        private void FillDropDownList5()
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                string query = "SELECT ID, Hours  FROM  Timing where Date='" + day5.Text + "'and Status ='0' and Work_Status='0'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DropDownList5.Items.Clear();
                        DropDownList5.DataSource = reader;
                        DropDownList5.DataTextField = "Hours"; // حقل النص الذي سيتم عرضه في DropDownList
                        DropDownList5.DataValueField = "ID"; // حقل القيمة الإضافي لكل عنصر في DropDownList
                        DropDownList5.DataBind();
                    }
                    else
                    {
                        DropDownList5.Items.Clear();
                        DropDownList5.Items.Insert(0, new ListItem("لاتوجد حجوزات  ، أختر يوم آخر", "0"));
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
        public int CheckHoliday(string input)
        {

            connection con = new connection();
            string connectionString = con.SQL();
            string query = "SELECT COUNT(*) FROM Holidays WHERE Holi = @Input";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Input", input);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        return 1; // المدخل موجود في الجدول
                    }
                    else
                    {
                        return 0; // المدخل غير موجود في الجدول
                    }
                }
            }
        }
    }

}