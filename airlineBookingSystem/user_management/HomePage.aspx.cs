using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

namespace airlineBookingSystem.user_management
{
    public partial class HomePage : System.Web.UI.Page
    {
        string sessionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            // ConnectionStringsSection connSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //connSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //config.Save();
        }
        protected void search_flight_btn(object sender, EventArgs e)
        {
            // string t = 
        }

        private void getUserInput()
        {
            //departDate_txtfield
            //returnDate_txtfield
            //guests_txtfield
            //destination_txtfield
            //origin_txtfield
            //return_flight_chkbox

            //create a session and store this info into the session
            sessionID = System.Web.HttpContext.Current.Session.SessionID;
            //Session["origin"] = returnDate_txtfield.Text;
            //Session["destination"] = ID;
            //Session["departDate"] = pwd;
            //Session["returnDate"] = email;
            //Session["guestsNr"] = "student";
            Session["returnFlightChkbox"] = sessionID;
        }
    }
}