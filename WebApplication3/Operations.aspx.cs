using con;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.IO;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NGS.Templater;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.XWPF.UserModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Xceed.Words.NET;
using System.Collections;

using DocumentFormat.OpenXml.Drawing.Charts;
using NPOI.SS.Formula.Functions;
namespace WebApplication3
{
    public partial class Operations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            connection cn = new connection();


            if (!IsPostBack)
            {
                string sql_ = " SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin FROM  Licen_Request " +
                "          UNION ALL SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend,Status as 'order_status', TypeofRequest as 'order_Type', Emailofuser , (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin FROM Licen_Renew  " +
                "          UNION ALL select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin from Property " +
                "          UNION ALL select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' ,Status as 'order_status',TypeofRequest as 'order_Type',Emailofuser,(select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin From Owner order by order_date ";
                sql.Text = sql_;
                myListView.Items.Clear();
                myListView.DataSource = cn.table(sql_);
                myListView.DataBind();
            }
            else
            {

            DataPager1.DataBind();
            myListView.Items.Clear();
            myListView.DataSource = cn.table(sql.Text);
            myListView.DataBind();
            }

        }
        protected bool GetAdminmail(string orderStatus)
        {
            if (orderStatus == "مقبول") {   return true; }
            else if (orderStatus == "تعديل") { return true; }
            else if (orderStatus == "مرفوض") { return true; }
            else { return false; }
        }
            protected string GetOrderStatusCssClass(string orderStatus)
        {
            if (orderStatus == "مقبول")
            {
                return "text-success alert-success";
            }
            else if (orderStatus == "قيد المراجعة")
            {
                return "text-secondary alert-secondary";
            }
            else if (orderStatus == "مرفوض")
            {
                return "text-danger alert-danger";
            }
            else if (orderStatus == "تعديل")
            {
                return "text-primary alert-primary";
            }
            else
            {
                return string.Empty;
            }
        }
        protected string GetViewLink(string orderType, string orderId)
        {
            string url = "Main.aspx";
            if (orderType == "تجديد رخصة")
            {
                url = "view2.aspx";
            }
            else if (orderType == "إصدار رخصة")
            {
                url = "view.aspx";
            }
            else if (orderType == "رقم جديد")
            {
                url = "view3.aspx";
            }
            else if (orderType == "نقل ملكية")
            {
                url = "view4.aspx";
            }
            string query = $"?t=view&id={orderId}";
            return url + query;
        }
        string getprint(string orderType, string orderId)
        {/*if (orderType == "إصدار رخصة")
            {
                string templateFilePath = Server.MapPath("~/Documents/Prints/Newliesen.docx");
                string outputFolderPath = Server.MapPath("~/Documents/Prints/test");
                string outputPath = Server.MapPath("~/Documents/Prints/ex/Newliesens");
                int existingFilesCount = Directory.GetFiles(outputFolderPath).Length;
                int sequenceNumber = existingFilesCount + 1;
                string outputFileName = $"Newliesen_{sequenceNumber}.docx";
                string outputFilePath = Path.Combine(outputPath, outputFileName);
*/
            if (orderType == "إصدار رخصة")
            {
                string templateFilePath = Server.MapPath("/Documents/Prints/Newliesen.docx");
                string outputFolderPath = Server.MapPath("/Documents/Prints/test");
                string outputPath = Server.MapPath("/Documents/Prints/ex/Newliesens");
                int existingFilesCount = Directory.GetFiles(outputFolderPath).Length;
                int sequenceNumber = existingFilesCount + 1;
                string outputFileName = $"Newliesen_{sequenceNumber}.docx";
                string outputFilePath = Path.Combine(outputPath, outputFileName);

                // نسخ الملف القالب إلى مجلد الإخراج
                string outputFilePathCopy = Path.Combine(outputFolderPath, outputFileName);
                System.IO.File.Copy(templateFilePath, outputFilePathCopy, true);

                // تعبئة البيانات في الملف المنسوخ
                using (DocX doc = DocX.Load(outputFilePathCopy))
                {
                    Newliesen(doc, orderId);
                    doc.SaveAs(outputFilePath);
                }

                Console.WriteLine("تم إنشاء الملفات بنجاح.");
                // أمر لفتح الملف باستخدام تطبيق Word
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + outputFileName);
                Response.TransmitFile(outputFilePath);
                Response.End();

            }
            else if (orderType == "تجديد رخصة")
            {

                string templateFilePath = Server.MapPath("/Documents/Prints/RenewalLicense.docx");
                string outputFolderPath = Server.MapPath("/Documents/Prints/test");
                string outputPath = Server.MapPath("/Documents/Prints/ex/ReNewliesens");
                int existingFilesCount = Directory.GetFiles(outputFolderPath).Length;
                int sequenceNumber = existingFilesCount + 1;
                string outputFileName = $"ReNewliesen_{sequenceNumber}.docx";
                string outputFilePath = Path.Combine(outputPath, outputFileName);

                // نسخ الملف القالب إلى مجلد الإخراج
                string outputFilePathCopy = Path.Combine(outputFolderPath, outputFileName);
                System.IO.File.Copy(templateFilePath, outputFilePathCopy, true);

                // تعبئة البيانات في الملف المنسوخ
                using (DocX doc = DocX.Load(outputFilePathCopy))
                {
                    ReNewliesen(doc, orderId);
                    doc.SaveAs(outputFilePath);
                }

                Console.WriteLine("تم إنشاء الملفات بنجاح.");
                // أمر لفتح الملف باستخدام تطبيق Word
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + outputFileName);
                Response.TransmitFile(outputFilePath);
                Response.End();
            }
            else if (orderType == "رقم جديد")
            { 
                string templateFilePath = Server.MapPath("/Documents/Prints/NewNumber.docx");
                string outputFolderPath = Server.MapPath("/Documents/Prints/test");
                string outputPath = Server.MapPath("/Documents/Prints/ex/NewNumbers");
                int existingFilesCount = Directory.GetFiles(outputFolderPath).Length;
                int sequenceNumber = existingFilesCount + 1;
                string outputFileName = $"NewNumber_{sequenceNumber}.docx";
                string outputFilePath = Path.Combine(outputPath, outputFileName);

                // نسخ الملف القالب إلى مجلد الإخراج
                string outputFilePathCopy = Path.Combine(outputFolderPath, outputFileName);
                System.IO.File.Copy(templateFilePath, outputFilePathCopy, true);

                // تعبئة البيانات في الملف المنسوخ
                using (DocX doc = DocX.Load(outputFilePathCopy))
                {
                    NewNumber(doc, orderId);
                    doc.SaveAs(outputFilePath);
                }

                Console.WriteLine("تم إنشاء الملفات بنجاح.");
                // أمر لفتح الملف باستخدام تطبيق Word
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + outputFileName);
                Response.TransmitFile(outputFilePath);
                Response.End();
            }
            else if (orderType == "نقل ملكية")
            {

                string templateFilePath = Server.MapPath("/Documents/Prints/Changeowner.docx");
                string outputFolderPath = Server.MapPath("/Documents/Prints/test");
                string outputPath = Server.MapPath("/Documents/Prints/ex/Changeowners");
                int existingFilesCount = Directory.GetFiles(outputFolderPath).Length;
                int sequenceNumber = existingFilesCount + 1;
                string outputFileName = $"Changeowner_{sequenceNumber}.docx";
                string outputFilePath = Path.Combine(outputPath, outputFileName);

                // نسخ الملف القالب إلى مجلد الإخراج
                string outputFilePathCopy = Path.Combine(outputFolderPath, outputFileName);
                System.IO.File.Copy(templateFilePath, outputFilePathCopy, true);

                // تعبئة البيانات في الملف المنسوخ
                using (DocX doc = DocX.Load(outputFilePathCopy))
                {
                    Changeowner(doc, orderId);
                    doc.SaveAs(outputFilePath);
                }

                Console.WriteLine("تم إنشاء الملفات بنجاح.");
                // أمر لفتح الملف باستخدام تطبيق Word
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + outputFileName);
                Response.TransmitFile(outputFilePath);
                Response.End();
            }
            return ("");
        }
        private static void Newliesen(DocX doc, string orderId)
        {

            connection cn = new connection();
            string connectionString = cn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT License_req_ip , Name,Birth_day,Age,Birth_place,Job,  Identity_ip ,Status,  DateofSend, TypeofRequest, IPofBook,  Emailofuser,  Identy_IP,  ID, Type, Produce_date, Produce_place,  Governorate, State, Street,Phone FROM Licen_Request AS L JOIN Identy AS I ON L.Identity_ip = I.Identy_IP JOIN Address AS A ON A.Address_IP = L.Address_ip WHERE L.License_req_ip = '" + orderId + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Licen_Request
                    doc.ReplaceText("Name", reader["Name"].ToString());
                    doc.ReplaceText("License_req_ip", reader["License_req_ip"].ToString());
                    doc.ReplaceText("Birth_day", reader["Birth_day"].ToString());
                    doc.ReplaceText("Age", reader["Age"].ToString());
                    doc.ReplaceText("Job", reader["Job"].ToString());
                    doc.ReplaceText("Governorate", reader["Governorate"].ToString());

                    //Identy
                    doc.ReplaceText("Produce_place", reader["Produce_place"].ToString());
                    doc.ReplaceText("Produce_date", reader["Produce_date"].ToString());
                    doc.ReplaceText("ID", reader["ID"].ToString());
                    doc.ReplaceText("Type", reader["Type"].ToString());



                    //Address
                    doc.ReplaceText("State", reader["State"].ToString());
                    doc.ReplaceText("Street", reader["Street"].ToString());
                    doc.ReplaceText("Phone", reader["Phone"].ToString());
                }
            }
            Console.WriteLine("تم إنشاء الملف الجديد بنجاح.");
        }
        private static void ReNewliesen(DocX doc, string orderId)
        {
            connection cn = new connection();
            string connectionString = cn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT License_renew_IP, Name,Old_license,Oldlicepr,Oldlicexp,center, Birth_day, Birth_place, Age, Job,  Identity_ip ,Status,  DateofSend, TypeofRequest, IPofBook,  Emailofuser,  Identy_IP,  ID, Type, Produce_date, Produce_place,  Governorate, State, Street,Phone FROM Licen_Renew AS L JOIN Identy AS I ON L.Identity_ip = I.Identy_IP JOIN Address AS A ON A.Address_IP = L.Address_ip WHERE L.License_renew_IP = '" + orderId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    // استخدم القالب لتعبئة المتغيرات
                    //RENEW
                    doc.ReplaceText("[[FullName]]", reader["Name"].ToString());
                    doc.ReplaceText("[[OldLicense]]", reader["Old_license"].ToString());  //رقم الجواز أو البطاقة     
                    doc.ReplaceText("[[BirthDay]]", ((DateTime)reader["Birth_day"]).ToString("yyyy/MM/dd"));
                    doc.ReplaceText("[[Age]]", reader["Age"].ToString());
                    doc.ReplaceText("[[Job]]", reader["Job"].ToString());  //رقم الجواز أو البطاقة     
                    doc.ReplaceText("[[center]]", reader["Center"].ToString());
                    doc.ReplaceText("[[LicenseIssuanceDate]]", ((DateTime)reader["Oldlicepr"]).ToString("yyyy/MM/dd"));
                    doc.ReplaceText("[[LicenseExpiryDate]]", ((DateTime)reader["Oldlicexp"]).ToString("yyyy/MM/dd"));


                    //identy

                    doc.ReplaceText("[[IDNumber]]", reader["ID"].ToString());  //رقم الجواز أو البطاقة     
                    doc.ReplaceText("[[IDReleaseDate]]", ((DateTime)reader["Produce_date"]).ToString("yyyy/MM/dd"));
                    doc.ReplaceText("[[IDPlaceIssue]]", reader["Produce_place"].ToString());

                    //address
                    doc.ReplaceText("[[State]]", reader["State"].ToString());
                    doc.ReplaceText("[[Governorate]]", reader["Governorate"].ToString());
                    doc.ReplaceText("[[Phone]]", reader["Phone"].ToString());
                }
            }
        }

        private static void NewNumber(DocX doc, string orderId)
        {
            connection cn = new connection();
            string connectionString = cn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Owner.Name, Owner.Sex, Owner.Owner_IP, Owner.Birth_day, Owner.Birth_place," +
                    " Owner.Nationality, Owner.Job_place ,Owner.Identity_ip, Owner.Cousin_id1, Owner.Cousin_id2," +
                    " Owner.Job, Identy.Produce_place, Identy.Produce_date, Identy.ID, Identy.Type,  Cousin1.Cousin_ID AS cousin_Id1," +
                    " Cousin1.Name AS cousin1, Cousin1.Adreess AS cousin_Address1, Cousin1.Phone AS cousin_Phone1,   " +
                    "  Cousin2.Cousin_ID AS cousin_Id2, Cousin2.Name AS cousin2, Cousin2.Adreess AS cousin_Address2, " +
                    "Cousin2.Phone AS cousin_Phone2, Address.Governorate, Address.Street FROM Owner " +
                    "LEFT JOIN Identy ON Identy.Identy_IP = Owner.Identity_ip LEFT JOIN Cousin AS Cousin1 ON Cousin1.Cousin_ID = Owner.Cousin_id1" +
                    " LEFT JOIN Cousin AS Cousin2 ON Cousin2.Cousin_ID = Owner.Cousin_id2  " +
                    " LEFT JOIN Address ON Address.Address_IP = Owner.Address_ip WHERE Owner.Owner_IP = '"+ orderId + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Owner
                    doc.ReplaceText("Name", reader["Name"].ToString());
                    doc.ReplaceText("Sex", reader["Sex"].ToString());
                    doc.ReplaceText("Owner_IP", reader["Owner_IP"].ToString());
                    doc.ReplaceText("Birth_day", reader["Birth_day"].ToString());
                    doc.ReplaceText("Birth_place", reader["Birth_place"].ToString());
                    doc.ReplaceText("Nationality", reader["Nationality"].ToString());
                    doc.ReplaceText("Job_place", reader["Job_place"].ToString());
                    doc.ReplaceText("Identity_ip", reader["Identity_ip"].ToString());
                    doc.ReplaceText("Cousin_id1", reader["Cousin_id1"].ToString());
                    doc.ReplaceText("Cousin_id2", reader["Cousin_id2"].ToString());
                    doc.ReplaceText("Job", reader["Job"].ToString());

                    //Identy
                    doc.ReplaceText("Produce_place", reader["Produce_place"].ToString());
                    doc.ReplaceText("Produce_date", reader["Produce_date"].ToString());
                    doc.ReplaceText("ID", reader["ID"].ToString());
                    doc.ReplaceText("Type", reader["Type"].ToString());

                    //Cousin 1
                    doc.ReplaceText("ID1", reader["cousin_Id1"].ToString());
                    doc.ReplaceText("C1", reader["cousin1"].ToString());
                    doc.ReplaceText("Adreess1", reader["cousin_Address1"].ToString());
                    doc.ReplaceText("Phone1", reader["cousin_Phone1"].ToString());

                    //Cousin 2
                    doc.ReplaceText("ID2", reader["cousin_Id2"].ToString());
                    doc.ReplaceText("C2", reader["cousin2"].ToString());
                    doc.ReplaceText("Adreess2", reader["cousin_Address2"].ToString());
                    doc.ReplaceText("Phone2", reader["cousin_Phone2"].ToString());

                    //Address
                    doc.ReplaceText("Governorate", reader["Governorate"].ToString());
                    doc.ReplaceText("Street", reader["Street"].ToString());

                }
            }
        }

        private static void Changeowner(DocX doc, string orderId)
        {
            connection cn = new connection();
            string connectionString = cn.SQL();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Property.Property_ip,Property.Identity_ip,Property.Governorate,Property.Doc_of_property,Property.Owner_name,Property.Job,Property.Nationality,Property.State," +
                    "Property.Police_Center,Property.Village,Property.Center,Property.Neighborhood,Property.Street,Property.House_phone,Property.Phone,Property.Seller_name," +
                    "Property.Identity_type,Property.Identity_number,Property.Produce_date AS 'Produce_date_seller',Property.Produce_from As 'Produce_from_seller',Property.Seller_address," +
                    "V.Plate_number ,V.Plate_type,V.Vehicle_type,V.Vehicle_color,V.Vehicle_color,V.Engine_number," +
                    "V.Potty_number,V.Card_management ,V.Trailer_number ,V.Type_trailer_number,V.Card_produce_management,V.Produce_year ," +
                    "I.ID ,I.Type , I.Produce_date,I.Produce_place " +
                    "from Property " +
                    "LEFT JOIN Identy I ON I.Identy_IP = Property.Identity_ip " +
                    "LEFT JOIN Vehicle V ON V.IP = Property.Vehicle_ip WHERE Property.Property_ip = '" + orderId + "'";



                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Property
                    doc.ReplaceText("IP", reader["Property_ip"].ToString());
                    doc.ReplaceText("Governorate", reader["Governorate"].ToString());
                    doc.ReplaceText("Doc_of_property", reader["Doc_of_property"].ToString());
                    doc.ReplaceText("Owner_name", reader["Owner_name"].ToString());
                    doc.ReplaceText("Job", reader["Job"].ToString());
                    doc.ReplaceText("Nationality", reader["Nationality"].ToString());
                    doc.ReplaceText("State", reader["State"].ToString());
                    doc.ReplaceText("Police_Center", reader["Police_Center"].ToString());
                    doc.ReplaceText("Village", reader["Village"].ToString());
                    doc.ReplaceText("Center", reader["Center"].ToString());
                    doc.ReplaceText("Neighborhood", reader["Neighborhood"].ToString());
                    doc.ReplaceText("Street", reader["Street"].ToString());
                    doc.ReplaceText("House_phone", reader["House_phone"].ToString());
                    doc.ReplaceText("Phone", reader["Phone"].ToString());
                    doc.ReplaceText("Seller_name", reader["Seller_name"].ToString());
                    doc.ReplaceText("Identity_type", reader["Identity_type"].ToString());
                    doc.ReplaceText("Identity_number", reader["Identity_number"].ToString());
                    doc.ReplaceText("Producedateowner", reader["Produce_date_seller"].ToString());
                    doc.ReplaceText("Produceplaceowner", reader["Produce_from_seller"].ToString());
                    doc.ReplaceText("Seller_address", reader["Seller_address"].ToString());

                    //Identy
                    doc.ReplaceText("Type", reader["Type"].ToString());
                    doc.ReplaceText("ID", reader["ID"].ToString());
                    doc.ReplaceText("Produce_placeb", reader["Produce_place"].ToString());
                    doc.ReplaceText("Produce_dateb", reader["Produce_date"].ToString());

                    //Vehicle
                    doc.ReplaceText("Plate_number", reader["Plate_number"].ToString());
                    doc.ReplaceText("Plate_type", reader["Plate_type"].ToString());
                    doc.ReplaceText("Card_produce_management", reader["Card_produce_management"].ToString());
                    doc.ReplaceText("Vehicle_type", reader["Vehicle_type"].ToString());
                    doc.ReplaceText("Vehicle_color", reader["Vehicle_color"].ToString());
                    doc.ReplaceText("Produce_year", reader["Produce_year"].ToString());
                    doc.ReplaceText("Engine_number", reader["Engine_number"].ToString());
                    doc.ReplaceText("Potty_number", reader["Potty_number"].ToString());
                    doc.ReplaceText("Card_management", reader["Card_management"].ToString());
                    doc.ReplaceText("TM", reader["Trailer_number"].ToString());
                    doc.ReplaceText("TN", reader["Type_trailer_number"].ToString());
                    //Address
                    doc.ReplaceText("Address_Governorate", reader["Governorate"].ToString());
                    doc.ReplaceText("Address_State", reader["State"].ToString());
                    doc.ReplaceText("Address_Street", reader["Street"].ToString());

                }

            }

        }
        protected void Print_Click(object sender, EventArgs e)
        {

            System.Web.UI.WebControls.LinkButton print = (System.Web.UI.WebControls.LinkButton)sender;
            ListViewDataItem item = (ListViewDataItem)print.NamingContainer;
            System.Web.UI.WebControls.Label id_ = (System.Web.UI.WebControls.Label)item.FindControl("order_id");
            System.Web.UI.WebControls.Label type = (System.Web.UI.WebControls.Label)item.FindControl("order_Type");

            LinkButton printButton = (LinkButton)sender;
            string orderType = string.Empty;
            string orderId = string.Empty;

            if (type != null)
            {
                orderType = type.Text;
            }

            // العثور على عنصر التحكم order_id داخل نموذج البيانات
            if (id_ != null)
            {
                orderId = id_.Text;
            }

             
    
            Response.Write("Order Type: " + orderType);
            getprint(orderType, orderId);
            Response.Write("Order ID: " + orderId);

        }

        protected void orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection cn = new connection();
            int select = orders.SelectedIndex;
            string sqltext = sql.Text;
            if (select == 0) 
            {
            sqltext = " SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin FROM  Licen_Request " +
                "          UNION ALL SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend as 'order_date',Status as 'order_status', TypeofRequest as 'order_Type', Emailofuser , (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin FROM Licen_Renew  " +
                "          UNION ALL select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin from Property " +
                "          UNION ALL select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' ,Status as 'order_status',TypeofRequest as 'order_Type',Emailofuser,(select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin From Owner order by order_date ";
            }
            else if(select == 1){sqltext = "SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin FROM  Licen_Request where Status=N'قيد المراجعة' order by order_date"; }
            else if (select == 2)  { sqltext = "SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend as 'order_date',Status as 'order_status', TypeofRequest as 'order_Type', Emailofuser , (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin  FROM Licen_Renew where Status=N'قيد المراجعة' order by order_date"; }
            else if (select == 3)  { sqltext = "select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin from Property  where Status=N'قيد المراجعة' order by order_date"; }
            else if (select == 4) { sqltext = "select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' ,Status as 'order_status',TypeofRequest as 'order_Type',Emailofuser,(select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin From Owner where Status=N'قيد المراجعة' order by order_date "; }
            else if (select == 5) { sqltext = "SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin FROM  Licen_Request order by order_date"; }
            else if (select == 6) { sqltext = "SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend as 'order_date',Status as 'order_status', TypeofRequest as 'order_Type', Emailofuser , (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin FROM Licen_Renew order by order_date"; }
            else if (select == 7) { sqltext = "select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin from Property order by order_date"; }
            else if (select == 8) { sqltext = "select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' ,Status as 'order_status',TypeofRequest as 'order_Type',Emailofuser,(select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin From Owner order by order_date"; }

            sql.Text = sqltext;
            myListView.Items.Clear();
            myListView.DataSource = cn.table(sqltext);
            myListView.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            connection cn = new connection();
            string name = searchBox.Text;
            string sqltext = sql.Text;
            sql.Text  =$" SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin FROM  Licen_Request where Name like N'%{name}%'  " +
               $"          UNION ALL SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend,Status as 'order_status', TypeofRequest as 'order_Type', Emailofuser , (select Name from Users where Email=Emailofuser) as 'user_name' ,EmailofAdmin FROM Licen_Renew  where Name like N'%{name}%' " +
               $"          UNION ALL select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type',Emailofuser, (select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin from Property where Seller_name  like N'%{name}%'  " +
               $"          UNION ALL select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' ,Status as 'order_status',TypeofRequest as 'order_Type',Emailofuser,(select Name from Users where Email=Emailofuser) as 'user_name',EmailofAdmin From Owner where Name like N'%{name}%' order by order_date ";
            DataPager1.DataBind();
            myListView.Items.Clear();
            myListView.DataSource = cn.table(sql.Text);
            myListView.DataBind();
        }
    }
}