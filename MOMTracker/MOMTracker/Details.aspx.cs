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

namespace MOMTracker
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ID = Request.QueryString["identifier"];
            var context = new MOMEntities();
            MEETINGTABLE USER = new MEETINGTABLE();
            AGENDATABLE AGENDA = new AGENDATABLE();
            DETAILSTABLE CP = new DETAILSTABLE();

            int id = Convert.ToInt32(ID);

            USER = context.MEETINGTABLE.Single(x => x.MEETINGID == id);
            // var X= context.MEETINGTABLE.Where(x => x.MEETINGID == Convert.ToInt32(ID)).Select(p => new { p.TITLE, p.TIME, p.MEETINGDATE, p.CHAIRPERSON });

            AGENDA = context.AGENDATABLE.Single(x => x.MEETINGID == id);
            var INVITEE = context.INVITEESTABLE.Where(x => x.MEETINGID == id).Select(P => new { P.INVITEEID }).ToList();
            List<string> NAMES = new List<string>();

            foreach (var item in INVITEE)
            {
                string name = context.DETAILSTABLE.Where(p => p.UNIQUEID == Convert.ToDecimal(item)).Select(P => P.FIRSTNAME).ToString();
                NAMES.Add(name);
            }
            Label1.Text = USER.MEETINGDATE.ToString();
            Label2.Text = USER.TIME.ToString();
            Label3.Text = USER.CHAIRPERSON.ToString();
            string noHTML = Regex.Replace(AGENDA.AGENDA, @"<[^>]+>|&nbsp;", "").Trim();
            Label4.Text = noHTML;
            // Label5.Text = NAMES.ToString();


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
                Label5.Text = ex.Message;
            }


        }
        protected void Button3_Click()
        {
            // create some string variables and assign null values 
            var ex_KEY = 1;
            var ex_STATUS = "";
            var ex_STATUSREM = "";
            var Text = "22/11/2009";

            DateTime ex_EXPECTEDCLOSURE = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
           // DateTime ex_EXPECTEDCLOSURE = Convert.ToDateTime("");
            var ex_RESP = "";
            var ex_ACTIONABLE= "";
            DateTime ex_REVIEWDATE = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
            var ex_ITEM = "";

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

                    if (o_dr[6].ToString()!= "") 
                    {
                        //get first row data and assign it ex_id variable 
                       // ex_KEY = Convert.ToInt32(o_dr[0]);
                        //get second row data and assign it ex_name variable
                        ex_STATUS = o_dr[0].ToString();
                        //get thirdt row data and assign it ex_name variable
                        ex_STATUSREM = o_dr[1].ToString();
                        ex_ITEM = o_dr[6].ToString();

                        //get first row data and assign it ex_location variable
                        ex_EXPECTEDCLOSURE = (DateTime)o_dr[2];// DateTime.ParseExact((string)o_dr[3], "dd/MM/yyyy", null);
                                                               //ex_EXPECTEDCLOSURE = Convert.ToDateTime(o_dr[3]);
                        ex_RESP = o_dr[3].ToString();
                        ex_ACTIONABLE = o_dr[4].ToString();
                        //Text = (string)o_dr[6];
                        //ex_REVIEWDATE = DateTime.ParseExact(Text, "dd/MM/yyyy", null);
                        ex_REVIEWDATE = (DateTime)o_dr[5];
                       
                        var context = new MOMEntities();
                        MOMDETAILS rec = new MOMDETAILS();
                        rec.ACTIONABLE = ex_ACTIONABLE;
                        rec.EXPECTEDCLOSURE = ex_EXPECTEDCLOSURE;
                        rec.ITEM = ex_ITEM;
                        rec.KEY = ex_KEY;
                        rec.RESP = ex_RESP;
                        rec.REVIEWDATE = ex_REVIEWDATE;
                        rec.STATUS = ex_STATUS;
                        rec.STATUSREM = ex_STATUSREM;
                        context.MOMDETAILS.Add(rec);
                        context.SaveChanges();
                    }
                    else
                    {
                        o_dr.Close();
                        break;
                    }
                    
                } //{
                        Label1.Text = "Data inserted successfully";
                   
                
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

    }       

}
    
