﻿using System;
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
    public partial class userlogin : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }

            SqlCommand cmd = new SqlCommand("select * from member_master where memberid='" + txtMemberId.Text.Trim() + "' AND password='"+txtMemberPassword.Text.Trim()+"'", con1);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script> alert('Login Successful');</script>");
                        Session["username"] = dr.GetValue(10).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(9).ToString();
                    }
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Invalid Login Credentials');</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}