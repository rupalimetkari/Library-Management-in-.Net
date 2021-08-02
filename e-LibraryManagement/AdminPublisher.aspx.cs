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
    public partial class AdminPublisher : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GdPublisherList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkIFPublisherExists())
            {
                Response.Write("<script> alert('Publisher Id already Exist');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkIFPublisherExists())
            {
                updatePublisher();
            }
            else
            {
               
                Response.Write("<script> alert('Publisher does not Exist');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkIFPublisherExists())
            {
                deletepublisher();
            }
            else
            {
                Response.Write("<script> alert('Publisher does not Exist');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getpublisherById();

        }

        //user defined function

        void getpublisherById()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master where publisher_id='" + txtPublisherId.Text.Trim() + "'", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    txtPublisherName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Publisher ID');</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIFPublisherExists()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master where publisher_id='" + txtPublisherId.Text.Trim() + "'", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
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

        void clearALL()
        {
            txtPublisherId.Text = "";
            txtPublisherName.Text = "";
        }

        void addNewPublisher()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("insert into publisher_master(publisher_id,publisher_name) values(@publisher_id, @publisher_name)", con1);
                cmd.Parameters.AddWithValue("@publisher_id", txtPublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", txtPublisherName.Text.Trim());


                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Publisher Added Successfully');</script>");
                clearALL();
                GdPublisherList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
            }
        }


        void updatePublisher()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("update publisher_master SET publisher_name = @publisher_name where publisher_id= '" + txtPublisherId.Text.Trim() + "' ", con1);

                cmd.Parameters.AddWithValue("@publisher_name", txtPublisherName.Text.Trim());


                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Publisher Update Successfully');</script>");
                clearALL();
                GdPublisherList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void deletepublisher()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("delete from publisher_master  where publisher_id= '" + txtPublisherId.Text.Trim() + "' ", con1);



                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Publisher Deleted Successfully');</script>");
                clearALL();
                GdPublisherList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
 
    }
}