using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using con;
namespace WebApplication3
{
    public partial class view2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string t = Request.QueryString["t"];  // قيمة المتغير "t"
                    string id = Request.QueryString["id"]; // قيمة المتغير "id"
                    if (id != null)
                    {
                        fill_texts(id.ToString());
                        div.Visible = true;
                        //Response.Write(t);

                        if (t == "view" || t == "View")
                        {
                            string script = @"<script>Swal.fire({ title: 'View' });</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
                            Label1.Visible = false;
                            alert_dan.Visible = false;
                            connection c = new connection();
                            imgs.Visible = true;

                            img1.Attributes.Add("style", "background-image: url('" + c.updoc("card", "تجديد رخصة", id).ToString() + "')"); // صورة الهــويـة 
                           
                            img4.Attributes.Add("style", "background-image: url('" + c.updoc("Personal_photo", "تجديد رخصة", id).ToString() + "')"); // الصورة الشخصية
                     
                            //Response.Write(c.updoc("Personal_photo", "تجديد رخصة", id).ToString());


                        }
                        else if (t == "update")
                        {
                            string Email = con.get_Email_of_user("Licen_Renew", "License_renew_IP", id);
                            if (Email == "0" || Email != Session["userEmail"].ToString()) { Response.Redirect("~/Error404.aspx"); }

                            string script = @"<script>Swal.fire({ title: 'update' });</script>";
                            hide();
                            ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
                            Label1.Visible = true;
                            alert_dan.Visible = true;
                        }
                    }


