using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airlineBookingSystem.user_management
{
    public partial class register : System.Web.UI.Page
    {
        int id_From_db;
        protected void Page_Load(object sender, EventArgs e)
        {
            check_id();

            System.Data.DataView dv = (System.Data.DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            lbl.Text = dv.Count.ToString();
            id_From_db = dv.Count+1;

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {

           //registerNewUser();            
           SqlDataSource1.InsertCommandType = SqlDataSourceCommandType.Text;
           SqlDataSource1.InsertCommand = "Insert into customer (customer_ID,customer_Fname,customer_Lname," +
                                                                  "customer_address_City,customer_address_Country," +
                                                                  "customer_email,customer_username,customer_pwd,customer_phone) " +
                                                                  "VALUES (@id,@fName,@lName,@city,@country,@email,@userName,@pwd,@phone)";
           SqlDataSource1.InsertParameters.Add("id","C"+id_From_db );
           SqlDataSource1.InsertParameters.Add("fName", fname.Text);
           SqlDataSource1.InsertParameters.Add("lName", lname.Text);
           SqlDataSource1.InsertParameters.Add("city", "generic");
           SqlDataSource1.InsertParameters.Add("country", "generic");
           //SqlDataSource1.InsertParameters.Add("postalcode", "0000");
           SqlDataSource1.InsertParameters.Add("email", Email.Text);
           SqlDataSource1.InsertParameters.Add("userName", "generic");
           SqlDataSource1.InsertParameters.Add("pwd", Password.Text);
           SqlDataSource1.InsertParameters.Add("phone", phoneNr.Text);            
           SqlDataSource1.Insert();
           Response.Redirect("~/user_management/login", false);
        }

        private void check_id()
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM [customer]";
        }

        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            lbl.Text = e.AffectedRows.ToString();

        }
    }
}