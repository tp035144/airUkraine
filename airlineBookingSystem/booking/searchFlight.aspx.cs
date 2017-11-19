using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.booking
{
    public partial class searchFlight : System.Web.UI.Page
    {
        string sessionID;
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



        private void getUserInput()
        {
            //departDate_txtfield //returnDate_txtfiel //guests_txtfield //destination_txtfield //origin_txtfield //return_flight_chkbox
            //create a session and store this info into the session
            sessionID = System.Web.HttpContext.Current.Session.SessionID;
            Session["origin"] = origin_txtfield.Text;
            Session["destination"] = destination_txtfield.Text;
            Session["departDate"] = departDate_txtfield.Text;
            Session["returnDate"] = returnDate_txtfield.Text;
            Session["guestsNr"] = guests_txtfield.Text;
            Session["sessionUniqueID"] = sessionID;

        }

        protected void search_flight(object sender, EventArgs e)
        {
            getUserInput();
            Response.Redirect("~/booking/selectFlight.aspx", false);
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

        protected void Book_Flight(object sender, EventArgs e)
        {

        }

    }
}