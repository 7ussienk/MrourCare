using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using con;
using System.Data;
using System.Data.SqlClient;
using Azure;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
namespace WebApplication3
{
    public partial class ReviewTheDaysOfWeek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                string t = Request.QueryString["t"];  // قيمة المتغير "t"
                string id = Request.QueryString["id"]; // قيمة المتغير "id"
                day.Text = DateTime.Now.ToString("yyyy-MM-dd");
                bind(day.Text);
                DataPager1.Page.DataBind(); 
                gen();
            }
            else { bind(day.Text); }

        }
        void bind(string day ) 
        {
            connection cn = new connection();
            sql.Text = "SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' ,IPofBook ,(select Date from Timing where Timing.ID=IPofBook ) as 'BookDate' ,(select Hours from Timing where Timing.ID=IPofBook ) as 'Hour' FROM  Licen_Request  where (select Date from Timing where Timing.ID=IPofBook ) ='" + day+"' " +
                " UNION ALL SELECT License_renew_IP as 'order_id', Name as 'order_name', DateofSend as 'order_date' , Status as 'order_status', TypeofRequest as 'order_Type' ,IPofBook ,(select Date from Timing where Timing.ID=IPofBook )  as 'BookDate' ,(select Hours from Timing where Timing.ID=IPofBook )as 'Hour' FROM Licen_Renew   where (select Date from Timing where Timing.ID=IPofBook ) ='" + day + "' " +
                "                         UNION ALL select Property_ip as 'order_id',Seller_name as 'order_name' , DateofSend as 'order_date'  , Status as 'order_status'  ,TypeofRequest as 'order_Type',IPofBook ,(select Date from Timing where Timing.ID=IPofBook ) as 'BookDate',(select Hours from Timing where Timing.ID=IPofBook ) as 'Hour'  from Property where (select Date from Timing where Timing.ID=IPofBook ) ='" + day + "' " +
                "                         UNION ALL select Owner_IP as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status',TypeofRequest as 'order_Type' ,IPofBook ,(select Date from Timing where Timing.ID=IPofBook ) as 'BookDate',(select Hours from Timing where Timing.ID=IPofBook ) as 'Hour'  From Owner where (select Date from Timing where Timing.ID=IPofBook) =  '" + day+"' ORDER BY IPofBook ASC ";

            myListView.DataSource = cn.table(sql.Text);
            myListView.DataBind();



        }

        protected void changeDay(object sender, EventArgs e)
        {

            //Response.Write(dropDays.SelectedValue);
            myListView.Items.Clear();
            day.Text = dropDays.SelectedValue;
            bind(dropDays.SelectedValue);
            DataPager1.Page.DataBind();
        }


        public void gen()
        {
            //string x = "  0  ";
            DateTime currentDate = DateTime.Now;
            DateTime startDate = currentDate.AddDays(0);

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

                    }

                }
                startDate = startDate.AddDays(1);
            }
   
            DateTime todayDate = DateTime.Now;
            dropDays.Items.Add(new ListItem($"حجوزات اليوم  : {GetArabicDayName(todayDate.DayOfWeek)} - {todayDate.ToString("yyyy-MM-dd")}", $"{todayDate.ToString("yyyy-MM-dd")}"));
            dropDays.Items.Add(new ListItem($"{dayNames[0]} - {weekdays[0].ToString("yyyy-MM-dd")}", $"{weekdays[0].ToString("yyyy-MM-dd")}"));
            dropDays.Items.Add(new ListItem($"{dayNames[1]} - {weekdays[1].ToString("yyyy-MM-dd")}", $"{weekdays[1].ToString("yyyy-MM-dd")}"));
            dropDays.Items.Add(new ListItem($"{dayNames[2]} - {weekdays[2].ToString("yyyy-MM-dd")}", $"{weekdays[2].ToString("yyyy-MM-dd")}"));
            dropDays.Items.Add(new ListItem($"{dayNames[3]} - {weekdays[3].ToString("yyyy-MM-dd")}", $"{weekdays[3].ToString("yyyy-MM-dd")}"));
            dropDays.Items.Add(new ListItem($"{dayNames[4]} - {weekdays[4].ToString("yyyy-MM-dd")}", $"{weekdays[4].ToString("yyyy-MM-dd")}"));

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
        private string GetArabicDayName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Saturday:
                    return "السبت";
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
                    return "الجمعة";
            }
        }

        protected string name_class(string order_status) 
        {
            if (order_status == "مقبول") {  return "user-link text-decoration-none  text-secondary "; }
            if (order_status == "مكتمل") { return "user-link text-decoration-none  text-success "; }
            if (order_status == "متأخر") { return "user-link text-decoration-none text-danger"; }
            else { return "user-link text-decoration-none"; }
            Response.Write($"<br> {order_status}");
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            System.Web.UI.WebControls.LinkButton accept = (System.Web.UI.WebControls.LinkButton)sender;
            ListViewDataItem item = (ListViewDataItem)accept.NamingContainer;
            System.Web.UI.WebControls.Label id_ = (System.Web.UI.WebControls.Label)item.FindControl("order_id");
            System.Web.UI.WebControls.Label type = (System.Web.UI.WebControls.Label)item.FindControl("order_type");
            System.Web.UI.WebControls.Label status = (System.Web.UI.WebControls.Label)item.FindControl("order_status");

            string orderType = type.Text; // نوع المعاملة
            string tableName = ""; // أٍم الجدول 
            string colomnID = ""; // ip الجدول 
            int id = Convert.ToInt32(id_.Text); // ايدي المعاملة 


            if (orderType == "إصدار رخصة") { tableName = "Licen_Request"; colomnID = "License_req_ip"; }
            if (orderType == "تجديد رخصة") { tableName = "Licen_Renew"; colomnID = "License_renew_IP"; }
            if (orderType == "نقل ملكية") { tableName = "Property"; colomnID = "Property_ip"; }
            if (orderType == "صرف رقم جديد") { tableName = "Owner"; colomnID = "Owner_IP"; }

            con.UpdateOrderStatus(id, $"{tableName}", "متأخر", $"{colomnID}");
        }

        protected void accept_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            System.Web.UI.WebControls.LinkButton accept = (System.Web.UI.WebControls.LinkButton)sender;
            ListViewDataItem item = (ListViewDataItem)accept.NamingContainer;
            System.Web.UI.WebControls.Label id_ = (System.Web.UI.WebControls.Label)item.FindControl("order_id");
            System.Web.UI.WebControls.Label type = (System.Web.UI.WebControls.Label)item.FindControl("order_type");
            System.Web.UI.WebControls.Label status = (System.Web.UI.WebControls.Label)item.FindControl("order_status");

            string orderType = type.Text; // نوع المعاملة
            string tableName = ""; // أٍم الجدول 
            string colomnID  = ""; // ip الجدول 
            int id = Convert.ToInt32(id_.Text); // ايدي المعاملة 

           
            if ( orderType == "إصدار رخصة") { tableName = "Licen_Request"; colomnID = "License_req_ip"; }
            if ( orderType == "تجديد رخصة") { tableName = "Licen_Renew"; colomnID = "License_renew_IP"; }
            if ( orderType == "نقل ملكية") { tableName = "Property"; colomnID = "Property_ip"; }
            if ( orderType == "صرف رقم جديد") { tableName = "Owner"; colomnID = "Owner_IP"; }

            con.UpdateOrderStatus(id, $"{tableName}", "مكتمل", $"{colomnID}");
        }

    }
}