using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
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

             
                var context = new MOMEntities();
                var ID = context.ROLETABLE.SingleOrDefault(x => x.ROLE == "CP");
              
                var origin = context.DETAILSTABLE.Where(s=> s.ROLE==ID.ROLEID).ToList();
                origin = origin.OrderBy(c => c.FIRSTNAME).ToList();
                
                DataSet o = new DataSet();
                ChairpersonList.DataSource = origin;
                
              
                ChairpersonList.DataTextField = "NAMEANDDESCRIPTION" ;


                ChairpersonList.DataValueField = "UNIQUEID";
                ChairpersonList.DataBind();

                var Invitees = context.DETAILSTABLE.ToList();
                InviteeList.DataSource = Invitees;
                InviteeList.DataTextField = "NAMEANDDESCRIPTION";
                InviteeList.DataValueField = "UNIQUEID";
                InviteeList.DataBind();
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

              
                // var list = InviteeList.SelectedValue;
                // var ID= context.MEETINGTABLE.
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


             
            


        }
    }
}