                    else
                    { div.Visible = false; }
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    div.Visible = false;
                }

            }
        }
        protected void hide()
        {
            groupbtns.Visible = false;
            update.Visible = true;
            string script = @"<script>Swal.fire({ title: 'Update' });</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
        }
        int get_id()
        {
            try
            {
                string id = Request.QueryString["id"]; // قيمة المتغير "id"
                fill_texts(id.ToString());
                div.Visible = true;
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                // Response.Redirect("~/Error404.aspx");
                return 0;
            }


        }
        connection con = new connection();
        protected void confirm_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Licen_Renew", Session["userEmail"].ToString(), "License_renew_IP");
            con.UpdateOrderStatus(get_id(), "Licen_Renew", "مقبول", "License_renew_IP");
            groupbtns.Visible = false;
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Licen_Renew", Session["userEmail"].ToString(), "License_renew_IP");
            con.UpdateOrderStatus(get_id(), "Licen_Renew", "مرفوض", "License_renew_IP");
            groupbtns.Visible=false;
        }

        protected void edit_Click(object sender, EventArgs e)
        {con.WriteAdmin(get_id(), "Licen_Renew", Session["userEmail"].ToString(), "License_renew_IP");
            con.UpdateOrderStatus(get_id(), "Licen_Renew", "تعديل", "License_renew_IP");
            groupbtns.Visible = false;
            notes.Visible = true;
        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            
            con.WriteNotes(get_id(), "Licen_Renew", content.Text, "License_renew_IP");
            content.Text = "تم ارسال التعليق";
            content.ForeColor = System.Drawing.Color.Green;
            SendBTNew.Enabled = false;
        }
        void fill_texts(string id)
        {
            connection con = new connection();
            SqlConnection connection = new SqlConnection(con.SQL());
            connection.Open();

            string query = "SELECT License_renew_IP, Name,Notes, Old_license, Birth_day, Birth_place, Age, Job, Address_ip, Identity_ip, Status, DateofSend, TypeofRequest, IPofBook, Emailofuser, Oldlicepr, Oldlicexp, Center FROM Licen_Renew where License_renew_IP='" + id+"'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // 1 
                FullNameTBNew.Text = reader["Name"].ToString(); // الاسم الكامل 
                LicNum.Text = reader["Old_license"].ToString(); // رقم الرخصة القديم 
                Label1.Text = reader["Notes"].ToString();
                BirthDatNew.Text = Convert.ToDateTime(reader["Birth_day"]).ToString("yyyy-MM-dd"); // تاريخ الميلاد
                oldlicepr.Text = Convert.ToDateTime(reader["Oldlicepr"]).ToString("yyyy-MM-dd"); // تاريخ إصدار الرخصة القديمة
                oldlicexp.Text = Convert.ToDateTime(reader["Oldlicexp"]).ToString("yyyy-MM-dd"); // تاريخ إنتهى الرخصة القديمة
                center.Text = reader["Center"].ToString(); // مركز الاصدار
                BirthPlaceTBNew.Text = reader["Birth_place"].ToString();  // مكان الميلاد 
                AgeTB.Text = reader["Age"].ToString(); // العمر 
                OccupationTBNew.Text = reader["Job"].ToString(); // الوظيفة 
                string Address_ip = reader["Address_ip"].ToString();
                string Identity_ip = reader["Identity_ip"].ToString();
                reader.Close();

                //2
                string query2 = "SELECT Address_IP, Governorate, State, Street, Phone FROM Address  where  Address_IP = '" + Address_ip + "'";
                SqlCommand command2 = new SqlCommand(query2, connection);
                 reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    GovernorateTBNew.Text = reader["Governorate"].ToString(); // المحافظة
                    DirectorateTBNew.Text = reader["State"].ToString(); // المدنية
                    StreetTBNew.Text = reader["Street"].ToString(); // الحي
                    HouseNumberTBNEW.Text = reader["Phone"].ToString(); // الهاتف
                }
                reader.Close();

                //3
                string query3 = "SELECT Identy_IP, ID, Type, Produce_date, Produce_place FROM Identy where Identy_IP = '" + Identity_ip + "'";
                SqlCommand command3 = new SqlCommand(query3, connection);
                reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    IDNumberTBNew.Text = reader["ID"].ToString();
                    ReleaseDateNew.Text = Convert.ToDateTime(reader["Produce_date"]).ToString("yyyy-MM-dd"); // تاريخ إنتهى الرخصة القديمة
                    PlaceIssueTBNEW.Text = reader["Produce_place"].ToString();
                    string Type = reader["Type"].ToString();
                   
                    if (Type == "بطاقة شخصية")
                    { radiocard.Checked = true;  }
                    else 
                    {  radiopassport.Checked = true; }
                }



            }

            
            connection.Close();
        }
        public string getValue(string columnName, string id)
        {
            string tableName = "Licen_Renew";
            string value = null;
            connection conn = new connection();
            string connectionString = conn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT {columnName} FROM {tableName} WHERE License_renew_IP ='{id}'";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    value = reader[columnName].ToString();
                }
                reader.Close();
            }
            return value;
        }
        protected void update_Click(object sender, EventArgs e)
        {

            {
                string t = Request.QueryString["t"];
                string id = Request.QueryString["id"];
                string Identity_ip = getValue("Identity_ip", id);
                string Address_ip = getValue("Address_ip", id);
              
                connection conn = new connection();
                SqlConnection sqlConnection = new SqlConnection(conn.SQL());
                sqlConnection.Open();
                //Response.Write($"in update method      :{Identity_ip}   .   ");
                //Response.Write($"in update method      :{Address_ip}   .   ");
                // Update query for Identiy table
                string updateQuery1 = $"UPDATE Identy SET ID = @ID, Produce_date = @Produce_date, Produce_place = @Produce_place, Type = @Type WHERE Identy_IP = @Identy_IP";
                using (SqlCommand updateCommand1 = new SqlCommand(updateQuery1, sqlConnection))
                {
                    updateCommand1.Parameters.AddWithValue("@ID", IDNumberTBNew.Text);
                    updateCommand1.Parameters.AddWithValue("@Identy_IP", Identity_ip);
                    updateCommand1.Parameters.AddWithValue("@Type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                    updateCommand1.Parameters.AddWithValue("@Produce_date", ReleaseDateNew.Text);
                    updateCommand1.Parameters.AddWithValue("@Produce_place", PlaceIssueTBNEW.Text);
                    updateCommand1.ExecuteNonQuery();
                    Response.Write("after ex");
                }
                sqlConnection.Close();
                // Update query for Vehicle table
                sqlConnection.Open();
                string updateQuery2 = "UPDATE Address SET Governorate = @Governorate, State = @State, Street = @Street, Phone = @Phone WHERE Address_IP = @Address_IP;";
                using (SqlCommand updateCommand2 = new SqlCommand(updateQuery2, sqlConnection))
                {
                    updateCommand2.Parameters.AddWithValue("@Governorate", GovernorateTBNew.Text);
                    updateCommand2.Parameters.AddWithValue("@State", DirectorateTBNew.Text);
                    updateCommand2.Parameters.AddWithValue("@Street", StreetTBNew.Text);
                    updateCommand2.Parameters.AddWithValue("@Phone", HouseNumberTBNEW.Text);
                    updateCommand2.Parameters.AddWithValue("@Address_IP", Address_ip);
                    updateCommand2.ExecuteNonQuery();
                }
                sqlConnection.Close();
                // Update query for Owner table
                sqlConnection.Open();
                string updateQuery3 = "UPDATE Licen_Renew SET Name = @Name, Old_license = @Old_license, Birth_day = @Birth_day, Birth_place = @Birth_place, Age = @Age, Job = @Job, Oldlicexp = @Oldlicexp, Oldlicepr = @Oldlicepr, Center = @Center WHERE Identity_ip = @Identity_ip;";
                using (SqlCommand updateCommand3 = new SqlCommand(updateQuery3, sqlConnection))
                {
                    updateCommand3.Parameters.AddWithValue("@Name", FullNameTBNew.Text);
                    updateCommand3.Parameters.AddWithValue("@Old_license", LicNum.Text);
                    updateCommand3.Parameters.AddWithValue("@Birth_day", BirthDatNew.Text);
                    updateCommand3.Parameters.AddWithValue("@Birth_place", BirthPlaceTBNew.Text);
                    updateCommand3.Parameters.AddWithValue("@Age", AgeTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Job", OccupationTBNew.Text);
                    updateCommand3.Parameters.AddWithValue("@Oldlicexp", oldlicexp.Text);
                    updateCommand3.Parameters.AddWithValue("@Oldlicepr", oldlicepr.Text);
                    updateCommand3.Parameters.AddWithValue("@Center", center.Text);
                    updateCommand3.Parameters.AddWithValue("@Identity_ip", Identity_ip);
                    updateCommand3.ExecuteNonQuery();
                }
                sqlConnection.Close();
                con.UpdateOrderStatus(get_id(), "Licen_Renew", "قيد المراجعة", "License_renew_IP");
                Label1.Text = "تم إرسال التعديل بنجاح";
                update.Enabled = false;
            }
        }
    }
     
}