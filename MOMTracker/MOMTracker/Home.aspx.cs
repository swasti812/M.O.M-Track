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

namespace MOMTracker
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new MOMEntities();
            // var list = from u in MEETINGTABLE sel
            var list = context.MEETINGTABLE.Where(x => x.MEETINGID <= 25).ToList();


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
           // var id = Meetlist.SelectedDataKey;
           string id1 = Meetlist.SelectedRow.Cells[3].Text;
            Response.Redirect("Details.aspx?identifier="+id1);
            // Response.Redirect("Details.aspx?ID=" + id);

        }
    }
}