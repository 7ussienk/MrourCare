using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using con;
using NPOI.SS.Formula.Functions;
namespace WebApplication3
{

    public partial class BookAppoForAdmin : System.Web.UI.Page
    {
        public void gen()
        {
            try
            {
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
                Label1.Text = dayNames[0];
                Label2.Text = dayNames[1];
                Label3.Text = dayNames[2];
                Label4.Text = dayNames[3];
                Label5.Text = dayNames[4];

                day1.Text = weekdays[0].ToString("yyyy-MM-dd");
                day2.Text = weekdays[1].ToString("yyyy-MM-dd");
                day3.Text = weekdays[2].ToString("yyyy-MM-dd");
                day4.Text = weekdays[3].ToString("yyyy-MM-dd");
                day5.Text = weekdays[4].ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                 
            }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userEmail"] = "abdallahalshibami@gmail.com";
            if (Session["userEmail"] == null)
            {
                string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
            }
            else
            {
                Button2.Enabled = false;
                Button7.Enabled = false;
                Button3.Enabled = false;
                Button8.Enabled = false;
                Button4.Enabled = false;
                Button9.Enabled = false;
                Button5.Enabled = false;
                Button10.Enabled = false;
                Button6.Enabled = false;
                Button11.Enabled = false;
                DropDownList1.Enabled = false;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = false;
            }

            if (!IsPostBack)
            {
                gen();
                FillDropDownList1(day1.Text);
                Button2.Enabled = true;
                Button7.Enabled = true;
                DropDownList1.Enabled = true;


            }

        }

