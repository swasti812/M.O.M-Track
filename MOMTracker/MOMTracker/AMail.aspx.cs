﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class AMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                var token = Session["TOKEN"] as string;
                var user = TokenManager.Identifytoken(token);
                if (user != null)
                {
                    //this.BindGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }
            }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var rem1 = TextBox1.Text;
                var rem2 = TextBox2.Text;
                var context = new MOMEntities();
                MAILTIMER obj1 = new MAILTIMER();
                obj1 = context.MAILTIMER.SingleOrDefault(x => x.KEYID == 1);
                //obj1.KEYID = 1;
                obj1.DAYS = Convert.ToDecimal(rem1);
                MAILTIMER obj2 = new MAILTIMER();
                obj2 = context.MAILTIMER.SingleOrDefault(x => x.KEYID == 2);
                //obj1.KEYID = 1;
                obj2.DAYS = Convert.ToDecimal(rem2);

                context.SaveChanges();
                Response.Redirect("Home.aspx");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }

            
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/Login.aspx", true);
        }
    }
}