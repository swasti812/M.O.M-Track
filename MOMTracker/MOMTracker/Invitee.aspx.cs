﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class Invitee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new MOMEntities();
            var list = context.DEPARTMENTTABLE.ToList();
            var list1 = context.ROLETABLE.ToList();
            Rolelist.DataSource = list1;
            Rolelist.DataTextField = "ROLE";
            Rolelist.DataValueField = "ROLEID";
            Rolelist.DataBind();

            DepList.DataSource = list;
            DepList.DataTextField = "DEPARTMENT";
            DepList.DataValueField = "KEY";
            DepList.DataBind();



        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var FirstName = TextBox.Text;
                var LastName = TextBox1.Text;
                var Dep = DepList.SelectedValue;
                var Email = TextBox2.Text;
                var mobno = txtTinyMCE.Text;
                var phoneno = TextBox3.Text;
                var role = Rolelist.SelectedValue;
                var context = new MOMEntities();
                DETAILSTABLE NEWMEMBER = new DETAILSTABLE();
                NEWMEMBER.FIRSTNAME = FirstName;
                NEWMEMBER.LASTNAME = LastName;
                NEWMEMBER.DEPARTMENT = Convert.ToDecimal(Dep);
                NEWMEMBER.EMAIL = Email;
                if(mobno!="")
                NEWMEMBER.MOBILE = mobno;
                if(phoneno!="")
                NEWMEMBER.TELEPHONE = phoneno;
                NEWMEMBER.ROLE = Convert.ToDecimal(role);

                context.DETAILSTABLE.Add(NEWMEMBER);
                context.SaveChanges();
                


            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }

        }
    }
}