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
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    lnkUserLogin.Visible = true;
                    lnkSIgnUp.Visible = true;

                    lnkLogout.Visible = false;
                    lnkHello.Visible = false;
                    lnkAdminLogin.Visible = true;
                    lnkAuthor.Visible = false;
                    lnkPublisherManage .Visible = false;
                    lnkBookInventory.Visible = false;
                    lnkBookIsuue.Visible = false;
                    lnkMember.Visible = false;

                }
                else if(Session["role"].Equals("user"))
                {
                    lnkAdminLogin.Visible = true;
                    lnkLogout.Visible = true;
                    lnkHello.Visible = true;

                    lnkHello.Text = "Hello" + Session["username"].ToString();

                    lnkUserLogin.Visible = false;
                    lnkSIgnUp.Visible = false;
                    lnkAuthor.Visible = false;
                    lnkPublisherManage.Visible = false;
                    lnkBookInventory.Visible = false;
                    lnkBookIsuue.Visible = false;
                    lnkMember.Visible = false;

                }

                else if (Session["role"].Equals("admin"))
                {
                    lnkAdminLogin.Visible = false;
                    lnkLogout.Visible = true;
                    lnkHello.Visible = true;

                    lnkHello.Text = "Hello Admin";

                    lnkUserLogin.Visible = false;
                    lnkSIgnUp.Visible = false;
                    lnkAuthor.Visible = true;
                    lnkPublisherManage.Visible = true;
                    lnkBookInventory.Visible = true;
                    lnkBookIsuue.Visible = true;
                    lnkMember.Visible = true;

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }

        }

        protected void lnkAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void lnkAuthor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthor.aspx");
        }

       

        protected void lnkPublisherManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisher.aspx");
        }

        protected void lnkBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInventory.aspx");
        }

        protected void lnkBookIsuue_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssue.aspx");
        }

        protected void lnkMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagment.aspx");
        }

        protected void lnkUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void lnkSIgnUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            lnkUserLogin.Visible = true;
            lnkSIgnUp.Visible = true;

            lnkLogout.Visible = false;
            lnkHello.Visible = false;
            lnkAdminLogin.Visible = true;
            lnkAuthor.Visible = false;
            lnkPublisherManage.Visible = false;
            lnkBookInventory.Visible = false;
            lnkBookIsuue.Visible = false;
            lnkMember.Visible = false;

            Response.Redirect("home.aspx");
        }

        protected void lnkViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void lnkHello_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}