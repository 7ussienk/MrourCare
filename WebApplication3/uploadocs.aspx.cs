using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using con;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection.Emit;
using System.Security.Policy;
using NPOI.SS.Formula.Functions;
namespace WebApplication3
{
    public partial class uploadocs : System.Web.UI.Page
    {
        protected string id = "";
        protected string type = "";
        static connection conn = new connection();
        public SqlConnection sqlConnection = conn.con();

        protected void Page_Load(object sender, EventArgs e)

        {
           

            id = "";
            type = "";
            try
            {
                id = Request.QueryString["id"];
                type = Request.QueryString["type"];
                //string Email = Session["userEmail"].ToString();
                lblID.Text = id;
                lilType.Text = type;
                if (type == "إصدار رخصة")
                {
                    File1.Visible = true;
                    File2.Visible = true;
                    File3.Visible = true;
                    File4.Visible = true;
                    HIDE1.Visible = true;
                    HIDE2.Visible = true;
                }
                else
                {
                    File1.Visible = true;
                    HIDE1.Visible = false;
                    HIDE2.Visible = false;
                    File4.Visible = true;
                }
                /*
                img1.Attributes.Add("style", "background-image: url('" + GetPath("Card", type, id).ToString() + "')");
                img2.Attributes.Add("style", "background-image: url('" + GetPath("Personal_photo", type, id).ToString() + "')");
                img3.Attributes.Add("style", "background-image: url('" + GetPath("Blood_test", type, id).ToString() + "')");
                img4.Attributes.Add("style", "background-image: url('" + GetPath("Optical_test", type, id).ToString() + "')");
                */
            }                                                      
            catch (Exception ex)
            {
                lblID.Text = "لايوجد";
                lilType.Text = "لايوجد" + ex;
            }

         
            if (Session["userEmail"] == null)
            {
                string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
            }
            else
            {
            }
            // CheckSession();
            GrtPassPage();
            if (IsPostBack)
            {
            }
        }
        public void GrtPassPage()
        {


        }
        protected void CheckSession()
        {
            if (Session["userEmail"] == null)
            {
                // لا توجد جلسة، قم بتوجيه المستخدم إلى صفحة تسجيل الدخول
                Response.Redirect("login.aspx");
            }
            else
            {
                // توجد جلسة، يمكنك وضع الإجراءات الأخرى هنا
                // ...
            }
        }
        protected void SendBTNew_Click(object sender, EventArgs e)
        {

        }

        protected void SendBTNew_Click1(object sender, EventArgs e)
        {
            if (true)
            {
                alert_dan.Visible = false;
                string msg = "";
                error_1.Text = "";
                error_2.Text = "";
                error_3.Text = "";
                error_4.Text = "";
                string[] allowedFileTypes = { "image/jpeg", "image/png", "image/gif", "image/bmp", "image/tiff", "image/x-icon", "image/svg+xml", "image/webp" };
                bool missingFields = false; // متغير للتحقق مما إذا كانت هناك حقول مفقودة
                
                if (File1.HasFile) { }
                else
                {

                    missingFields = true;
                    error_1.Text = "    ◘ لقد نسيت إدخال صورة البطاقة أو جواز السفر";
                }
                if (File4.HasFile) { }
                else
                {
                    missingFields = true;
                    error_2.Text = "    ◘ لقد نسيت إدخال الصورة الشخصية";
                }
               


                if (type == "إصدار رخصة") 
                {
                    if (File2.HasFile) { }
                    else
                    {
                        missingFields = true;
                        error_4.Text = "     ◘ لقد نسيت إدخال فحص الدم";
                    }

                    if (File3.HasFile) { }
                    else
                    {
                        missingFields = true;
                        error_3.Text = "    ◘ لقد نسيت إدخال فحص النظر";
                    }
                    if (File1.HasFile == true && File2.HasFile == true && File3.HasFile == true && File4.HasFile == true)
                    {
                        save_card();
                        save_personal();
                        save_blood();
                        save_optical();
                    }
                }

                else if (type == "تجديد رخصة" || type == "رقم جديد" || type == "نقل ملكية")
                {
                    if (File1.HasFile == true && File4.HasFile == true)
                    {
                        save_card();
                        save_personal();

                    }

                }

                if (missingFields) { alert_dan.Visible = true; }

                string script = @"<script>Swal.fire({ title: 'تم رفع الصور بنجاح' });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SwalScript", script, false);
                SendBTNew.Enabled=false;
            }

        }

