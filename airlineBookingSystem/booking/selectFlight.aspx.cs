using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.booking
{
    public partial class selectFlight : System.Web.UI.Page
    {
        string origin;
        string destination;
        string depart_date;
        string return_date;
        string user_name;
        string user_id;
        string session_code;
        string return_id_flight;
        string depart_id_flight;

        //session data

        int  id_From_db;
        protected void Page_Load(object sender, EventArgs e)
        {
            check_id();


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

            origin = (string)Session["origin"];
            destination = (string)Session["destination"];
            depart_date = (string)Session["departDate"];
            return_date = (string)Session["returnDate"];
            user_id = (string)Session["uid"];



            if (string.IsNullOrEmpty(depart_date) && string.IsNullOrEmpty(return_date))
                 {

                 }
            else if (string.IsNullOrEmpty(return_date))
                 {
                //only depart table select command
                SqlDataSource1.SelectCommand = ("SELECT * FROM [flight] where departure_location = '" + origin + "' AND destinatioin_location ='" + destination + "' AND departure_time > '" + depart_date + "'");
                Book_Flight_btn.Visible = true;


            }
            else
                 {

                // depart table select command
                SqlDataSource1.SelectCommand = ("SELECT * FROM [flight] where departure_location = '" + origin + "' AND destinatioin_location ='" + destination + "' AND departure_time > '"+depart_date+"'");

                //return table select command
                SqlDataSource2.SelectCommand = ("SELECT * FROM [flight] where departure_location = '" + destination + "' AND destinatioin_location ='" + origin + "' AND departure_time > '" + return_date + "'");
                Book_Flight_btn.Visible = true;
            }





            //one way flight

            //return flight if available
            //SqlDataSource1.SelectCommand = ("SELECT * FROM [flight] where departure_location = '" + destination + "' AND destinatioin_location ='" + origin + "'");
        }
        /*
          Session["origin"] = origin_txtfield.Text;
          Session["destination"] = destination_txtfield.Text;
          Session["departDate"] = departDate_txtfield.Text;
          Session["returnDate"] = returnDate_txtfield.Text;
          Session["guestsNr"] = guests_txtfield.Text;
          Session["sessionUniqueID"] = sessionID;             
         */


        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)

        {

            if (e.AffectedRows < 1)

            {
               // depart_table_lbl.Enabled =true;
                depart_table_lbl.Text = "No Flights were found from " +origin+" to "+destination;
                // perform action

            }

        }

        protected void SqlDataSource2_Selected(object sender, SqlDataSourceStatusEventArgs e)

        {

            if (e.AffectedRows < 1)

            {
                // depart_table_lbl.Enabled =true;
                Book_Flight_btn.Visible = false;
                return_table_lbl.Text = "No Flights were found from "+destination+" to "+origin;
                // perform action

            }
            
        }

        private void selectStatment()
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_flight_departTable_lbl.Text = "Selected Depart Flight ID is: "+GridView1.SelectedRow.Cells[0].Text;
            depart_id_flight = GridView1.SelectedRow.Cells[0].Text.ToString();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_flight_returnTable_lbl.Text = "Selected Return Flight ID is: " + GridView2.SelectedRow.Cells[0].Text;
            return_id_flight= GridView2.SelectedRow.Cells[0].Text.ToString();
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
            /*
           origin = (string)Session["origin"];
           destination = (string)Session["destination"];
           depart_date = (string)Session["departDate"];
           return_date = (string)Session["returnDate"];
           user_id = (string)Session["uid"];
            */
            if (selected_flight_departTable_lbl.Text != "" && selected_flight_returnTable_lbl.Text != "")
            {
                //depart
                //registerNewUser();            
                SqlDataSource3.InsertCommandType = SqlDataSourceCommandType.Text;
                SqlDataSource3.InsertCommand = "Insert into ticket_details (ticket_id,customer_ID,flight_id," +
                                                                       "flight_date,Payment_Status) " +
                                                                       "VALUES (@ticket_id,@customer_id,@flight_id,@flight_date,@Payment_Status)";
                SqlDataSource3.InsertParameters.Add("ticket_id", "00" + id_From_db);
                SqlDataSource3.InsertParameters.Add("customer_id", user_id);
                SqlDataSource3.InsertParameters.Add("flight_id", GridView1.SelectedRow.Cells[0].Text);
                SqlDataSource3.InsertParameters.Add("flight_date", DateTime.Today.ToString("yyyy-MM-dd"));
                SqlDataSource3.InsertParameters.Add("Payment_Status", "ok");

                SqlDataSource3.Insert();

                //return 
                //registerNewUser();
                int id_From_db_return = id_From_db + 1;
                SqlDataSource3.InsertCommandType = SqlDataSourceCommandType.Text;
                SqlDataSource3.InsertCommand = "Insert into ticket_details (ticket_id,customer_ID,flight_id," +
                                                                       "flight_date,Payment_Status) " +
                                                                       "VALUES (@ticket_id1,@customer_id1,@flight_id1,@flight_date1,@Payment_Status1)";
                SqlDataSource3.InsertParameters.Add("ticket_id1", "00" + id_From_db_return);
                SqlDataSource3.InsertParameters.Add("customer_id1", user_id);
                SqlDataSource3.InsertParameters.Add("flight_id1", GridView2.SelectedRow.Cells[0].Text);
                SqlDataSource3.InsertParameters.Add("flight_date1", DateTime.Today.ToString("yyyy-MM-dd"));
                SqlDataSource3.InsertParameters.Add("Payment_Status1", "ok");

                SqlDataSource3.Insert();
                Response.Redirect("~/user_management/receipt", false);
            }
            else if (selected_flight_departTable_lbl.Text != "")
            {
                //depart only
                //registerNewUser();            
                SqlDataSource3.InsertCommandType = SqlDataSourceCommandType.Text;
                SqlDataSource3.InsertCommand = "Insert into ticket_details (ticket_id,customer_ID,flight_id," +
                                                                       "flight_date,Payment_Status) " +
                                                                       "VALUES (@ticket_id,@customer_id,@flight_id,@flight_date,@Payment_Status)";
                SqlDataSource3.InsertParameters.Add("ticket_id", "00" + id_From_db);
                SqlDataSource3.InsertParameters.Add("customer_id", user_id);
                SqlDataSource3.InsertParameters.Add("flight_id", GridView1.SelectedRow.Cells[0].Text);
                SqlDataSource3.InsertParameters.Add("flight_date", DateTime.Today.ToString("yyyy-MM-dd"));
                SqlDataSource3.InsertParameters.Add("Payment_Status", "ok");
                SqlDataSource3.Insert();
                Response.Redirect("~/user_management/receipt", false);
            }
            

           


        }
        private void check_id()
        {
            SqlDataSource4.SelectCommand = "SELECT * FROM [ticket_details]";
            System.Data.DataView dv = (System.Data.DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
            lbl.Text = dv.Count.ToString();
            id_From_db = dv.Count + 1;
        }

        protected void SqlDataSource4_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            lbl.Text = e.AffectedRows.ToString();

        }

    }
}