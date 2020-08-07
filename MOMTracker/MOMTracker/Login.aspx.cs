using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations;

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
                MEMBERTABLE check = new MEMBERTABLE();
                check.EMAIL = uid;
                check.PASSWORD = pass;
                //var contextt = new ValidationContext(uid);
                //var results = new List<ValidationResult>();
                //var isValid = Validator.TryValidateObject(check, contextt, results, true);

                //if (!isValid)
                //{

                //}
             
                //else
                //{
                    var user = context.MEMBERTABLE.SingleOrDefault(x => x.EMAIL == uid && x.PASSWORD == pass);
                    if (user != null)
                    {
                        //Token_cs obj = new Token_cs();
                        var obj = TokenManager.GenerateToken(user.EMAIL);
                        //var token=TokenManager.GenerateToken(user.EMAIL);
                        Session["TOKEN"] = obj;
                        Response.Redirect("Home.aspx?token=" + obj, false);
                    }
                    else
                    {
                        Label4.Text = "UserId & Password Is not correct Try again..!!";

                    }
                //}
                //con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}
