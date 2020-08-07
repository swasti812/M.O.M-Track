using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if (!IsPostBack)
            {
                var context = new MOMEntities();
                var list = context.DEPARTMENTTABLE.ToList();


                Dep.DataSource = list;
                Dep.DataTextField = "DEPARTMENT";
                Dep.DataValueField = "KEY";
                Dep.DataBind();
            }
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
                var dep = Dep.SelectedValue;
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
                    user.ID = 0;
                    var contextt = new ValidationContext(user);
                    var results = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(user, contextt, results, true);

                    if (!isValid)
                    {
                        foreach (var validationResult in results)
                        {
                            //Response.Write(validationResult.ErrorMessage.ToString());
                            //Response.Redirect("SignUp.aspx");

                        }
                    }
                    else
                    {
                        user.DEPARTMENT = Convert.ToInt32(dep);
                        context.MEMBERTABLE.Add(user);
                        context.SaveChanges();
                        Response.Redirect("Login.aspx");
                    }
                    }
                

}
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}