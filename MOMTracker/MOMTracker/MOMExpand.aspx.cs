using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class MOMExpand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ID = Request.QueryString["identifier"];
            int id = Convert.ToInt32(ID);
            var context = new MOMEntities();
            MOMDETAILS USER = new MOMDETAILS();
            USER = context.MOMDETAILS.Single(x => x.KEY == id);
            Label1.Text = USER.RESP;
            Label2.Text = USER.REVIEWDATE.Date.ToString();
            Label3.Text = USER.STATUS;
            Label4.Text = USER.STATUSREM;

        }

        protected void btn_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}