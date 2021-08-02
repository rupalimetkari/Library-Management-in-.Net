<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="e_LibraryManagement.BookInventoryaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type ="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
    <div class="container-fluid">
         <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                       
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Books Details</h4>
                                    
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img src="book_inventory/images.jpg" style="width:100px; height:150px" id="imgview" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="fuBookDetails" runat="server" CssClass="form-control" onchange="readURL(this);" />
                                
                            </div>
                        </div>
                        

                        <div class="row">

                            <div class="col-md-4">
                                <label>Book ID :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookId" runat="server" CssClass="form-control"
                                            placeholder="Id"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" CssClass="btn btn-primary form-control" Text="Go" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Book Name :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control"
                                       placeholder="Book Name"></asp:TextBox>
                                </div>

                            </div>
                           
                            
                        </div>


                         <div class="row">

                            <div class="col-md-4">
                                 <label>Language :</label>
                                 <div class="form-group">
                                     <asp:DropDownList ID="ddlLanuage" runat="server" Class="form-control">
                                         <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                         <asp:ListItem>English</asp:ListItem>
                                         <asp:ListItem>Hindi</asp:ListItem>
                                         <asp:ListItem>Marathi</asp:ListItem>
                                         <asp:ListItem>Sanscrit</asp:ListItem>
                                         <asp:ListItem>French</asp:ListItem>
                                         <asp:ListItem>German</asp:ListItem>
                                         <asp:ListItem>Urdu</asp:ListItem>

                                     </asp:DropDownList>
                                     
                                 </div>
                                <label>Publisher Name :</label>
                                 <div class="form-group">
                                     <asp:DropDownList ID="ddlPublisherName" runat="server" Class="form-control">
                                        
                                        

                                     </asp:DropDownList>
                             </div>
                             </div>

                              <div class="col-md-4">
                                 <label>Author Name :</label>
                                 <div class="form-group">
                                     <asp:DropDownList ID="ddlAuthorList" runat="server" Class="form-control">
                                         
                                         

                                     </asp:DropDownList>
                                     
                                 </div>
                                <label>Publisher Date :</label>
                                 <div class="form-group">
                                      <asp:TextBox ID="txtPublisherDate" runat="server" CssClass="form-control"
                                          placeholder="Date" TextMode="Date"></asp:TextBox>
                             </div>
                             </div>
                             <div class="col-md-4">
                                 <label>Genre :</label>
                                 <div class="form-group">
                                     <asp:ListBox ID="lbGenre" runat="server" SelectionMode="Multiple"  CssClass="form-control" Rows="5">
                                         <asp:ListItem>Action</asp:ListItem>
                                         <asp:ListItem>Fiction</asp:ListItem>
                                         <asp:ListItem>Comic Book</asp:ListItem>
                                         <asp:ListItem>Novel</asp:ListItem>
                                         <asp:ListItem>Drama</asp:ListItem>
                                         <asp:ListItem>Poetry</asp:ListItem>
                                         <asp:ListItem>Thriller</asp:ListItem>
                                         <asp:ListItem>Horror</asp:ListItem>
                                         <asp:ListItem>Science</asp:ListItem>
                                         <asp:ListItem>Techincal</asp:ListItem>
                                         <asp:ListItem>Art</asp:ListItem>
                                         <asp:ListItem>Crime</asp:ListItem>
                                         <asp:ListItem>Fantasy</asp:ListItem>
                                         <asp:ListItem>Cooking</asp:ListItem>
                                         <asp:ListItem>Wellness</asp:ListItem>
                                          <asp:ListItem>economics</asp:ListItem>

                                     </asp:ListBox> 
                                 </div>
                             </div>

                        </div>

                         

                        <div class="row">

                            <div class="col-md-4">
                                <label>Edition:</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEdition" runat="server" CssClass="form-control"
                                        placeholder="Edition"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per Unit) :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookCost" runat="server" CssClass="form-control"
                                        placeholder="Cost" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPages" runat="server" CssClass="form-control"
                                        placeholder="Pages" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Actual Stock:</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtActualStock" runat="server" CssClass="form-control"
                                        placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Current Stock :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCurrentStock" runat="server" CssClass="form-control"
                                        placeholder="Current Stock" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Book :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIssuedBooks" runat="server" CssClass="form-control"
                                        TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Book Description :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtBookDescription" runat="server" CssClass="form-control"
                                   placeholder="Book Description"  TextMode="MultiLine" Rows="2"></asp:TextBox>
                                 </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" 
                                    CssClass="btn btn-lg btn-block btn-success" OnClick="btnAdd_Click"/>
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                                    CssClass="btn btn-lg btn-block btn-warning" OnClick="btnUpdate_Click"/>
                            </div>
                             <div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                    CssClass="btn btn-lg btn-block btn-danger" OnClick="btnDelete_Click"/>
                            </div>
                           
                           
                        </div>

                    </div>

                    </div>
                </div>
           

             <div class="col-md-6">
                 <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
                                    
                                </center>
                            </div>
                        </div>

                         
                        <div class="row">
                            <div class="col">

                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataBookInventory" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryConnectionString %>" SelectCommand="SELECT * FROM [book_master]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GdInventoryList"  runat="server" 
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataBookInventory">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                       
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                       
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author:<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    | Genre:
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    | Language:
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                Publisher:
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                | Publish Date:
                                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                | Pages:
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                | Edition:
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("edition") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Cost:
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    | Actual Stock:
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    | Avaialble Stock:
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description:
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>



                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="Image1" CssClass="img-fluid p-2" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>


                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
                                
                            </div>
                        </div>

                    </div>
                </div>
            </div>
         </div>
    </div>
    <br />
    <br />
</asp:Content>
