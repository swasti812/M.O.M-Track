using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new MOMEntities();
            var list = context.DEPARTMENTTABLE.ToList();
          

            DepList.DataSource = list;
            DepList.DataTextField = "DEPARTMENT";
            DepList.DataValueField = "KEY";
            DepList.DataBind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var firstname = TextBox1.Text;
                var lastname = TextBox6.Text;
                var email = TextBox2.Text;
                var mob = TextBox3.Text;
                var tel = TextBox4.Text;
                var dep = DepList.SelectedValue;
                var password = TextBox5.Text;
                var context = new MOMEntities();
                MEMBERTABLE user = new MEMBERTABLE();
                var exa = context.MEMBERTABLE.SingleOrDefault(x => x.EMAIL == email);
                if (exa != null)
                {
                    Response.Write("Email already exist");

                }
                else
                {

                    user.FIRSTNAME = firstname;
                    user.LASTNAME = lastname;
                    user.EMAIL = email;
                    user.MOBILE = mob;
                    user.TELEPHONE = tel;
                    user.PASSWORD = password;

                    user.DEPARTMENT = Convert.ToInt32(dep);
                    context.MEMBERTABLE.Add(user);
                    context.SaveChanges();
                    Response.Redirect("Home.aspx");
                }

}
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}