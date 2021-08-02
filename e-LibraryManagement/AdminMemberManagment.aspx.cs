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
    public partial class AdminMemberManagment : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GdMemberList.DataBind();
        }

        protected void lnkGo_Click(object sender, EventArgs e)
        {
            GetMemberById();
        }

        protected void lnkA_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("active");
        }

        protected void lnkP_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("pending");
        }

        protected void lnkD_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("deactive");
        }

        protected void btndeletedData_Click(object sender, EventArgs e)
        {
            DeleteMember();
        }


        //user defined function

        bool CheckIFMemberExists()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master where memberid='" +txtMemberId.Text.Trim() + "'", con1);

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

        void GetMemberById()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from member_master where memberid='" + txtMemberId.Text.Trim() + "'", con1);

                SqlDataReader dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtFullName.Text = dr.GetValue(0).ToString();

                        txtAccountStatus.Text = dr.GetValue(9).ToString();
                        txtDOB.Text = dr.GetValue(1).ToString();
                        txtContactNo.Text = dr.GetValue(2).ToString();
                        txtEmail.Text = dr.GetValue(3).ToString();
                        txtState.Text = dr.GetValue(4).ToString();
                        txtCity.Text = dr.GetValue(5).ToString();
                        txtPinCode.Text = dr.GetValue(6).ToString();
                        txtFullAddress.Text = dr.GetValue(7).ToString();
                    }

                }
                else
                {
                    Response.Write("<script> alert('Invalid Member ID');</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");

            }
        }


        void UpdateMemberStatusById(string status)
        {
            if(CheckIFMemberExists())
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(con);
                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();

                    }

                    SqlCommand cmd = new SqlCommand("update member_master set account_status='" + status + "' where memberid='" + txtMemberId.Text.Trim() + "'", con1);

                    cmd.ExecuteNonQuery();
                    con1.Close();
                    GdMemberList.DataBind();
                    Response.Write("<script> alert('Member Status Update');</script>");

                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'),</script>");

                }
            }
            else
            {
                Response.Write("<script> alert('Invalid Member ID');</script>");
            }
           
        }

        void DeleteMember()
        { 
            if(CheckIFMemberExists())
            {
                
                try
                {
                    SqlConnection con1 = new SqlConnection(con);
                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();

                    }
                    SqlCommand cmd = new SqlCommand("delete from member_master  where memberid= '" + txtMemberId.Text.Trim() + "' ", con1);



                    cmd.ExecuteNonQuery();
                    con1.Close();

                    Response.Write("<script> alert('Member Deleted Successfully');</script>");
                    ClearAll();
                    GdMemberList.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid Member ID');</script>");
            }
            

        }
        void ClearAll()
        {
            txtMemberId.Text = "";
            txtFullName.Text = "";

            txtAccountStatus.Text = "";
            txtDOB.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPinCode.Text = "";
            txtFullAddress.Text = "";

        }
    }

}