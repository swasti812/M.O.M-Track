using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MOMTracker
{
    public partial class CreateMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!this.IsPostBack)
                {
                    var token = Session["TOKEN"] as string;
                    var user = TokenManager.Identifytoken(token);
                    if (user != null)
                    {
                        var context = new MOMEntities();
                        var ID = context.ROLETABLE.SingleOrDefault(x => x.ROLE == "CP");

                        var origin = context.DETAILSTABLE.Where(s => s.ROLE == ID.ROLEID).ToList();
                        origin = origin.OrderBy(c => c.FIRSTNAME).ToList();

                        DataSet o = new DataSet();
                        ChairpersonList.DataSource = origin;


                        ChairpersonList.DataTextField = "FullName";


                        ChairpersonList.DataValueField = "UNIQUEID";
                        ChairpersonList.DataBind();

                        var Invitees = context.DETAILSTABLE.ToList();
                        InviteeList.DataSource = Invitees;
                        InviteeList.DataTextField = "FullName";
                        InviteeList.DataValueField = "UNIQUEID";
                        InviteeList.DataBind();
                        var Department = context.DEPARTMENTTABLE.ToList();
                        ListBox1.DataSource = Department;
                        ListBox1.DataTextField = "DEPARTMENT";
                        ListBox1.DataValueField = "KEY";
                        ListBox1.DataBind();
                        //this.BindGrid();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");

                    }
                }


               
            }
                
               
        }
    
        

        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var agenda = txtTinyMCE.Text;
                var title = TextBox3.Text;
                var chairperson = ChairpersonList.SelectedValue;
                var date = Convert.ToDateTime(TextBox.Text);
                var time = TextBox1.Text;

                var NewMeeting = new MEETINGTABLE();
                NewMeeting.CHAIRPERSON =Convert.ToDecimal(chairperson);
                NewMeeting.TIME = time;
                NewMeeting.TITLE = title;
                NewMeeting.MEETINGDATE = date;
                //NewMeeting.CHAIRPERSON = chairperson;
                
                var context = new MOMEntities();
                context.MEETINGTABLE.Add(NewMeeting);
                context.SaveChanges();
                var ID = NewMeeting.MEETINGID;
                var Meetagenda = new AGENDATABLE();
                Meetagenda.MEETINGID = ID;
                Meetagenda.AGENDA = agenda;
                context.AGENDATABLE.Add(Meetagenda);
                context.SaveChanges();
                foreach (ListItem listItem in InviteeList.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        var txt = listItem.Text;
                        INVITEESTABLE invite = new INVITEESTABLE();
                        invite.MEETINGID = ID;
                        invite.INVITEEID = Convert.ToDecimal(val);
                        context.INVITEESTABLE.Add(invite);
                        context.SaveChanges();

                    }
                }
                foreach(ListItem LISTITEM in ListBox1.Items)
                {
                    if (LISTITEM.Selected)
                    { var val = LISTITEM.Value;
                        MEETDEP obj = new MEETDEP();
                        obj.MEETID = ID;
                        obj.DEPID = Convert.ToInt32(val);
                        context.MEETDEP.Add(obj);
                        context.SaveChanges();

                    }
                }
                Response.Redirect("/Home.aspx");
              
                // var list = InviteeList.SelectedValue;
                // var ID= context.MEETINGTABLE.
            }
            catch (Exception ex)
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