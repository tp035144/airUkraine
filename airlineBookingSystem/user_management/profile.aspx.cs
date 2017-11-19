using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.user_management
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                //Response.Redirect("~/Error.aspx", false);
            }
            else
            {

                logoutButton.Visible = true;
                showusername();// display username on the top corner
                if (!IsPostBack)//check if the request is a postback from the same page--only get data from database if it is  not a postback
                {

                }
            }
        }
        
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("/user_management/HomePage.aspx");
        }

        protected void showusername()
        {
            string name;
            name = (String)(Session["email"]);
            userL.Visible = true;
            userL.Text = "Hi, " + name;
        }

        protected void btnReset(object sender, EventArgs e)
        {
           // populateProfile();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.Parameters["@c_ID"].Value = (string)Session["uid"];
        }
    }
}