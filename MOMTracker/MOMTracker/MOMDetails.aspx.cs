using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOMTracker
{
    public partial class MOMDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var token = Session["TOKEN"] as string;
                var user = TokenManager.Identifytoken(token);
                if (user != null)
                {
                  
                    this.BindGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }

           
        }
        private void BindGrid()
        {
            var context = new MOMEntities();
            // var list = from u in MEETINGTABLE sel
            var list = context.MOMDETAILS.ToList();


            Meet.DataSource = list;

            Meet.DataBind();

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Meet.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ID = Request.QueryString["identifier"];
            int id = Convert.ToInt32(ID);
            var context = new MOMEntities();
            MOMDETAILS USER = new MOMDETAILS();
            USER = context.MOMDETAILS.Single(x => x.KEY == id);
            var meeting = USER.MOMDETAILS1;
            MEETINGTABLE Meeting = new MEETINGTABLE();
            Meeting = context.MEETINGTABLE.Single(x => x.MEETINGID == USER.MOMDETAILS1);
            var CPID = Meeting.CHAIRPERSON;
            DETAILSTABLE cp = new DETAILSTABLE();
            cp = context.DETAILSTABLE.Single(x => x.UNIQUEID == CPID);
            var email = cp.EMAIL;

            using (MailMessage mm = new MailMessage("sender@gmail.com", email))
            {
                mm.Subject = "REMINDER";



                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                //mm.Body = USER.ACTIONABLE+" "+ USER.ITEM+" "+ USER.STATUS+" "+ USER.EXPECTEDCLOSURE;
                mm.Body = USER.ACTIONPOINT + USER.TASKDESCRIPTION + USER.TARGET;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = "photoblues.biz@gmail.com";
                credentials.Password = "TESTPASS";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credentials;
                smtp.Port = 587;
                smtp.Send(mm);


            }


        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ID = Request.QueryString["identifier"];
                int id = Convert.ToInt32(ID);
                var context = new MOMEntities();
                MOMDETAILS USER = new MOMDETAILS();
                USER = context.MOMDETAILS.Single(x => x.KEY == id);
                var meeting = USER.MOMDETAILS1;
                List<INVITEESTABLE> INV = context.INVITEESTABLE.Where(x => x.MEETINGID == meeting).ToList();
                DETAILSTABLE detail = new DETAILSTABLE();
                foreach (var item in INV)
                {
                    var uid = item.INVITEEID;
                    detail = context.DETAILSTABLE.SingleOrDefault(x => x.UNIQUEID == uid);
                    var email = detail.EMAIL;
                    using (MailMessage mm = new MailMessage("sender@gmail.com", email))
                    {
                        mm.Subject = "MOM DETAILS";
                        mm.Body = USER.ACTIONPOINT + USER.TASKDESCRIPTION + USER.TARGET;
                        //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                        credentials.UserName = "photoblues.biz@gmail.com";
                        credentials.Password = "TESTPASS";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = credentials;
                        smtp.Port = 587;
                        smtp.Send(mm);


                    }
                }

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

        //protected void Meetlist_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    //this.Meetlist.Columns[0].Visible = false;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.Meetlist, "Select$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
        //        e.Row.ToolTip = "select row";
        //    }

        //}

        //protected void Meetlist_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // var id = Meetlist.SelectedDataKey;
        //    string id1 = Meetlist.SelectedRow.Cells[3].Text;
        //    Response.Redirect("MOMExpand.aspx?identifier=" + id1);
        //    // Response.Redirect("Details.aspx?ID=" + id);

        //}

    }
}
