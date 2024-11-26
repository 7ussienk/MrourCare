using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;
using con;


namespace WebApplication3
{
    public partial class requires : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] == null)
            {
                string confirmScript = "<script>if(confirm('يجب  عليك تسجيل الدخول')){ window.location.href = 'login.aspx'; } else { window.location.href = 'login.aspx'; }</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", confirmScript);
            }
            else
            {
                cards(Session["userEmail"].ToString());
            }


        }

        protected void cards(string Email)
        {
            string xc = " SELECT Owner_IP as 'order_id', Name as 'order_name' ,DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Owner\r\n                          union all \r\n                         SELECT Property_ip as 'order_id', Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Property \r\n                           union all \r\n                          SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM  Licen_Request\r\n                           union all \r\n                          SELECT License_renew_IP AS 'order_id', Name as 'order_name',DateofSend 'order_date' ,Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Licen_Renew";


            string sql_ = " SELECT Owner_IP as 'order_id', Name as 'order_name' ,DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Owner where Emailofuser= '" + Email + "' " +
                           " union all " +
                           " SELECT Property_ip as 'order_id', Seller_name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Property where Emailofuser= '" + Email + "' " +
                           " union all " +
                           " SELECT  License_req_ip as 'order_id', Name as 'order_name' , DateofSend as 'order_date' , Status as 'order_status' ,TypeofRequest as 'order_Type' FROM  Licen_Request where Emailofuser= '" + Email + "' " +
                           " union all " +
                           " SELECT License_renew_IP AS 'order_id', Name as 'order_name',DateofSend 'order_date' ,Status as 'order_status' ,TypeofRequest as 'order_Type' FROM Licen_Renew where Emailofuser= '" + Email + "' order by DateofSend desc  ";
            connection cn = new connection();
            myListView.DataSource = cn.table(sql_);
            myListView.DataBind();

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Accepted_Click(object sender, EventArgs e)
        {
            Button acceptedButton = (Button)sender;
            ListViewDataItem item = (ListViewDataItem)acceptedButton.NamingContainer;

            // الحصول على القيم المطلوبة من عناصر التحكم في قالب ListView
            // string re_date = ((Label)item.FindControl("lblOrderNum")).Text;
            string orderID = ((Label)item.FindControl("lblOrderNum")).Text;
            string order_Type = ((Label)item.FindControl("order_type")).Text;
            string type = "";
            if (order_Type == "تجديد رخصة") { type = "reNewLiesen"; }
            else if (order_Type == "إصدار رخصة") { type = "NewLiesen"; }
            else if (order_Type == "رقم جديد") { type = "NewNumber"; }
            else if (order_Type == "نقل ملكية") {  type = "changeOnwer";}

            // تحويل المستخدم إلى الصفحة bookappo.aspx مع تمرير القيم
            Response.Redirect("bookappo.aspx?type=" + type + "&id=" + orderID);

        }
        protected void Updateing(object sender, EventArgs e)
        {
            Button acceptedButton = (Button)sender;
            ListViewDataItem item = (ListViewDataItem)acceptedButton.NamingContainer;

            // الحصول على القيم المطلوبة من عناصر التحكم في قالب ListView
            // string re_date = ((Label)item.FindControl("lblOrderNum")).Text;
            string orderID = ((Label)item.FindControl("lblOrderNum")).Text;
            string order_Type = ((Label)item.FindControl("order_type")).Text;

            // تحويل المستخدم إلى الصفحة bookappo.aspx مع تمرير القيم
            string page = "";


            Response.Redirect(GetViewLink(order_Type, orderID));
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
            string query = $"?t=update&id={orderId}";
            return url + query;
        }

        protected string DisplayRequestType(object orderType)
        {
            string requestType = string.Empty;



            if (orderType != null)
            {
                int requestTypeValue;
                if (int.TryParse(orderType.ToString(), out requestTypeValue))
                {
                    switch (requestTypeValue)
                    {
                        case 1:
                            requestType = "طلب رخصة";
                            break;
                        case 2:
                            requestType = "طلب تجديد رخصة";
                            break;
                        case 3:
                            requestType = "طلب نقل ملكية";
                            break;
                        default:
                            requestType = "غير معروف";
                            break;
                    }
                }
            }

            return requestType;
        }
        protected bool mesg(string stat) 
        {
            if (stat == "مرفوض") { return false; }
            else if(stat == "مقبول") { return false; }
            else if(stat == "قيد المراجعة") { return false; }
            else if(stat =="تعديل"){ return false; }
            else if(stat == "مكتمل") { return false; }
            else if(stat == "متأخر") { return false; }
            else { return true; }
        }
    }
}