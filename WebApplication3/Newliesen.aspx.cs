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
using System.Web.Routing;

namespace WebApplication3
{
    public partial class Newliesen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] == null)
            {
                string confirmScript = @"<script> Swal.fire({  title: 'يجب  عليك تسجيل الدخول اولًا',confirmButtonText: 'حسنا',}).then((result) => { if (result.isConfirmed) { window.location.href = 'login.aspx';} else { window.location.href = 'login.aspx'; } }) </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
                container.Visible = false;
            }
            else
            {
                string script = @"<script>Swal.fire({ title: 'إصدار رخصة' });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {

        }

        protected void send_Click1(object sender, EventArgs e)
        {

        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            try
            {

                connection conn = new connection();
                SqlConnection sqlConnection = conn.con();
                sqlConnection.Open();

                //Address

                string insertQuery = "INSERT INTO Address ( Governorate, State, Street, Phone) " +
                                     "VALUES ( @Governorate, @State, @Street, @Phone); SELECt SCOPE_IDENTITY();";
                SqlCommand insertCommand1 = new SqlCommand(insertQuery, sqlConnection);
                insertCommand1.Parameters.AddWithValue("@Governorate", GovernorateTBNew.Text);
                insertCommand1.Parameters.AddWithValue("@State", DirectorateTBNew.Text);
                insertCommand1.Parameters.AddWithValue("@Street", StreetTBNew.Text);
                insertCommand1.Parameters.AddWithValue("@Phone", HouseNumberTBNEW.Text);

                int addressId = Convert.ToInt32(insertCommand1.ExecuteScalar());

                //identy

                string insertQuery2 = "INSERT INTO identy ( ID, Produce_date, Produce_place,Type) " +
                                      "VALUES ( @ID, @Produce_date, @Produce_place ,@Identity_type); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand2 = new SqlCommand(insertQuery2, sqlConnection);
                insertCommand2.Parameters.AddWithValue("@ID", IDNumberTBNew.Text);
                insertCommand2.Parameters.AddWithValue("@Identity_type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                insertCommand2.Parameters.AddWithValue("@Produce_date", ReleaseDateNew.Text);
                insertCommand2.Parameters.AddWithValue("@Produce_place", PlaceIssueTBNEW.Text);
                int Identy_IP = Convert.ToInt32(insertCommand2.ExecuteScalar());


                //Liecen
                string insertQuery5 = "INSERT INTO Licen_Request (Name, Birth_day, Birth_place, Age, Job,Status,DateofSend,TypeofRequest,IPofBook, Address_ip, Identity_ip, Emailofuser) " +
                                      "VALUES (@Name, @Birth_day, @Birth_place, @Age, @Job,@Status,@DateofSend,@TypeofRequest,@IPofBook," +
                                      "@Address_IP, @Identy_IP, @Emailofuser); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand5 = new SqlCommand(insertQuery5, sqlConnection);
                insertCommand5.Parameters.AddWithValue("@Name", FullNameTBNew.Text);
                insertCommand5.Parameters.AddWithValue("@Birth_day", BirthDatNew.Text);
                insertCommand5.Parameters.AddWithValue("@Birth_place", BirthPlaceTBNew.Text);
                insertCommand5.Parameters.AddWithValue("@Age", AgeTB.Text);
                insertCommand5.Parameters.AddWithValue("@Job", OccupationTBNew.Text);
                insertCommand5.Parameters.AddWithValue("@Status", "قيد المراجعة");
                insertCommand5.Parameters.AddWithValue("@DateofSend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                insertCommand5.Parameters.AddWithValue("@TypeofRequest", "إصدار رخصة");
                insertCommand5.Parameters.AddWithValue("@IPofBook", "0");
                insertCommand5.Parameters.AddWithValue("@Address_IP", addressId.ToString());
                insertCommand5.Parameters.AddWithValue("@Identy_IP", Identy_IP.ToString());
                insertCommand5.Parameters.AddWithValue("@Emailofuser", Session["userEmail"].ToString());
                int ownerID = Convert.ToInt32(insertCommand5.ExecuteScalar());
                sqlConnection.Close();

                PassPage(ownerID.ToString(), "إصدار رخصة", "uploadocs.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<b> حدثت مشكلة  </b> <hr> " + ex.ToString());

            }
        }


        public void PassPage(string id, string type, string pageName)
        {
            string redirectUrl = $"{pageName}?id={HttpUtility.UrlEncode(id)}&type={HttpUtility.UrlEncode(type)}";
            Response.Redirect(redirectUrl);
        }
        protected void HouseNumberTBNEW_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BackBTNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(("/Main.aspx"));
        }
    }
}