using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using con;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class view4 : System.Web.UI.Page
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
                            img1.Attributes.Add("style", "background-image: url('" + c.updoc("card", "نقل ملكية", id).ToString() + "')"); // صورة الهــويـة 

                            img4.Attributes.Add("style", "background-image: url('" + c.updoc("Personal_photo", "نقل ملكية", id).ToString() + "')"); // الصورة الشخصية


                        }
                        else if (t == "update")
                        {
                            string Email = con.get_Email_of_user("Property", "Property_ip", id);
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
                return 0;
            }


        }
        connection con = new connection();
        protected void confirm_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Property", Session["userEmail"].ToString(), "Property_ip");
            con.UpdateOrderStatus(get_id(), "Property", "مقبول", "Property_ip");
            groupbtns.Visible = false;

        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Property", Session["userEmail"].ToString(), "Property_ip");
            con.UpdateOrderStatus(get_id(), "Property", "مرفوض", "Property_ip");
            groupbtns.Visible = false;

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            con.WriteAdmin(get_id(), "Property", Session["userEmail"].ToString(), "Property_ip");
            con.UpdateOrderStatus(get_id(), "Property", "تعديل", "Property_ip");
            groupbtns.Visible = false;
            notes.Visible = true;
        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            con.WriteNotes(get_id(), "Property", content.Text, "Property_ip");
            content.Text = "تم ارسال التعليق";
            content.ForeColor = System.Drawing.Color.Green;
            SendBTNew.Enabled = false;
        }
        void fill_texts(string id)
        {
            connection con = new connection();
            SqlConnection connection = new SqlConnection(con.SQL());
            connection.Open();

            string query = "SELECT Property_ip, Identity_ip, Seller_name,Notes, Seller_address, Police_Center, Identity_type, Identity_number, Produce_date, Produce_from, Owner_name, Owner_address, Phone, Nationality, Governorate, State, Center, Village, Neighborhood, Street, Job, House_phone, Status, DateofSend, TypeofRequest, IPofBook, Vehicle_ip, Doc_of_property, Emailofuser FROM Property where Property_ip =  '" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // 1  بيانات المالك الجديد
                string Vehicle_ip = reader["Vehicle_ip"].ToString();
                Label1.Text = reader["Notes"].ToString();
                string Identity_ip = reader["Identity_ip"].ToString();
                OwnershipDocumentNumberTB.Text = reader["Doc_of_property"].ToString(); // رقم الوثيقة
                NewSellerNameTB.Text = reader["Seller_name"].ToString(); // اسم البائع 
                Address.Text = reader["Seller_address"].ToString(); // عنوان البائع 
                OldDepartmentTB.Text = reader["Police_Center"].ToString(); // ادارة الشرطة المسجل لديها المركبة 
                string Type = reader["Identity_type"].ToString(); //نوع الهوية
                if (Type == "جواز سفر")
                { radiopassport2.Checked = true; }
                else
                { radiocard2.Checked = true; }
                IDNumberTBNew.Text = reader["Identity_number"].ToString(); // رقم البطاقة أو الجواز 
                ReleaseDateNew.Text = Convert.ToDateTime(reader["Produce_date"]).ToString("yyyy-MM-dd"); //  تاريخ إصدار البطاقة أو الجواز 
                PlaceIssueTBNEW.Text = reader["Produce_from"].ToString(); // مكان الاصدار 
                NewOwnerNameTB.Text = reader["Owner_name"].ToString(); // اسم المالك الجديد 
                Address1.Text = reader["Owner_address"].ToString(); // عنوان المالك الجديد 
                PhoneNumberTB.Text = reader["Phone"].ToString(); // الهاتف 
                NationalityTB.Text = reader["Nationality"].ToString(); // الجنسية 
                GovernorateTB.Text = reader["Governorate"].ToString(); // المحافضة 
                DirectorateTB.Text = reader["State"].ToString(); // المديرية 
                CenterTB.Text = reader["Center"].ToString(); // المركز 
                VillageTB.Text = reader["Village"].ToString(); // القرية 
                NeighTB.Text = reader["Neighborhood"].ToString(); // الحي 
                StretTB.Text = reader["Street"].ToString(); // الشارع 
                Job.Text = reader["Job"].ToString(); // المهنة 
                HouseNumberTB.Text = reader["House_phone"].ToString(); // رقم المنزل 

                reader.Close();



                //2 معلومات الهوية
                string query3 = "SELECT Identy_IP, ID, Type, Produce_date, Produce_place FROM Identy where Identy_IP = '" + Identity_ip + "'";
                SqlCommand command3 = new SqlCommand(query3, connection);
                reader = command3.ExecuteReader();
                while (reader.Read())
                {

                    IDNumberTBNew2.Text = reader["ID"].ToString();

                    ReleaseDateNew2.Text = Convert.ToDateTime(reader["Produce_date"]).ToString("yyyy-MM-dd"); // تاريخ إنتهى الرخصة القديمة
                    PlaceIssueTBNEW2.Text = reader["Produce_place"].ToString();
                    string Type2 = reader["Type"].ToString();

                    if (Type2 == "بطاقة شخصية")
                    { radiocard.Checked = true; }
                    else
                    { radiopassport.Checked = true; }
                }

                reader.Close();

                string query2 = "SELECT IP, Plate_number, Plate_type, Vehicle_type, Vehicle_color, Produce_year, Engine_number, Potty_number, Card_management, Trailer_number, Type_trailer_number, Card_produce_management FROM Vehicle where IP = '" + Vehicle_ip + "'";
                SqlCommand command2 = new SqlCommand(query2, connection);
                reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    TypeVehicleDD.SelectedValue = reader["Vehicle_type"].ToString();// نوع المركبه 
                    PlateNumberTB.Text = reader["Plate_number"].ToString(); // رقم اللوحة المعدنية 
                    TypeNumberDD.SelectedValue = reader["Plate_type"].ToString(); // نوع الرقم 

                    ColorVehicleDD.SelectedValue = reader["Vehicle_color"].ToString(); // لون المركبة 
                    ManufacturingYearTB.Text = Convert.ToDateTime(reader["Produce_year"]).ToString("yyyy-MM-dd");  // سنة الصنع 
                    EngineNumberTB.Text = reader["Engine_number"].ToString(); // رقم المحرك 
                    DropDownList1.SelectedValue = reader["Potty_number"].ToString(); // نوع رقم المقطورة 
                    LicenseNumberTB.Text = reader["Type_trailer_number"].ToString(); // رقم رخصة التسيير|الكرتk 
                    VehicalSoldTB.Text = reader["Trailer_number"].ToString(); // رقم المقطورة المباعة 
                    CaNumberTB.Text = reader["Card_management"].ToString(); // 
                    LicenseNumberTBdate.Text = Convert.ToDateTime(reader["Card_produce_management"]).ToString("yyyy-MM-dd");   // تاريخ إصدار رخصة التسيير 

                }
            }

            connection.Close();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string t = Request.QueryString["t"];
            string id = Request.QueryString["id"];
            string Identity_ip = getValue("Identity_ip", id);
            string Vehicle_ip = getValue("Vehicle_ip", id);
            connection conn = new connection();
            SqlConnection sqlConnection = new SqlConnection(conn.SQL());
            sqlConnection.Open();
            Response.Write($"in update method      :{Identity_ip}   .   ");
            Response.Write($"          -  Vehicle_ip      :{Vehicle_ip}   .   ");
            Response.Write("in update method      : ");
            string updateQuery1 = $"UPDATE Identy SET ID = @ID, Produce_date = @Produce_date, Produce_place = @Produce_place, Type = @Type WHERE Identy_IP = @Identy_IP";
            using (SqlCommand updateCommand1 = new SqlCommand(updateQuery1, sqlConnection))
            {
                updateCommand1.Parameters.AddWithValue("@ID", IDNumberTBNew2.Text);
                updateCommand1.Parameters.AddWithValue("@Identy_IP", Identity_ip);
                updateCommand1.Parameters.AddWithValue("@Type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                updateCommand1.Parameters.AddWithValue("@Produce_date", ReleaseDateNew2.Text);
                updateCommand1.Parameters.AddWithValue("@Produce_place", PlaceIssueTBNEW2.Text);
                updateCommand1.ExecuteNonQuery();
                Response.Write("after ex");
            }
            sqlConnection.Close();
            sqlConnection.Open();
            // Update query for Vehicle table
            string updateQuery2 = "UPDATE Vehicle SET Plate_type = @Plate_type, Vehicle_type = @Vehicle_type, Vehicle_color = @Vehicle_color, Produce_year = @Produce_year, Engine_number = @Engine_number, Potty_number = @Potty_number, Card_management = @Card_management, Trailer_number = @Trailer_number, Type_trailer_number = @Type_trailer_number, Card_produce_management = @Card_produce_management, Plate_number = @Plate_number WHERE IP = @Vehicle_ip";
            using (SqlCommand updateCommand2 = new SqlCommand(updateQuery2, sqlConnection))
            {

                updateCommand2.Parameters.AddWithValue("@Vehicle_ip", Vehicle_ip);
                updateCommand2.Parameters.AddWithValue("@Plate_type", TypeNumberDD.Text);
                updateCommand2.Parameters.AddWithValue("@Plate_number", PlateNumberTB.Text);
                updateCommand2.Parameters.AddWithValue("@Vehicle_type", TypeVehicleDD.Text);
                updateCommand2.Parameters.AddWithValue("@Vehicle_color", ColorVehicleDD.Text);
                updateCommand2.Parameters.AddWithValue("@Produce_year", ManufacturingYearTB.Text);
                updateCommand2.Parameters.AddWithValue("@Engine_number", EngineNumberTB.Text);
                updateCommand2.Parameters.AddWithValue("@Potty_number", DropDownList1.Text);
                updateCommand2.Parameters.AddWithValue("@Card_management", CaNumberTB.Text);
                updateCommand2.Parameters.AddWithValue("@Trailer_number", VehicalSoldTB.Text);
                updateCommand2.Parameters.AddWithValue("@Type_trailer_number", LicenseNumberTB.Text);
                updateCommand2.Parameters.AddWithValue("@Card_produce_management", LicenseNumberTBdate.Text);
                updateCommand2.ExecuteNonQuery();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            string updateQuery5 = "UPDATE Property SET Doc_of_property = @Doc_of_property, Seller_name = @Seller_name, Seller_address = @Seller_address, Police_Center = @Police_Center, Identity_type = @Identity_type, Identity_number = @Identity_number, Produce_date = @Produce_date, Produce_from = @Produce_from, Owner_name = @Owner_name, Owner_address = @Owner_address, Phone = @Phone, Nationality = @Nationality, Governorate = @Governorate, State = @State, Center = @Center, Village = @Village, Neighborhood = @Neighborhood, Street = @Street, Job = @Job, House_phone = @House_phone WHERE Identity_ip = @Identity_ip";
            using (SqlCommand updateCommand5 = new SqlCommand(updateQuery5, sqlConnection))
            {
                updateCommand5.Parameters.AddWithValue("@Doc_of_property", OwnershipDocumentNumberTB.Text);
                updateCommand5.Parameters.AddWithValue("@Seller_name", NewSellerNameTB.Text);
                updateCommand5.Parameters.AddWithValue("@Seller_address", Address.Text);
                updateCommand5.Parameters.AddWithValue("@Police_Center", OldDepartmentTB.Text);
                updateCommand5.Parameters.AddWithValue("@Identity_type", radiopassport2.Checked ? "جواز سفر" : "بطاقة شخصية");
                updateCommand5.Parameters.AddWithValue("@Identity_number", IDNumberTBNew.Text);
                updateCommand5.Parameters.AddWithValue("@Produce_date", ReleaseDateNew.Text);
                updateCommand5.Parameters.AddWithValue("@Produce_from", PlaceIssueTBNEW.Text);
                updateCommand5.Parameters.AddWithValue("@Owner_name", NewOwnerNameTB.Text);
                updateCommand5.Parameters.AddWithValue("@Owner_address", Address1.Text);
                updateCommand5.Parameters.AddWithValue("@Phone", PhoneNumberTB.Text);
                updateCommand5.Parameters.AddWithValue("@Nationality", NationalityTB.Text);
                updateCommand5.Parameters.AddWithValue("@Governorate", GovernorateTB.Text);
                updateCommand5.Parameters.AddWithValue("@State", DirectorateTB.Text);
                updateCommand5.Parameters.AddWithValue("@Center", CenterTB.Text);
                updateCommand5.Parameters.AddWithValue("@Village", VillageTB.Text);
                updateCommand5.Parameters.AddWithValue("@Neighborhood", NeighTB.Text);
                updateCommand5.Parameters.AddWithValue("@Street", StretTB.Text);
                updateCommand5.Parameters.AddWithValue("@Job", Job.Text);
                updateCommand5.Parameters.AddWithValue("@House_phone", HouseNumberTB.Text);
                updateCommand5.Parameters.AddWithValue("@Identity_ip", Identity_ip);
                updateCommand5.ExecuteNonQuery();

            }
            sqlConnection.Close();
            con.UpdateOrderStatus(get_id(), "Property", "قيد المراجعة", "Property_ip");
            update.Enabled = false;
            Label1.Text = "تم إرسال التعديل بنجاح";
        }

        public string getValue(string columnName, string id)
        {
            string tableName = "Property";
            string value = null;
            connection conn = new connection();
            string connectionString = conn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = $"SELECT {columnName} FROM {tableName} WHERE Property_ip ='{id}'";
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
    }
}