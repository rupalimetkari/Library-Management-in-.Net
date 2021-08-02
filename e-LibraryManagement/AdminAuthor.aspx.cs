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
    public partial class AdminAuthor : System.Web.UI.Page
    {

        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GdAuthorList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckIFAuthorExists())
            {
                Response.Write("<script> alert('Author Id already Exist');</script>");
            }
            else
            {
                AddNewAuthor();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckIFAuthorExists())
            {
                UpdateAuthor();
            }
            else
            {
                Response.Write("<script> alert('Author does not Exist');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIFAuthorExists())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script> alert('Author does not Exist');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetAuthorById();
        }

        //user defined function

            void GetAuthorById()
            {
                try
                {
                     SqlConnection con1 = new SqlConnection(con);
                     if (con1.State == ConnectionState.Closed)
                     {
                       con1.Open();

                     }
                        SqlCommand cmd = new SqlCommand("select * from author where author_id='" + txtAuthorId.Text.Trim() + "'", con1);

                       SqlDataAdapter da = new SqlDataAdapter(cmd);
                       DataTable dt = new DataTable();
                        da.Fill(dt);

                     if (dt.Rows.Count >= 1)
                     {
                           txtAuthorName.Text = dt.Rows[0][1].ToString();
                     }
                     else
                     {
                         Response.Write("<script> alert('Invalid Author ID');</script>");
                     }

                }

                catch (Exception ex)
                {
                   Response.Write("<script> alert('" + ex.Message + "'),</script>");
               
                }
            }

        void DeleteAuthor()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("delete from author where author_id= '" + txtAuthorId.Text.Trim() + "' ", con1);



                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Author Deleted Successfully');</script>");
                ClearALL();
                GdAuthorList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
            }
        }
        

         void UpdateAuthor()
         {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("update author SET author_name = @author_name where author_id= '"+ txtAuthorId.Text.Trim() +"' ", con1);
                
                cmd.Parameters.AddWithValue("@author_name", txtAuthorName.Text.Trim());


                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Author Update Successfully');</script>");
                ClearALL();
                GdAuthorList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
         }


         void AddNewAuthor()
         {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("insert into author(author_id,author_name) values(@author_id, @author_name)", con1);
                cmd.Parameters.AddWithValue("@author_id", txtAuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", txtAuthorName.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script> alert('Author Added Successfully');</script>");
                ClearALL();

                GdAuthorList.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
         }
           

        bool CheckIFAuthorExists()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from author where author_id='" + txtAuthorId.Text.Trim() + "'", con1);

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

        void ClearALL()
        {
            txtAuthorId.Text = "";
            txtAuthorName.Text = "";
        }
    }
}