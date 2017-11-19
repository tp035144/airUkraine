using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.user_management
{
    public partial class login : System.Web.UI.Page
    {
        Boolean correctUser = false;
        string Uemail;
        string Upwd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn(object sender, EventArgs e)
        {
            Upwd = Password.Text;
            Uemail = email.Text;
            lbl.Visible = true;

            SqlDataSource3.SelectCommand = ("SELECT customer_ID FROM [customer] where customer_email ='"+Uemail+"' AND customer_pwd = '"+Upwd+"'");

            DataSourceSelectArguments sr = new DataSourceSelectArguments();
            System.Data.DataView dv = (System.Data.DataView)SqlDataSource3.Select(sr);
            if (dv.Count!=0)
            {                
                Session["uid"] = dv[0][0].ToString();
            }


            if (correctUser.Equals(true))
            {
                lbl.Text = "Correct Credentials Inserted";
                Response.Redirect("~/user_management/userHomePage", false); //create a user page with few options (book, view profile, view booking list)
                Session["email"] = Uemail;
                Session["state"] = "logged in";
               
            }
            else
            {
                lbl.Text = "Wrong Credentials inserted";
            }
        }

        protected void SqlDataSource3_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            
            if (e.AffectedRows < 1)

            {
                correctUser = false;
            }
            else
            {
                correctUser = true;
            }
        }

    } 

    }