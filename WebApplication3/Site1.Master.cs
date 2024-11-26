using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton1.Visible = false; // التعليمات
                LinkButton2.Visible = false; // من نحنُ
                LinkButton7.Visible = true; // أدارة الحسابات
                LinkButton6.Visible = true; // الاستعلامات
                LinkButton3.Visible = false; // دخول/تسجيل
                LinkButton9.Visible = true; // خروج
                LinkButton10.Visible = true; // إدارة الحساب الشخصي
                LinkButton1.Visible = false;

                if (Session["kind"] as string == "0")
                {
                    LinkButton7.Visible = false;
                }
                else if (Session["kind"] as string == "2")
                {
                   
                    LinkButton7.Visible = true; // أدارة الحسابات
                    LinkButton4.Visible = true; // أدارة المواعيد
                    LinkButton8.Visible = true; // تدقيق العمليات
                    ReviewTheDaysOfWeek.Visible = true; // تدقيق الحجوزات
                    LinkButton6.Visible = true; // الاستعلامات
                    LinkButton1.Visible = true; // التعليمات 
                    LinkButton2.Visible = true;// من نحنُ

                }
                else if (Session["kind"] as string == "1")
                {

                    LinkButton7.Visible = true; // أدارة الحسابات
                    LinkButton4.Visible = false; // أدارة المواعيد
                    LinkButton8.Visible = true; // تدقيق العمليات
                    ReviewTheDaysOfWeek.Visible = true; // تدقيق الحجوزات
                    LinkButton6.Visible = true; // الاستعلامات
                    LinkButton1.Visible = true; // التعليمات 
                    LinkButton2.Visible = true;// من نحنُ

                }

            }
            else
            {
                LinkButton1.Visible = true; // التعليمات 
                LinkButton2.Visible = true;// من نحنُ
                LinkButton3.Visible = true; // دخول/تسجيل
                LinkButton4.Visible = false; // أدارة المواعيد
                LinkButton8.Visible = false; // تدقيق العمليات

                ReviewTheDaysOfWeek.Visible = false; // تدقيق الحجوزات

                LinkButton7.Visible = false; // أدارة الحسابات
                LinkButton6.Visible = false; // الاستعلامات
                LinkButton9.Visible = false; // خروج
                LinkButton10.Visible = false; // إدارة الحساب الشخصي
                LinkButton1.Visible = false;

            }
        }
        protected void linkLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Main.aspx");


        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }
    }
}