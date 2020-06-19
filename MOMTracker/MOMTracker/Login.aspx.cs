using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace MOMTracker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MOMEntities"].ToString());
            try
            {
                string uid = TextBox.Text;
                string pass = TextBox2.Text;
                var context = new MOMEntities();
                // con.Open();
                
                var user = context.DETAILSTABLE.SingleOrDefault(x => x.EMAIL == uid && x.PASSWORD==pass );
                if (user!=null)
                {
                    Response.Redirect("/Home.aspx");
                }
                else
                {
                    Label4.Text = "UserId & Password Is not correct Try again..!!";

                }
                //con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}
