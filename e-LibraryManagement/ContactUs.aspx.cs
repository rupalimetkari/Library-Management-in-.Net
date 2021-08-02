using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace e_LibraryManagement
{
    public partial class ContactUs : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            UserContact();
           

        }
        void UserContact()
        {
            SqlConnection con1 = new SqlConnection(con);
            if(con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into Contact(Name, Address, Contact, Email,Message) values(@Name,@Address,@Contact,@Email,@Message)", con1);
            cmd.Parameters.AddWithValue("@Name",txtFullName.Text.Trim());
            cmd.Parameters.AddWithValue("@Address",txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Contact", txtMobileNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmailID.Text.Trim());
            cmd.Parameters.AddWithValue("@Message", txtMessage.Text.Trim());

            cmd.ExecuteNonQuery();
            con1.Close();
            ClearAll();
            Response.Write("<script> alert('Message Send Successful');</script>");
        }

        void ClearAll()
        {
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtEmailID.Text = "";
            txtMessage.Text = "";
        }
    }
}