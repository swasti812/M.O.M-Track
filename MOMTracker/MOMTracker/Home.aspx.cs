using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new MOMEntities();
            var list = context.MOMDETAILS.SqlQuery("Select * from MOMDETAILS");
            //meetlist.DataSource = list;
            //meetlist.DataBind();

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //Response.RedirectToRoute();
        }
    }
}