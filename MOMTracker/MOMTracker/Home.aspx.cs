using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Web.Security;

namespace MOMTracker
{
    public partial class Home : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
           


           
                if (!this.IsPostBack)
                {
                    //var token = Request["token"];
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
            var token = Session["TOKEN"] as string;
            var user = TokenManager.Identifytoken(token);

            var context = new MOMEntities();
            // var list = from u in MEETINGTABLE sel List<MEETINGTABLE> list = new List<MEETINGTABLE>();
            var dep = user.DEPARTMENT;
            var DepMeet = (List<MEETDEP>)context.MEETDEP.Where(x => x.DEPID == dep).ToList();
            List<MEETINGTABLE> list = new List<MEETINGTABLE>();
            foreach (var item in DepMeet)
            {
                MEETINGTABLE x = new MEETINGTABLE();
                    x=context.MEETINGTABLE.Single(p => p.MEETINGID==item.MEETID);
                list.Add(x);
            }

         
            Meetlist.DataSource = list;

            Meetlist.DataBind();
        }
        


    protected void btn_Click(object sender, EventArgs e)
        {
            //Response.RedirectToRoute();
        }

        protected void Meetlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //this.Meetlist.Columns[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.Meetlist, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "select row";
            }

        }

        protected void Meetlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var id1 = Meetlist.SelectedDataKey;
            //var id = Convert.ToInt32(id1);
            //var id1 = Meetlist.DataKeys[].Value;
            string id1 = Meetlist.SelectedRow.Cells[3].Text;
            Response.Redirect("Details.aspx?identifier="+id1);
            // Response.Redirect("Details.aspx?ID=" + id);

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Meetlist.PageIndex = e.NewPageIndex;
            this.BindGrid();
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