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
    public partial class SignUp : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {  
            if(checkMemberExists())
            {
                Response.Write("<script> alert('Member ID Already Exist');</script>");
            }
            else
            {
                signupNewUser();
            }
           
            
        }

          bool checkMemberExists()
          {

            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master where memberid='"+txtMemberID.Text.Trim()+"'", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt =  new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               
                

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
                return false;
            }

           
          }
           

        void signupNewUser()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("insert into member_master(full_name,dob,contact_no,email,state,city,pincode,full_address,password,account_status,memberid) values(@full_name,@dob ,@contact_no ,@email ,@state ,@city ,@pincode ,@full_address ,@password ,@account_status ,@memberid)", con1);
                cmd.Parameters.AddWithValue("@full_name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txtDateOfBirth.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txtMobileNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmailID.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddlState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtPinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.Parameters.AddWithValue("@memberid", txtMemberID.Text.Trim());

                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Registration Successful');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        
        }
    }
}