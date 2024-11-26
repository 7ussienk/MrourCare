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

namespace WebApplication3
{
    public partial class NewNumberL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] == null)
            {
                // string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
                string confirmScript = @"<script> Swal.fire({  title: 'يجب  عليك تسجيل الدخول اولًا',confirmButtonText: 'حسنا',}).then((result) => { if (result.isConfirmed) { window.location.href = 'login.aspx';} else { window.location.href = 'login.aspx'; } }) </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
                container.Visible = false;

            }
            else
            {
                string script = @"<script>Swal.fire({ title: 'إصدار رقم جديد' });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
            }
        }

        protected void SendBT_Click(object sender, EventArgs e)
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
                insertCommand1.Parameters.AddWithValue("@Governorate", province.Text);
                insertCommand1.Parameters.AddWithValue("@State", DirectorateTB.Text);
                insertCommand1.Parameters.AddWithValue("@Street", StreetTB.Text);
                insertCommand1.Parameters.AddWithValue("@Phone", HouseNumberTB.Text);

                int addressId = Convert.ToInt32(insertCommand1.ExecuteScalar());
                // 
                //string script = "alert('" + addressId.ToString() + "');";
                // ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);


                // insert in too 
                //identy

                string insertQuery2 = "INSERT INTO identy ( ID, Produce_date, Produce_place,Type) " +
                                      "VALUES ( @ID, @Produce_date, @Produce_place ,@Type); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand2 = new SqlCommand(insertQuery2, sqlConnection);
                insertCommand2.Parameters.AddWithValue("@ID", IDNumberTB.Text);
                insertCommand2.Parameters.AddWithValue("@Type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                insertCommand2.Parameters.AddWithValue("@Produce_date", ReleaseDate.Text);
                insertCommand2.Parameters.AddWithValue("@Produce_place", PlaceIssueTB.Text);
                int Identy_IP = Convert.ToInt32(insertCommand2.ExecuteScalar());


                //Cousin 1
                string insertQuery3 = "INSERT INTO Cousin ( Name, ID, Adreess, Phone, ID_type) " +
                                      "VALUES " +
                                      " (@Name, @ID, @Adreess, @Phone, @ID_type); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand3 = new SqlCommand(insertQuery3, sqlConnection);
                insertCommand3.Parameters.AddWithValue("@Name", CousinOneTB.Text);
                insertCommand3.Parameters.AddWithValue("@ID", IDNumberCousinOneTB.Text);
                insertCommand3.Parameters.AddWithValue("@Adreess", txtaddress1.Text);
                insertCommand3.Parameters.AddWithValue("@Phone", PhoneNumberCousinOneTB.Text);
                insertCommand3.Parameters.AddWithValue("@ID_type", radiopassport2.Checked ? "جواز سفر" : "بطاقة شخصية");
                int Cousin_Ip_1 = Convert.ToInt32(insertCommand3.ExecuteScalar());



                // Cousin 2
                string insertQuery4 = "INSERT INTO Cousin (Name, ID, Adreess, Phone, ID_type) " +
                                      "VALUES" +
                                      " (@Name, @ID, @Adreess, @Phone ,@ID_type); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand4 = new SqlCommand(insertQuery4, sqlConnection);
                insertCommand4.Parameters.AddWithValue("@Name", CousinTwoTB.Text);
                insertCommand4.Parameters.AddWithValue("@ID", IDNumberCousinTwoTB.Text);
                insertCommand4.Parameters.AddWithValue("@Adreess", txtaddress2.Text);
                insertCommand4.Parameters.AddWithValue("@Phone", PhoneNumberCousinTwoTB.Text);
                insertCommand4.Parameters.AddWithValue("@ID_type", radiopassport3.Checked ? "جواز سفر" : "بطاقة شخصية");
                int Cousin_Ip_2 = Convert.ToInt32(insertCommand4.ExecuteScalar());




                //Owner
                string insertQuery5 = "INSERT INTO Owner (Name, Sex, Birth_day, Birth_place, Nationality, Job, Job_place, Address_ip, Identity_ip, Cousin_id1, Cousin_id2,Emailofuser ,Status,DateofSend,TypeofRequest,IPofBook) " +
                                      "VALUES (@Name, @Sex, @Birth_day, @Birth_place, @Nationality, @Job, @Job_place," +
                                      "@Address_IP, @Identy_IP,@Cousin_ID1,@Cousin_ID2, @Emailofuser, @Status, @DateofSend, @TypeofRequest, @IPofBook); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand5 = new SqlCommand(insertQuery5, sqlConnection);
                insertCommand5.Parameters.AddWithValue("@Name", FullNameTB.Text);
                insertCommand5.Parameters.AddWithValue("@Sex", GenderTB.Text);
                insertCommand5.Parameters.AddWithValue("@Birth_day", BirthDate.Text);
                insertCommand5.Parameters.AddWithValue("@Birth_place", BirthPlaceTB.Text);
                insertCommand5.Parameters.AddWithValue("@Nationality", NationalityTB.Text);
                insertCommand5.Parameters.AddWithValue("@Job", OccupationTB.Text);
                insertCommand5.Parameters.AddWithValue("@Job_place", ProfessionalTB.Text);

                insertCommand5.Parameters.AddWithValue("@Status", "قيد المراجعة");
                insertCommand5.Parameters.AddWithValue("@DateofSend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                insertCommand5.Parameters.AddWithValue("@TypeofRequest", "رقم جديد");
                insertCommand5.Parameters.AddWithValue("@IPofBook", "0");

                insertCommand5.Parameters.AddWithValue("@Address_IP", addressId.ToString());
                insertCommand5.Parameters.AddWithValue("@Identy_IP", Identy_IP.ToString());
                insertCommand5.Parameters.AddWithValue("@Cousin_ID1", Cousin_Ip_1.ToString());
                insertCommand5.Parameters.AddWithValue("@Cousin_ID2", Cousin_Ip_2.ToString());
                insertCommand5.Parameters.AddWithValue("@Emailofuser", Session["userEmail"].ToString());
                int ownerID = Convert.ToInt32(insertCommand5.ExecuteScalar());
                // end 



                // update updateCousin1

                string updateCousin1 = "UPDATE Cousin SET Owner_ip =@Owner_ip WHERE Cousin_ID = @CousinID";
                SqlCommand updateCommand1 = new SqlCommand(updateCousin1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@Owner_ip", ownerID.ToString());
                updateCommand1.Parameters.AddWithValue("@CousinID", Cousin_Ip_1);
                updateCommand1.ExecuteNonQuery();
                // استعادة التحقق من قيود المفتاح الخارجي



                // update updateCousin2
                string updateCousin2 = "UPDATE Cousin SET Owner_ip =@Owner_ip WHERE Cousin_ID = @CousinID";
                SqlCommand updateCommand2 = new SqlCommand(updateCousin2, sqlConnection);
                updateCommand2.Parameters.AddWithValue("@Owner_ip", ownerID.ToString());
                updateCommand2.Parameters.AddWithValue("@CousinID", Cousin_Ip_2);
                updateCommand2.ExecuteNonQuery();

                sqlConnection.Close();


                PassPage(ownerID.ToString(), "رقم جديد", "uploadocs.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<b> حدثت مشكلة  </b> <hr> "+ ex.ToString());
            }
        }
        public void PassPage(string id, string type, string pageName)
        {
            string redirectUrl = $"{pageName}?id={HttpUtility.UrlEncode(id)}&type={HttpUtility.UrlEncode(type)}";
            Response.Redirect(redirectUrl);
        }
    }
}