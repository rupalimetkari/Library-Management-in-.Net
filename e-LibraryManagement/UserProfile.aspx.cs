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
    public partial class UserProfile : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GdUserIssuedBooks.DataBind();
            try
            {
                if(Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script> alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    GetUserData();
                    if(!Page.IsPostBack)
                    {
                        GetUserProfile();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
                Response.Write("<script> alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script> alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                UpdateUserProfile();
            }
        }

        // user defined function

            void UpdateUserProfile()
            {
            string password = "";
            if(txtPassword.Text.Trim() == "")
            {
                password = txtOldPassword.Text.Trim();
            }
            else
            {
                password = txtPassword.Text.Trim();
            }



            try
            { 
              SqlConnection con1 = new SqlConnection(con);
            if (con1.State == ConnectionState.Closed)
            {
              con1.Open();

            }

             SqlCommand cmd = new SqlCommand("update member_master set full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,password=@password,account_status=@account_status where memberid='"+ Session["username"].ToString().Trim() +"'",con1);
             cmd.Parameters.AddWithValue("@full_name",txtFullName.Text.Trim());
             cmd.Parameters.AddWithValue("@dob", txtDateOfBirth.Text.Trim());
             cmd.Parameters.AddWithValue("@contact_no", txtMobileNo.Text.Trim());
             cmd.Parameters.AddWithValue("@email", txtEmailID.Text.Trim());
             cmd.Parameters.AddWithValue("@state",ddlState.SelectedItem.Value);
             cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());
             cmd.Parameters.AddWithValue("@pincode", txtPinCode.Text.Trim());
             cmd.Parameters.AddWithValue("@full_address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");
                             

                int result = cmd.ExecuteNonQuery();
                con1.Close();
            if (result > 0)
            {
                    Response.Write("<script> alert('Your Details Update Successfully');</script>");
                    GetUserProfile();
                    GetUserData();
            }
            else
            {
                    Response.Write("<script> alert('Invalid Entry');</script>");
            }


            }
            catch (Exception ex)
            {
                         Response.Write("<script> alert('" + ex.Message + "'),</script>");

            }
            }

            void GetUserProfile()
            {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master where memberid='" + Session["username"].ToString() + "';", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtFullName.Text = dt.Rows[0]["full_name"].ToString();
                txtDateOfBirth.Text = dt.Rows[0]["dob"].ToString();
                txtMobileNo.Text = dt.Rows[0]["contact_no"].ToString();
                txtEmailID.Text = dt.Rows[0]["email"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                txtCity.Text = dt.Rows[0]["city"].ToString();
                txtPinCode.Text = dt.Rows[0]["pincode"].ToString();
                txtAddress.Text = dt.Rows[0]["full_address"].ToString();
                txtMemberID.Text = dt.Rows[0]["memberid"].ToString();
                txtOldPassword.Text = dt.Rows[0]["password"].ToString();

                lblProfile.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if(dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    lblProfile.Attributes.Add("class", "badge badge-pill badge-success");
                }
               else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
               {
                    lblProfile.Attributes.Add("class", "badge badge-pill badge-warning");
               }
               else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
               {
                    lblProfile.Attributes.Add("class", "badge badge-pill badge-danger");
               }
               else 
               {
                    lblProfile.Attributes.Add("class", "badge badge-pill badge-info");
               }









            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");

            }
        }

        void GetUserData()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from book_issue where member_id='" + Session["username"].ToString() + "';", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GdUserIssuedBooks.DataSource = dt;
                GdUserIssuedBooks.DataBind();

                        

            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");

            }
        }

        protected void GdUserIssuedBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }



                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }
}