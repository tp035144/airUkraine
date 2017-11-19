using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.user_management
{
    public partial class receipt : System.Web.UI.Page
    {
        string ticket_id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

          ticket_id = GridView1.SelectedRow.Cells[0].Text;
            

        }

        protected void cancel_book_flight(object sender, EventArgs e)
        {
            SqlDataSource1.Update();
        }

        protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@status"].Value = "ABORT";
            e.Command.Parameters["@ticket_id"].Value = GridView1.SelectedRow.Cells[0].Text;
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
           e.Command.Parameters["@c_ID"].Value = (string)Session["uid"];
        }
    }
}