        protected void save_card()
        {
            sqlConnection.Open();
            String url_card;
            string fileExtension = Path.GetExtension(File1.FileName);
            string fileName = Path.GetFileName(File1.PostedFile.FileName);
            
            string url;
            id = Request.QueryString["id"];
            type = Request.QueryString["type"];
            string na = type + "_" + id;
            if (radiocard.Checked)
            {
                string filePath = Server.MapPath("/Documents/Cards/") + na + fileExtension;
                File1.SaveAs(filePath);
                

                url = "/Documents/Cards/" + type + "_" + id + fileExtension;
                url_card = url;
            
                string insertDocumentsQuery = "INSERT INTO Documents (Type, Path, IdofRequest, TypeofRequet) " +
                                              "VALUES (@Type, @Path, @IdofRequest, @TypeofRequet);";
                SqlCommand insertDocumentsCommand = new SqlCommand(insertDocumentsQuery, sqlConnection);
                insertDocumentsCommand.Parameters.AddWithValue("@Type", "Card");
                insertDocumentsCommand.Parameters.AddWithValue("@Path", url);
                insertDocumentsCommand.Parameters.AddWithValue("@IdofRequest", id);
                insertDocumentsCommand.Parameters.AddWithValue("@TypeofRequet", type);
                insertDocumentsCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            else
            {
                string filePath = Server.MapPath("/Documents/Passports/") + na + fileExtension;
                File1.SaveAs(filePath);
 
                url = "/Documents/Passports/" + type + "_" + id + fileExtension;
                
                 
                string insertDocumentsQuery = "INSERT INTO Documents (Type, Path, IdofRequest, TypeofRequet) " +
                                              "VALUES (@Type, @Path, @IdofRequest, @TypeofRequet);";
                SqlCommand insertDocumentsCommand = new SqlCommand(insertDocumentsQuery, sqlConnection);
                insertDocumentsCommand.Parameters.AddWithValue("@Type", "Passport");
                insertDocumentsCommand.Parameters.AddWithValue("@Path", url);
                insertDocumentsCommand.Parameters.AddWithValue("@IdofRequest", id);
                insertDocumentsCommand.Parameters.AddWithValue("@TypeofRequet", type);
                insertDocumentsCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }
        protected void save_personal()
        {
            id = Request.QueryString["id"];
            type = Request.QueryString["type"];

            sqlConnection.Open();
            string url_personal = "";
            string fileExtension = Path.GetExtension(File1.FileName);
            string fileName = Path.GetFileName(File1.PostedFile.FileName);
 
            string url;
            string na = type + "_" + id;
            string filePath = Server.MapPath("/Documents/Personal_Photo/") + na + fileExtension;
            url_personal = "h:\\root\\home\\mrourcare-001\\www\\mrourcare\\Documents\\Personal_Photo\\" + na + fileExtension;
            // h:\\root\\home\\mrourcare-001\\www\\mrourcare\\Documents\\Personal_Photo\\
            File4.SaveAs(filePath);
           
            url = "/Documents/Personal_Photo/" + type + "_" + id + fileExtension;
           
            string insertDocumentsQuery = "INSERT INTO Documents (Type, Path, IdofRequest, TypeofRequet) " +
                                          "VALUES (@Type, @Path, @IdofRequest, @TypeofRequet);";
            SqlCommand insertDocumentsCommand = new SqlCommand(insertDocumentsQuery, sqlConnection);
            insertDocumentsCommand.Parameters.AddWithValue("@Type", "Personal_photo");
            insertDocumentsCommand.Parameters.AddWithValue("@Path", url);
            insertDocumentsCommand.Parameters.AddWithValue("@IdofRequest", id);
            insertDocumentsCommand.Parameters.AddWithValue("@TypeofRequet", type);
            insertDocumentsCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        protected void save_blood()
        {
            id = Request.QueryString["id"];
            type = Request.QueryString["type"];

            sqlConnection.Open();
            String url_bload = "";
            string fileExtension = Path.GetExtension(File1.FileName);
            string fileName = Path.GetFileName(File1.PostedFile.FileName);
           
            string url;
            string na = type + "_" + id;
            string filePath = Server.MapPath("/Documents/Blood_Test/") + na + fileExtension;
            File2.SaveAs(filePath);
            // h:\\root\\home\\mrourcare-001\\www\\mrourcare\\Documents\\Blood_Test\\
            url = "/Documents/Blood_Test/" + type + "_" + id + fileExtension;
           
            string insertDocumentsQuery = "INSERT INTO Documents (Type, Path, IdofRequest, TypeofRequet) " +
                                          "VALUES (@Type, @Path, @IdofRequest, @TypeofRequet);";
            SqlCommand insertDocumentsCommand = new SqlCommand(insertDocumentsQuery, sqlConnection);
            insertDocumentsCommand.Parameters.AddWithValue("@Type", "Blood_test");
            insertDocumentsCommand.Parameters.AddWithValue("@Path", url);
            insertDocumentsCommand.Parameters.AddWithValue("@IdofRequest", id);
            insertDocumentsCommand.Parameters.AddWithValue("@TypeofRequet", type);
            insertDocumentsCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        protected void save_optical()
        {
            id = Request.QueryString["id"];
            type = Request.QueryString["type"];

            sqlConnection.Open();
            string url_checkEye = "";
            string fileExtension = Path.GetExtension(File1.FileName);
            string fileName = Path.GetFileName(File1.PostedFile.FileName);
           // string filePath1 = Server.MapPath("~/uploads/images/image.jpg");
            string url;
            string na = type + "_" + id;

           // string filePath = Server.MapPath("~/Documents/Optic_Test/") + na + fileExtension;
            string filePath = Server.MapPath("/Documents/Optic_Test/") + na + fileExtension;
            File3.SaveAs(filePath);

           
            url = "/Documents/Optic_Test/" + type + "_" + id + fileExtension;
            //img3.Attributes.Add("style", "background-image: url('/Documents/Optic_Test/" + na + fileExtension + "')");

            string insertDocumentsQuery = "INSERT INTO Documents (Type, Path, IdofRequest, TypeofRequet) " +
                                   "VALUES (@Type, @Path, @IdofRequest, @TypeofRequet);";
            SqlCommand insertDocumentsCommand = new SqlCommand(insertDocumentsQuery, sqlConnection);
            insertDocumentsCommand.Parameters.AddWithValue("@Type", "Optical_test");
            insertDocumentsCommand.Parameters.AddWithValue("@Path", url);
            insertDocumentsCommand.Parameters.AddWithValue("@IdofRequest",id);
            insertDocumentsCommand.Parameters.AddWithValue("@TypeofRequet",type);
            insertDocumentsCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        protected void CheckFileUploads()
        {/*   //lilError.Text = "";
            //CheckFileUploads();
            FileUpload[] fileUploads = { File1, File2, File3, File4 };
            bool[] fileValidity = new bool[fileUploads.Length];
            string[] fileNames = { "صورة الهوية", "صورة فحص الدم", "صورة فحص النظر", "الصورة الشخصية" };

            for (int i = 0; i < fileUploads.Length; i++)
            {
                fileValidity[i] = fileUploads[i].HasFile && IsValidImageFormat(fileUploads[i].PostedFile.ContentType);
            }

            bool allFilesValid = fileValidity.All(valid => valid);

            if (!allFilesValid)
            {
                for (int i = 0; i < fileUploads.Length; i++)
                {
                    if (!fileValidity[i])
                    {
                        string errorMessage = GetErrorMessage(fileUploads[i], fileNames[i]);
                        //lilError.Text += errorMessage + "<br/>";
                    }
                }
            }
            else
            {
                //lilError.Text = "تم تحميل جميع الملفات بنجاح.";
            }*/
        }

        protected bool IsValidImageFormat(string contentType)
        {
            string[] allowedFormats = { "image/jpeg", "image/png", "image/gif", "image/bmp", "image/tiff", "image/x-icon", "image/svg+xml", "image/webp" };
            return allowedFormats.Contains(contentType);
        }

        protected string GetErrorMessage(FileUpload fileUpload, string fileName)
        {
            if (!fileUpload.HasFile)
            {
                return $"لم يتم تحديد {fileName}.";
            }
            return $"صيغة {fileName} غير مقبولة.";
        }

        public string GetPath(string type, string typeofRequest, string idofRequest)
        {
            connection con = new connection();
            string connectionString = con.SQL();
            string path = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Path FROM Documents WHERE Type = N'" + type+ "' and TypeofRequet = N'" + typeofRequest + "' and IdofRequest = N'" + idofRequest+" '";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    { 

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                path = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                path = "Not Fond!!"+ ex;
            }

            return path;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}