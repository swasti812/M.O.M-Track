 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Web.Security;
using System.Web.ModelBinding;
using Microsoft.Ajax.Utilities;

namespace MOMTracker
{
    public partial class Details : System.Web.UI.Page
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
            var ID = Request.QueryString["identifier"];
            var id = Convert.ToInt32(ID);
            // var list = from u in MEETINGTABLE sel List<MEETINGTABLE> list = new List<MEETINGTABLE>();
            var list = (List<MOMDETAILS>)context.MOMDETAILS.Where(x => x.MOMDETAILS1 == id).ToList();


            MOMList.DataSource = list;

            MOMList.DataBind();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MOMList.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void btn_Click(object sender, EventArgs e)
        {


            string file_name = Path.GetFileName(FileUpload1.PostedFile.FileName);
            // save the file on server(website) 
            FileUpload1.SaveAs(Server.MapPath(file_name));
            // save file name in sessio objet
            Session["name"] = file_name;
            string myfile_name = Session["name"].ToString();
            string Excel_path = Server.MapPath(myfile_name);
            // create connection with excel database  
            OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel_path + ";Extended Properties=Excel 8.0;Persist Security Info=False");
            my_con.Open();
            try
            {
                // get the excel file data and assign it in OleDbcoomad object(o_cmd) 
                OleDbCommand o_cmd = new OleDbCommand("select * from [Sheet1$]", my_con);
                //create oledbdataadapter object
                OleDbDataAdapter da = new OleDbDataAdapter();
                // pass o_cmd data to da object
                da.SelectCommand = o_cmd;
                //create a dataset object ds
                DataSet ds = new DataSet();
                // Assign da object data to dataset (virtual table) 
                da.Fill(ds);
                // assign dataset data to gridview control  
                //GridView1.DataSource = ds.Tables[0];
                //GridView1.DataBind();
                my_con.Close();
                Button3_Click();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }


        }
        protected void Button3_Click()
        {
            // create some string variables and assign null values 
            var ex_KEY = 1;
            var ex_TASKDESCRIP = "";
            var ex_CURRENTSTAGE = "";
            var Text = "22/11/2009";

            var ID = Request.QueryString["identifier"];

            DateTime ex_EXPECTEDCLOSURE = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            // DateTime ex_EXPECTEDCLOSURE = Convert.ToDateTime("");
            var ex_RESPONSIBILITY = "";
            var ex_ACTIONPOINT = "";
            var ex_EMAIL = "";
            DateTime ex_TARGET = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            var ex_ITEM = "";
            var ex_ITSPOC = ""
;
            //string myfile_name = Path.GetFileName(FileUpload1.PostedFile.FileName);
            // assign session object data to myfile_name variable
            string myfile_name = Session["name"].ToString();
            // get complete path of excel sheet and assing it Excel_path variable 
            string Excel_path = Server.MapPath(myfile_name);
            // create connection with excel database  
            OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel_path + ";Extended Properties=Excel 8.0;Persist Security Info=False");
            my_con.Open();
            try
            {
                // get the excel file data and assign it in OleDbcoomad object(o_cmd)
                OleDbCommand o_cmd = new OleDbCommand("select*from [Sheet1$]", my_con);
                // read the excel file data and assing it o_dr object
                OleDbDataReader o_dr = o_cmd.ExecuteReader();
                while (o_dr.Read())
                {

                    if (o_dr[0].ToString() != "")
                    {
                        //get first row data and assign it ex_id variable 
                        // ex_KEY = Convert.ToInt32(o_dr[0]);
                        ex_ITSPOC = o_dr[0].ToString();
                        //get second row data and assign it ex_name variable
                        ex_TASKDESCRIP = o_dr[1].ToString();
                        //get thirdt row data and assign it ex_name variable
                        ex_CURRENTSTAGE = o_dr[2].ToString();
                        ex_ITEM = o_dr[6].ToString();

                        //get first row data and assign it ex_location variable
                        ex_ACTIONPOINT = o_dr[3].ToString();// DateTime.ParseExact((string)o_dr[3], "dd/MM/yyyy", null);
                                                            //ex_EXPECTEDCLOSURE = Convert.ToDateTime(o_dr[3]);
                        ex_RESPONSIBILITY = o_dr[4].ToString();
                        ex_TARGET = (DateTime)o_dr[5];
                        // ex_TARGET =DateTime.ParseExact(o_dr[5].ToString(),"dd/MM/yyyy",null);
                        //Text = (string)o_dr[6];
                        //ex_REVIEWDATE = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
                        ex_EMAIL = o_dr[6].ToString();

                        var context = new MOMEntities();
                        MOMDETAILS rec = new MOMDETAILS();
                        rec.TASKDESCRIPTION = ex_TASKDESCRIP;
                        rec.TARGET = ex_TARGET;
                        rec.RESPONSIBILITY = ex_RESPONSIBILITY;
                        //rec.RESPONSIBILITY = ex_RESPONSIBILITY;
                        rec.CURRENTSTAGE = ex_CURRENTSTAGE; rec.ACTIONPOINT = ex_ACTIONPOINT;
                        rec.EMAIL = ex_EMAIL;
                        rec.ITSPOC = ex_ITSPOC;
                        ////var context = new MOMEntities();
                        int id = Convert.ToInt32(ID);
                        rec.MOMDETAILS1 = id;
                        context.MOMDETAILS.Add(rec);
                        context.SaveChanges();
                    }
                    else
                    {
                        o_dr.Close();
                        break;
                    }

                } //{
                Response.Write("DATA INSERTED SUCCESSFULLY");
                Response.Redirect("Details.aspx?identifier=" + ID);


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void MOMList_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
                MOMList.EditIndex = e.NewEditIndex;
                //Bind data to the GridView control.
                BindGrid();
            
        }


        protected void MOMList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string key = MOMList.SelectedRow.Cells[7].Text;
            GridViewRow row = (GridViewRow)MOMList.Rows[e.RowIndex];

            var key = MOMList.DataKeys[e.RowIndex].Value;
            var Key = Convert.ToInt32(key);
            var context = new MOMEntities();
            var obj = context.MOMDETAILS.Single(x => x.KEY == Key);
            var rem = e.NewValues["REMARKS"];

            //TextBox txtBox = (TextBox);
            if (!string.IsNullOrEmpty(e.NewValues["REMARKS"].ToString()))
            {
                obj.REMARKS = rem.ToString();// e.NewValues["REMARKS"].ToString();
            }
            else
            {
                obj.REMARKS = null;
            }
            string ATR = (MOMList.Rows[e.RowIndex].FindControl("DD2") as DropDownList).SelectedItem.Value;
            obj.ATR = ATR;
            context.SaveChanges();

            Response.Redirect("Details.aspx?identifier=" + obj.MOMDETAILS1);


        }

        protected void MOMList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MOMList.EditIndex = -1;
            BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ID = Request.QueryString["identifier"];
            int id = Convert.ToInt32(ID);
            var context = new MOMEntities();
            List<MOMDETAILS> USER = new List<MOMDETAILS>();
            USER = context.MOMDETAILS.Where(x => x.MOMDETAILS1 == id).ToList();


            //var meeting = USER.MOMDETAILS1;
            //MEETINGTABLE Meeting = new MEETINGTABLE();
            var Meeting = context.MEETINGTABLE.Single(x => x.MEETINGID == id);
            var CPID = Meeting.CHAIRPERSON;
            DETAILSTABLE cp = new DETAILSTABLE();
            cp = context.DETAILSTABLE.Single(x => x.UNIQUEID == CPID);
            var email = cp.EMAIL;

            using (MailMessage mm = new MailMessage("sender@gmail.com", email))
            {
                mm.Subject = "Chairperson Meeting Update";



                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                //mm.Body = USER.ACTIONABLE+" "+ USER.ITEM+" "+ USER.STATUS+" "+ USER.EXPECTEDCLOSURE;
                foreach (var item in USER)
                {
                    mm.Body = mm.Body + "   " + item.ACTIONPOINT + item.TASKDESCRIPTION + item.TARGET;
                }
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
            PopUp("Mail sent to Chairperson");

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var ID = Request.QueryString["identifier"];
                int id = Convert.ToInt32(ID);
                var context = new MOMEntities();
                List<MOMDETAILS> USER = new List<MOMDETAILS>();
                USER = context.MOMDETAILS.Where(x => x.MOMDETAILS1 == id).ToList();
                //var meeting = USER.MOMDETAILS1;
                List<INVITEESTABLE> INV = context.INVITEESTABLE.Where(x => x.MEETINGID == id).ToList();
                DETAILSTABLE detail = new DETAILSTABLE();
                foreach (var item in INV)
                {
                    var uid = item.INVITEEID;
                    detail = context.DETAILSTABLE.SingleOrDefault(x => x.UNIQUEID == uid);
                    var email = detail.EMAIL;
                    using (MailMessage mm = new MailMessage("sender@gmail.com", email))
                    {
                        mm.Subject = "MOM DETAILS";

                        foreach (var item2 in USER)
                        {
                            mm.Body = mm.Body + "   " + item2.ACTIONPOINT + item2.TASKDESCRIPTION + item2.TARGET;
                        }
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
                PopUp("Mail sent to all Invitees");

            }
            catch (Exception ex)
            {
                PopUp("Some error occured");
                //Response.Write(ex.Message);
            }
        }
        protected void PopUp( string content)
        {
            //Insert record here.

            //Display success message.
            string message = content;
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/Login.aspx", true);
        }

        //protected void DisplayYear_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var context = new MOMEntities();
        //    var ID = Request.QueryString["identifier"];
        //    var id = Convert.ToInt32(ID);
        //    var status = DisplayYear.SelectedValue;
        //    // var list = from u in MEETINGTABLE sel List<MEETINGTABLE> list = new List<MEETINGTABLE>();
        //    var list = (List<MOMDETAILS>)context.MOMDETAILS.Where(x => x.MOMDETAILS1 == id && x.ATR==status).ToList();


        //    MOMList.DataSource = list;

        //    MOMList.DataBind();
        //}
    }
}
  


    
