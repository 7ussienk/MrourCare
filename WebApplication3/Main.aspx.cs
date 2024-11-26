using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

         

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Newliesen.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/changeowner.aspx");
        }

        protected void SendBTNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RenewLicense.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewNumberL.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //f.Visible = true;
        }
    }
    }
