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
    public partial class changeowner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] == null)
            {
                string confirmScript = @"<script> Swal.fire({  title: 'يجب  عليك تسجيل الدخول اولًا',confirmButtonText: 'حسنا',}).then((result) => { if (result.isConfirmed) { window.location.href = 'login.aspx';} else { window.location.href = 'login.aspx'; } }) </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
                // string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
                container.Visible = false;

            }
            else
            {
                string script = @"<script>Swal.fire({ title: 'نقل الملكية' });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
            }

        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            try
            {
                connection conn = new connection();
                SqlConnection sqlConnection = conn.con();
                sqlConnection.Open();

                //identy of seller
                string insertQuery1 = "INSERT INTO identy ( ID, Produce_date, Produce_place,Type) " +
                                  "VALUES ( @ID, @Produce_date, @Produce_place ,@Type); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand1 = new SqlCommand(insertQuery1, sqlConnection);
                insertCommand1.Parameters.AddWithValue("@ID", IDNumberTBNew2.Text);
                insertCommand1.Parameters.AddWithValue("@Type", radiopassport.Checked ? "جواز سفر" : "بطاقة شخصية");
                insertCommand1.Parameters.AddWithValue("@Produce_date", ReleaseDateNew2.Text);
                insertCommand1.Parameters.AddWithValue("@Produce_place", PlaceIssueTBNEW2.Text);
                int Identy_IP = Convert.ToInt32(insertCommand1.ExecuteScalar());

                //Vihcle
                string insertQuery2 = "INSERT INTO Vehicle ( Plate_number, Plate_type, Vehicle_type, Vehicle_color, Produce_year, Engine_number, Potty_number,Card_management, Trailer_number, Type_trailer_number, Card_produce_management) " +
                                      "VALUES ( @Plate_number, @Plate_type, @Vehicle_type, @Vehicle_color, @Produce_year, @Engine_number, @Potty_number, @Card_management, @Trailer_number, @Type_trailer_number, @Card_produce_management); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand2 = new SqlCommand(insertQuery2, sqlConnection);
                insertCommand2.Parameters.AddWithValue("@Plate_number", PlateNumberTB.Text);
                insertCommand2.Parameters.AddWithValue("@Plate_type", TypeNumberDD.Text);
                insertCommand2.Parameters.AddWithValue("@Vehicle_type", TypeVehicleDD.Text);
                insertCommand2.Parameters.AddWithValue("@Vehicle_color", ColorVehicleDD.Text);
                insertCommand2.Parameters.AddWithValue("@Produce_year", ManufacturingYearTB.Text);
                insertCommand2.Parameters.AddWithValue("@Engine_number", EngineNumberTB.Text);
                insertCommand2.Parameters.AddWithValue("@Potty_number", CaNumberTB.Text);
                insertCommand2.Parameters.AddWithValue("@Card_management", LicenseNumberTB.Text);
                insertCommand2.Parameters.AddWithValue("@Trailer_number", VehicalSoldTB.Text);
                insertCommand2.Parameters.AddWithValue("@Type_trailer_number", DropDownList1.Text);
                insertCommand2.Parameters.AddWithValue("@Card_produce_management", LicenseNumberTBdate.Text);

                int Vihcle_ip = Convert.ToInt32(insertCommand2.ExecuteScalar());




                //RenewLiecen
                string insertQuery5 = "INSERT INTO Property (Doc_of_property, Seller_name, Seller_address, Police_Center, Identity_type, Identity_number, Produce_date, Produce_from, Owner_name, Owner_address, Phone, Nationality, Governorate, State, Center, Village, Neighborhood, Street, Job, Status, DateofSend, TypeofRequest, IPofBook, House_phone, Identity_ip, Vehicle_ip, Emailofuser) " +
                                      "VALUES (@Doc_of_property, @Seller_name, @Seller_address, @Police_Center, @Identity_type, @Identity_number, @Produce_date, @Produce_from, @Owner_name, @Owner_address, @Phone, @Nationality, @Governorate, @State, @Center, @Village, @Neighborhood, @Street, @Job, @Status, @DateofSend, @TypeofRequest, @IPofBook, @House_phone," +
                                      "@Identy_IP, @Vihcle_ip,@Emailofuser); SELECT SCOPE_IDENTITY();";

                SqlCommand insertCommand5 = new SqlCommand(insertQuery5, sqlConnection);
                insertCommand5.Parameters.AddWithValue("@Doc_of_property", OwnershipDocumentNumberTB.Text);
                insertCommand5.Parameters.AddWithValue("@Seller_name", NewSellerNameTB.Text);
                insertCommand5.Parameters.AddWithValue("@Seller_address", Address.Text);
                insertCommand5.Parameters.AddWithValue("@Police_Center", OldDepartmentTB.Text);
                insertCommand5.Parameters.AddWithValue("@Identity_type", radiopassport2.Checked ? "جواز سفر" : "بطاقة شخصية");
                insertCommand5.Parameters.AddWithValue("@Identity_number", IDNumberTBNew.Text);
                insertCommand5.Parameters.AddWithValue("@Produce_date", ReleaseDateNew.Text);
                insertCommand5.Parameters.AddWithValue("@Produce_from", PlaceIssueTBNEW.Text);
                insertCommand5.Parameters.AddWithValue("@Owner_name", NewOwnerNameTB.Text);
                insertCommand5.Parameters.AddWithValue("@Owner_address", Address1.Text);
                insertCommand5.Parameters.AddWithValue("@Phone", PhoneNumberTB.Text);
                insertCommand5.Parameters.AddWithValue("@Nationality", NationalityTB.Text);
                insertCommand5.Parameters.AddWithValue("@Governorate", GovernorateTB.Text);
                insertCommand5.Parameters.AddWithValue("@State", DirectorateTB.Text);
                insertCommand5.Parameters.AddWithValue("@Center", CenterTB.Text);
                insertCommand5.Parameters.AddWithValue("@Village", VillageTB.Text);
                insertCommand5.Parameters.AddWithValue("@Neighborhood", NeighTB.Text);
                insertCommand5.Parameters.AddWithValue("@Street", StretTB.Text);
                insertCommand5.Parameters.AddWithValue("@Job", Job.Text);
                insertCommand5.Parameters.AddWithValue("@House_phone", HouseNumberTB.Text);
                insertCommand5.Parameters.AddWithValue("@Status", "قيد المراجعة");
                insertCommand5.Parameters.AddWithValue("@DateofSend", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                insertCommand5.Parameters.AddWithValue("@TypeofRequest", "نقل ملكية");
                insertCommand5.Parameters.AddWithValue("@IPofBook", "0");
                insertCommand5.Parameters.AddWithValue("@Emailofuser", Session["userEmail"].ToString());
                insertCommand5.Parameters.AddWithValue("@Vihcle_ip", Vihcle_ip.ToString());
                insertCommand5.Parameters.AddWithValue("@Identy_IP", Identy_IP.ToString());
                insertCommand5.ExecuteNonQuery();
                int ownerID = Convert.ToInt32(insertCommand5.ExecuteScalar());
                sqlConnection.Close();
                PassPage(ownerID.ToString(), "نقل ملكية", "uploadocs.aspx");
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
    }
}