        protected void FillDropDownList1(string date)
        {
            try
            {
                DropDownList1.Items.Clear();
                connection con = new connection();
                string connectionString = con.SQL();
                string query = "SELECT ID,Status ,Hours, Work_Status FROM Timing where Date='" + date + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader["Hours"].ToString(), reader["ID"].ToString());

                        if (reader["Work_Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: red;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "0")
                        {
                            item.Attributes["style"] = "color: green;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: blue;";
                        }
                        else
                        {
                            item.Attributes["style"] = "color: yellow;";

                        }

                        DropDownList1.Items.Add(item);
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
        private string UpdateWorkStatus(DropDownList list, string d)
        {


            string id = list.SelectedValue;
            string name = list.SelectedItem.Text;
            string message = "";

            connection con = new connection();
            string connectionString = con.SQL();
            string query = "SELECT Work_Status, Status FROM Timing WHERE ID = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int workStatus = Convert.ToInt32(reader["Work_Status"]);
                    int status = Convert.ToInt32(reader["Status"]);

                    if (workStatus == 0 && status == 0)
                    {
                        // Perform the update
                        string updateQuery = "UPDATE Timing SET Work_Status = 1 WHERE ID = @id";

                        using (SqlConnection updateConnection = new SqlConnection(connectionString))
                        {
                            SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection);
                            updateCommand.Parameters.AddWithValue("@id", id);
                            updateConnection.Open();
                            updateCommand.ExecuteNonQuery();
                        }

                        message = " تم التعطيل " + " الساعه " + name + " بتاريخ  :" + d;
                    }
                    else if (workStatus == 1 && status == 0)
                    {
                        message = " لا يمكنك التعديل ، لان الساعة " + name + " بتاريخ : " + d + " .. معطلة اصلا.";
                    }
                    else if (workStatus == 0 && status == 1)
                    {
                        message = "لا يمكنك التعطيل لأن الموعد محجوز في الساعة : " + name + " بتاريخ : " + d;
                    }
                }
                else
                {

                    message = "حدث خطا اثناء عمل التعديل !!";
                }
            }

            return message;
        }
        protected void FillDropDownList2(string date)
        {
            try
            {
                DropDownList2.Items.Clear();
                connection con = new connection();
                string connectionString = con.SQL();
                string query = "SELECT ID,Status ,Hours, Work_Status FROM Timing where Date='" + date + "'";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader["Hours"].ToString(), reader["ID"].ToString());

                        if (reader["Work_Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: red;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "0")
                        {
                            item.Attributes["style"] = "color: green;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: blue;";
                        }
                        else
                        {
                            item.Attributes["style"] = "color: yellow;";

                        }

                        DropDownList2.Items.Add(item);
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
        protected void FillDropDownList3(string date)
        {
            try
            {
                DropDownList3.Items.Clear();
                connection con = new connection();
                string connectionString = con.SQL();
                string query = "SELECT ID,Status ,Hours, Work_Status FROM Timing where Date='" + date + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader["Hours"].ToString(), reader["ID"].ToString());

                        if (reader["Work_Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: red;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "0")
                        {
                            item.Attributes["style"] = "color: green;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: blue;";
                        }
                        else
                        {
                            item.Attributes["style"] = "color: yellow;";

                        }
                        DropDownList3.Items.Add(item);
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
        protected void FillDropDownList4(string date)
        {
            try
            {
                DropDownList4.Items.Clear();
                connection con = new connection();
                string connectionString = con.SQL();
                string query = "SELECT ID,Status ,Hours, Work_Status FROM Timing where Date='" + date + "'";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader["Hours"].ToString(), reader["ID"].ToString());

                        if (reader["Work_Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: red;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "0")
                        {
                            item.Attributes["style"] = "color: green;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: blue;";
                        }
                        else
                        {
                            item.Attributes["style"] = "color: yellow;";

                        }
                        DropDownList4.Items.Add(item);
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
        protected void FillDropDownList5(string date)
        {
            try
            {
                DropDownList5.Items.Clear();
                connection con = new connection();
                string connectionString = con.SQL();
                string query = "SELECT ID,Status ,Hours, Work_Status FROM Timing where Date='" + date + "'";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader["Hours"].ToString(), reader["ID"].ToString());

                        if (reader["Work_Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: red;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "0")
                        {
                            item.Attributes["style"] = "color: green;";
                        }
                        else if (reader["Work_Status"].ToString() == "0" && reader["Status"].ToString() == "1")
                        {
                            item.Attributes["style"] = "color: blue;";
                        }
                        else
                        {
                            item.Attributes["style"] = "color: yellow;";

                        }

                        DropDownList5.Items.Add(item);
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
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == true)
            {
                DropDownList1.Enabled = false;
                Button4.Enabled = true;
                Button9.Enabled = true;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = true;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = false;
                FillDropDownList3(day3.Text);
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                DropDownList1.Enabled = true;
                Button2.Enabled = true;
                Button7.Enabled = true;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = false;
                FillDropDownList1(day1.Text);
            }

        }
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                DropDownList1.Enabled = false;
                Button3.Enabled = true;
                Button8.Enabled = true;
                DropDownList2.Enabled = true;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = false;
                FillDropDownList2(day2.Text);
            }

        }
        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.Checked == true)
            {
                DropDownList1.Enabled = false;
                Button5.Enabled = true;
                Button10.Enabled = true;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = true;
                DropDownList5.Enabled = false;
                FillDropDownList4(day4.Text);
            }
        }
        protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox5.Checked == true)
            {
                DropDownList1.Enabled = false;
                Button6.Enabled = true;
                Button11.Enabled = true;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = true;
                FillDropDownList5(day5.Text);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string msg = UpdateWorkStatus(DropDownList1, Label1.Text + " - " + day1.Text);
            alter.Text = msg;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = UpdateWorkStatus(DropDownList2, Label2.Text + " - " + day2.Text);
                alter.Text = msg;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = UpdateWorkStatus(DropDownList3, Label3.Text + " - " + day3.Text);
                alter.Text = msg;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = UpdateWorkStatus(DropDownList4, Label4.Text + " - " + day4.Text);
                alter.Text = msg; ;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = UpdateWorkStatus(DropDownList5, Label5.Text + " - " + day5.Text);
                alter.Text = msg;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }

        }


        protected void remove_day(string txtday, string date_name)
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select COUNT(Status) as 'Status' from Timing where Date='{txtday}' and Status=0 ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                string book_stat = "";
                while (reader.Read())
                {
                    book_stat = reader["Status"].ToString();
                }
                if (book_stat == "17")
                {
                    add_holyday(txtday);
                    alter.Text = $"تم تعطيل هذا اليوم {date_name}  - {txtday} بنجاح.";
                }
                else
                {
                    alter.Text = $"- لا يمكنك تعطيل هذا اليوم {date_name} - {txtday} ، لان هنالك حجوزات مسبقة .";

                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
        public void add_holyday(string date_)
        {
            try
            {
                connection cn = new connection();
                string connectionString = cn.SQL();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"insert into Holidays (Holi) VALUES (@date_)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date_", date_);
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

        protected void btn_day1(object sender, EventArgs e)
        {
            try
            {
                remove_day(day1.Text, Label1.Text);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void btn2(object sender, EventArgs e)
        {
            try
            {
                remove_day(day2.Text, Label2.Text);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void btn3(object sender, EventArgs e)
        {
            try
            {
                remove_day(day3.Text, Label3.Text);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void btn4(object sender, EventArgs e)
        {
            try
            {
                remove_day(day4.Text, Label4.Text);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
               // Response.Redirect("~/Error404.aspx");
            }
        }

        protected void btn5(object sender, EventArgs e)
        {
            try
            {
                remove_day(day5.Text, Label5.Text);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
            }
        }
    }

}