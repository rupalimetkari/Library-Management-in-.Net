using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace e_LibraryManagement
{
    public partial class BookInventoryaspx : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["MyTest"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!IsPostBack)
            {
                FillAuthorPublisherValue();
            }
            
            GdInventoryList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckIFBookExists())
            {
                Response.Write("<script> alert('Book Already Exist');</script>");
            }
            else
            {

                AddNewBook();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateBookByID();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteBookById();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            GetBookByID();
        }


        // user defined function 


        void GetBookByID()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from book_master where book_id='" + txtBookId.Text.Trim() + "'", con1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    txtBookName.Text = dt.Rows[0]["book_name"].ToString().Trim();
                    ddlLanuage.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    ddlAuthorList.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    lbGenre.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                      for(int i = 0; i<genre.Length; i++)
                      {
                        for(int j = 0; j<lbGenre.Items.Count; j++)
                        {
                            if(lbGenre.Items[j].ToString() == genre[i])
                            {
                                lbGenre.Items[j].Selected = true;
                            }
                            
                        }
                      }
                      
                    ddlPublisherName.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    txtPublisherDate.Text = dt.Rows[0]["publish_date"].ToString().Trim();
                    txtEdition.Text = dt.Rows[0]["edition"].ToString().Trim();
                    txtBookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    txtPages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    txtBookDescription.Text = dt.Rows[0]["book_description"].ToString().Trim(); 
                    txtActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    txtCurrentStock.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script> alert('Invalid Book ID');</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");

            }
        }

        void FillAuthorPublisherValue()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if(con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                SqlCommand cmd = new SqlCommand("select author_name from author;", con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlAuthorList.DataSource = dt;
                ddlAuthorList.DataValueField = "author_name";
                ddlAuthorList.DataBind();

                 cmd = new SqlCommand("select publisher_name from publisher_master;", con1);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);

                ddlPublisherName.DataSource = dt;
                ddlPublisherName.DataValueField = "publisher_name";
                ddlPublisherName.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        bool CheckIFBookExists()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from book_master where book_id='" + txtBookId.Text.Trim() + "' OR book_name = '"+txtBookName.Text.Trim()+"'", con1);

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

        void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i  in lbGenre.GetSelectedIndices())
                {
                    genres = genres + lbGenre.Items[i] + ",";
                }

                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/images.jpg";
                string filename = Path.GetFileName(fuBookDetails.PostedFile.FileName);
                 fuBookDetails.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con1 = new SqlConnection(con);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }

                SqlCommand cmd = new SqlCommand("insert into book_master(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con1);
                cmd.Parameters.AddWithValue("@book_id", txtBookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);

                cmd.Parameters.AddWithValue("@author_name", ddlAuthorList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", txtPublisherDate.Text.Trim());

                cmd.Parameters.AddWithValue("@language", ddlLanuage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", txtBookDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", txtActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", txtActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con1.Close();
                Response.Write("<script> alert('Book added Successfully');</script>");
                GdInventoryList.DataBind();
                ClearAll();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void UpdateBookByID()
        {
            if (CheckIFBookExists())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(txtActualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(txtCurrentStock.Text.Trim());

                    if(global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if(actual_stock < global_issued_books)
                        {
                            Response.Write("<script> alert('Actual Stock value cannot be less than Issued books');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            txtCurrentStock.Text = "" + current_stock ;
                        }

                    }

                    string genres = "";
                    foreach (int i in lbGenre.GetSelectedIndices())
                    {
                        genres = genres + lbGenre.Items[i] + ",";
                    }

                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/images.jpg";
                    string filename = Path.GetFileName(fuBookDetails.PostedFile.FileName);
                    if(filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        fuBookDetails.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con1 = new SqlConnection(con);
                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();

                    }

                    SqlCommand cmd = new SqlCommand("update book_master set book_name=@book_name, genre=@genre,author_name=@author_name, publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock,book_img_link=@book_img_link where book_id='"+txtBookId.Text.Trim()+"'", con1);

                  
                    cmd.Parameters.AddWithValue("@book_name", txtBookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre",genres);

                    cmd.Parameters.AddWithValue("@author_name", ddlAuthorList.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", ddlPublisherName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", txtPublisherDate.Text.Trim());

                    cmd.Parameters.AddWithValue("@language", ddlLanuage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", txtBookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", txtPages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", txtBookDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con1.Close();
                    GdInventoryList.DataBind();
                    Response.Write("<script> alert('Books Details Update');</script>");

                }

                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'),</script>");

                }
            }
            else
            {
                Response.Write("<script> alert('Invalid Book ID');</script>");
            }
        }

        void DeleteBookById()
        {
            if (CheckIFBookExists())
            {

                try
                {
                    SqlConnection con1 = new SqlConnection(con);
                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();

                    }
                    SqlCommand cmd = new SqlCommand("delete from book_master  where book_id= '" + txtBookId.Text.Trim() + "' ", con1);



                    cmd.ExecuteNonQuery();
                    con1.Close();

                    Response.Write("<script> alert('Book Details Deleted Successfully');</script>");
                    ClearAll();
                    GdInventoryList.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'),</script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid Book ID');</script>");
            }
        }

        void ClearAll()
        {
            txtBookId.Text = "";
            txtBookName.Text = "";
            lbGenre.SelectedItem.Value = "";
            ddlAuthorList.SelectedItem.Value = "";
            ddlPublisherName.SelectedItem.Value = "";
            txtPublisherDate.Text = "";
            ddlLanuage.SelectedItem.Value = "";
            txtBookCost.Text = "";
            txtEdition.Text = "";
            txtPages.Text = "";
            txtBookDescription.Text = "";
            txtActualStock.Text = "";
           






        }

       
    }
}