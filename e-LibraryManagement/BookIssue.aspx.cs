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
    public partial class BookIssue : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        { 
          
           
                GdBookIssued.DataBind();
            
            
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if(CheckIfBookExist() && CheckIfMemberExist())
            {
                if(CheckIssueMember())
                {
                    Response.Write("<script> alert('This Member has already Issued this Book');</script>");
                }
                else
                {
                    IssueBook();
                }
               
            }
            else
            {
                Response.Write("<script> alert('Invalid Book ID' and Member ID');</script>");

            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExist() && CheckIfMemberExist())
            {
                if (CheckIssueMember())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script> alert('This Entry does not exist');</script>");
                }

            }
            else
            {
                Response.Write("<script> alert('Invalid Book ID and Member ID');</script>");

            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetNames();
        }


        // user defined 


        void ReturnBook()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("delete from book_issue where book_id='" + txtBookId.Text.Trim() + "' AND member_id='"+txtMemberId.Text.Trim()+"' ", con1);
                int result = cmd.ExecuteNonQuery();
                
                if(result > 0)
                {
                    
                    cmd = new SqlCommand("update book_master set current_stock = current_stock+1 where book_id ='" + txtBookId.Text.Trim() + "'", con1);
                    cmd.ExecuteNonQuery();
                    con1.Close();

                    Response.Write("<script> alert('Book Returned Successfully');</script>");
                    ClearALL();
                    GdBookIssued.DataBind();
                    con1.Close();


                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }


        void IssueBook()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("insert into book_issue(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con1);
                cmd.Parameters.AddWithValue("@member_id", txtMemberId.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", txtMemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", txtBookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", txtStartDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", txtEndDate.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update book_master set current_stock = current_stock-1 where book_id = '" + txtBookId.Text.Trim() + "'", con1);
                cmd.ExecuteNonQuery();


                con1.Close();

                Response.Write("<script> alert('Book Issued Successfully');</script>");
                ClearALL();

                GdBookIssued.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
            }
        }

        bool CheckIfBookExist()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master where book_id='" + txtBookId.Text.Trim() + "' AND current_stock >0", con1);
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

        bool CheckIfMemberExist()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_master where memberid='" + txtMemberId.Text.Trim() + "'", con1);
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

        bool CheckIssueMember()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue where member_id='" + txtMemberId.Text.Trim() + "' AND book_id='"+txtBookId.Text.Trim()+"'", con1);
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
                Response.Write("<script> alert('" + ex.Message + "'),</script>");
                return false;
            }
        }


        void GetNames()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                    SqlCommand cmd = new SqlCommand("select book_name from book_master where book_id='" + txtBookId.Text.Trim() + "'", con1);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count >= 1)
                    {
                        txtBookName.Text = dt.Rows[0]["book_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> alert('Invalid Book ID');</script>");
                    }

                 cmd = new SqlCommand("select full_name from member_master where memberid='" + txtMemberId.Text.Trim() + "'", con1);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txtMemberName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Member ID');</script>");
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void ClearALL()
        {
            txtMemberId.Text = "";
            txtBookId.Text = "";
            txtBookName.Text = "";
            txtMemberName.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }

        protected void GdBookIssued_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
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