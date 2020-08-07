using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var status = TextBox3.Text;
                var context = new MOMEntities();
                var ID = Request.QueryString["Identifier"];
                var id = Convert.ToInt32(ID);
                var obj = context.MOMDETAILS.Single(x => x.KEY == id);
                obj.CURRENTSTAGE = DateTime.Now.ToLongDateString()+":" + status;
                context.SaveChanges();
                Response.Write("Thank you!");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }
    }
}