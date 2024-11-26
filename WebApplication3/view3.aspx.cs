using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using con;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;

namespace WebApplication3
{
    public partial class view3 : System.Web.UI.Page
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
                        if (t == "view")
                        {
                            string script = @"<script>Swal.fire({ title: 'View' });</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
                            Label1.Visible = false;
                            alert_dan.Visible = false;
                            connection c = new connection();
                            imgs.Visible = true;

                            img1.Attributes.Add("style", "background-image: url('" + c.updoc("card", "رقم جديد", id).ToString() + "')"); // صورة الهــويـة 
                            
                            img4.Attributes.Add("style", "background-image: url('" + c.updoc("Personal_photo", "رقم جديد", id).ToString() + "')"); // الصورة الشخصية


                        }
                        else if (t == "update")
                        {
                            string Email = con.get_Email_of_user("Owner", "Owner_IP", id);
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
                    // Response.Redirect("~/Error404.aspx");
                    div.Visible = false;
                }
            }
        }
        public string getValue(string columnName, string id)
        {
            string tableName = "Owner";
            string value = null;
            connection conn = new connection();
            string connectionString = conn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT {columnName} FROM {tableName} WHERE Owner_IP ='{id}'";
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
            con.WriteAdmin(get_id(), "Owner", Session["userEmail"].ToString(), "Owner_IP");
            con.UpdateOrderStatus(get_id(), "Owner", "مقبول", "Owner_IP");
            groupbtns.Visible = false;
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Owner", Session["userEmail"].ToString(), "Owner_IP");
            con.UpdateOrderStatus(get_id(), "Owner", "مرفوض", "Owner_IP");
            groupbtns.Visible = false;
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Owner", Session["userEmail"].ToString(), "Owner_IP");
            con.UpdateOrderStatus(get_id(), "Owner", "تعديل", "Owner_IP");
            groupbtns.Visible = false;
            notes.Visible = true;
        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            con.WriteNotes(get_id(), "Owner", content.Text, "Owner_IP");
            content.Text = "تم ارسال التعليق";
            content.ForeColor = System.Drawing.Color.Green;
            SendBTNew.Enabled = false;
        }
        void fill_texts(string id)
        {
            connection con = new connection();
            SqlConnection connection = new SqlConnection(con.SQL());
            connection.Open();

            string query = " SELECT  Owner_IP, Name, Sex,Notes, Birth_day, Birth_place, Nationality, Job, Job_place, Address_ip, Identity_ip, Cousin_id1, Cousin_id2, Status, DateofSend, TypeofRequest, IPofBook, Emailofuser FROM Owner where Owner_IP=  '" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // 1  بيانات المالك
                FullNameTB.Text = reader["Name"].ToString(); // الاسم الكامل 
                GenderTB.Text = reader["Sex"].ToString(); // الجنس 
                BirthDate.Text = Convert.ToDateTime(reader["Birth_day"]).ToString("yyyy-MM-dd"); // تاريخ الميلاد
                BirthPlaceTB.Text = reader["Birth_place"].ToString();  // مكان الميلاد 
                NationalityTB.Text = reader["Nationality"].ToString(); // الجنسية  
                OccupationTB.Text = reader["Job"].ToString(); // المهنة  
                ProfessionalTB.Text = reader["Job_place"].ToString(); // جهه وعنوان العمل 
                string Address_ip = reader["Address_ip"].ToString();
                Label1.Text = reader["Notes"].ToString();
                string Identity_ip = reader["Identity_ip"].ToString();
                string Owner_IP = reader["Owner_IP"].ToString();
                reader.Close();


                //2 معلومات الهوية
                string query3 = "SELECT Identy_IP, ID, Type, Produce_date, Produce_place FROM Identy where Identy_IP = '" + Identity_ip + "'";
                SqlCommand command3 = new SqlCommand(query3, connection);
                reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    IDNumberTB.Text = reader["ID"].ToString();
                    ReleaseDate.Text = Convert.ToDateTime(reader["Produce_date"]).ToString("yyyy-MM-dd"); // تاريخ إنتهى الرخصة القديمة
                    PlaceIssueTB.Text = reader["Produce_place"].ToString();
                    string Type = reader["Type"].ToString();

                    if (Type == "بطاقة شخصية")
                    { radiocard.Checked = true; }
                    else
                    { radiopassport.Checked = true; }
                }
                reader.Close();

                //3
                string query2 = "SELECT Address_IP, Governorate, State, Street, Phone FROM Address  where  Address_IP = '" + Address_ip + "'";
                SqlCommand command2 = new SqlCommand(query2, connection);
                reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    province.Text = reader["Governorate"].ToString(); // المحافظة
                    DirectorateTB.Text = reader["State"].ToString(); // المدنية
                    StreetTB.Text = reader["Street"].ToString(); // الحي
                    HouseNumberTB.Text = reader["Phone"].ToString(); // الهاتف
                }
                reader.Close();

                //4
                string query4 = "SELECT Cousin_ID, Name, ID, Adreess, Phone, Owner_ip, ID_type FROM Cousin WHERE Owner_ip = '" + Owner_IP + "'";
                SqlCommand command4 = new SqlCommand(query4, connection);
                reader = command4.ExecuteReader();
                List<string> cousinIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> IDs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phones = new List<string>();
                List<string> ownerIPs = new List<string>();
                List<string> IDTypes = new List<string>();

                while (reader.Read())
                {
                    cousinIDs.Add(Convert.ToString(reader["Cousin_ID"]));
                    names.Add(Convert.ToString(reader["Name"]));
                    IDs.Add(Convert.ToString(reader["ID"]));
                    addresses.Add(Convert.ToString(reader["Adreess"]));
                    phones.Add(Convert.ToString(reader["Phone"]));
                    ownerIPs.Add(Convert.ToString(reader["Owner_ip"]));
                    IDTypes.Add(Convert.ToString(reader["ID_type"]));
                }

                if (cousinIDs.Count > 0)
                {
                    // الشاهد 1
                    CousinOneTB.Text = names[0]; // الاسم
                    txtaddress1.Text = addresses[0]; // العنوان 
                    string Type2 = IDTypes[0]; // نوع البطاقة
                    IDNumberCousinOneTB.Text = IDs[0]; // ايدي الهوية 
                    PhoneNumberCousinOneTB.Text = phones[0];

                    if (Type2 == "بطاقة شخصية")
                    {
                        radiocard2.Checked = true;
                    }
                    else
                    {
                        radiopassport2.Checked = true;
                    }

                    // الشاهد 2
                    CousinTwoTB.Text = names[1]; // الاسم
                    txtaddress2.Text = addresses[1]; // العنوان
                    string Type3 = IDTypes[1]; // نوع البطاقة
                    IDNumberCousinTwoTB.Text = IDs[1]; // ايدي الهوية 
                    PhoneNumberCousinTwoTB.Text = phones[1]; // رقم الجوال

                    if (Type3 == "بطاقة شخصية")
                    {
                        radiocard3.Checked = true;
                    }
                    else
                    {
                        radiopassport3.Checked = true;
                    }
                }


            }


            connection.Close();
        }

        protected void update_Click1(object sender, EventArgs e)
        {
            {
                string t = Request.QueryString["t"];
                string id = Request.QueryString["id"];
                string Identity_ip = getValue("Identity_ip", id);
                string Address_ip = getValue("Address_ip", id);
                string Cousin_ID = getValue("Cousin_id1", id);
                string Cousin_ID2 = getValue("Cousin_id2", id);
                connection conn = new connection();
                SqlConnection sqlConnection = new SqlConnection(conn.SQL());
                sqlConnection.Open();
                Response.Write($"in update method      :{Identity_ip}   .   ");
                Response.Write($"in update method      :{Address_ip}   .   ");
                // Update query for Identiy table
                string updateQuery1 = $"UPDATE Identy SET ID = @ID, Produce_date = @Produce_date, Produce_place = @Produce_place, Type = @Type WHERE Identy_IP = @Identy_IP";
                using (SqlCommand updateCommand1 = new SqlCommand(updateQuery1, sqlConnection))
                {
                    updateCommand1.Parameters.AddWithValue("@ID", IDNumberTB.Text);
                    updateCommand1.Parameters.AddWithValue("@Identy_IP", Identity_ip);
                    updateCommand1.Parameters.AddWithValue("@Type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                    updateCommand1.Parameters.AddWithValue("@Produce_date", ReleaseDate.Text);
                    updateCommand1.Parameters.AddWithValue("@Produce_place", PlaceIssueTB.Text);
                    updateCommand1.ExecuteNonQuery();
                    Response.Write("after ex");
                }
                sqlConnection.Close();
                // Update query for Vehicle table
                sqlConnection.Open();
                string updateQuery2 = "UPDATE Address SET Governorate = @Governorate, State = @State, Street = @Street, Phone = @Phone WHERE Address_IP = @Address_IP;";
                using (SqlCommand updateCommand2 = new SqlCommand(updateQuery2, sqlConnection))
                {
                    updateCommand2.Parameters.AddWithValue("@Governorate", province.Text);
                    updateCommand2.Parameters.AddWithValue("@State", DirectorateTB.Text);
                    updateCommand2.Parameters.AddWithValue("@Street", StreetTB.Text);
                    updateCommand2.Parameters.AddWithValue("@Phone", HouseNumberTB.Text);
                    updateCommand2.Parameters.AddWithValue("@Address_IP", Address_ip);
                    updateCommand2.ExecuteNonQuery();
                }
                sqlConnection.Close();
                // Update query for Owner table
                sqlConnection.Open();
                string updateQuery3 = "UPDATE Owner SET Name = @Name, Sex = @Sex, Birth_day = @Birth_day, Birth_place = @Birth_place, Nationality = @Nationality, Job = @Job, Job_place = @Job_place WHERE Identity_ip = @Identity_ip;";
                using (SqlCommand updateCommand3 = new SqlCommand(updateQuery3, sqlConnection))
                {
                    updateCommand3.Parameters.AddWithValue("@Name", FullNameTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Sex", GenderTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Birth_day", BirthDate.Text);
                    updateCommand3.Parameters.AddWithValue("@Birth_place", BirthPlaceTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Nationality", NationalityTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Job", OccupationTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Job_place", ProfessionalTB.Text);
                    updateCommand3.Parameters.AddWithValue("@Identity_ip", Identity_ip);
                    updateCommand3.ExecuteNonQuery();
                }
                sqlConnection.Close();
                // Update cousin 1
                sqlConnection.Open();
                string updateQuery4 = "UPDATE Cousin SET Name = @Name, ID = @ID, Adreess = @Adreess, Phone = @Phone, ID_type = @ID_type WHERE Cousin_ID = @Cousin_ID;";
                using (SqlCommand updateCommand4 = new SqlCommand(updateQuery4, sqlConnection))
                {
                    updateCommand4.Parameters.AddWithValue("@Name", CousinOneTB.Text);
                    updateCommand4.Parameters.AddWithValue("@ID", IDNumberCousinOneTB.Text);
                    updateCommand4.Parameters.AddWithValue("@Adreess", txtaddress1.Text);
                    updateCommand4.Parameters.AddWithValue("@Phone", PhoneNumberCousinOneTB.Text);
                    updateCommand4.Parameters.AddWithValue("@ID_type", radiopassport2.Checked ? "جواز سفر" : "بطاقة شخصية");
                    updateCommand4.Parameters.AddWithValue("@Cousin_ID", Cousin_ID);
                    updateCommand4.ExecuteNonQuery();
                }
                sqlConnection.Close();
                // Update cousin 2
                sqlConnection.Open();
                string updateQuery5 = "UPDATE Cousin SET Name = @Name, ID = @ID, Adreess = @Adreess, Phone = @Phone, ID_type = @ID_type WHERE Cousin_ID = @Cousin_ID2;";
                using (SqlCommand updateCommand5 = new SqlCommand(updateQuery5, sqlConnection))
                {
                    updateCommand5.Parameters.AddWithValue("@Name", CousinTwoTB.Text);
                    updateCommand5.Parameters.AddWithValue("@ID", IDNumberCousinTwoTB.Text);
                    updateCommand5.Parameters.AddWithValue("@Adreess", txtaddress2.Text);
                    updateCommand5.Parameters.AddWithValue("@Phone", PhoneNumberCousinTwoTB.Text);
                    updateCommand5.Parameters.AddWithValue("@ID_type", radiopassport3.Checked ? "جواز سفر" : "بطاقة شخصية");
                    updateCommand5.Parameters.AddWithValue("@Cousin_ID2", Cousin_ID2);
                    updateCommand5.ExecuteNonQuery();
                }
                sqlConnection.Close();
                con.UpdateOrderStatus(get_id(), "Owner", "قيد المراجعة", "Owner_IP");
                Label1.Text = "تم إرسال التعديل بنجاح";
                update.Enabled = false;
            }
        }
    }
}