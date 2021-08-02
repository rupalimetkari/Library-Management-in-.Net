<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="e_LibraryManagement.ViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class =" container">
        <div class="row">

            <div class="col-sm-12">
                <center>
                    <h3>View All Books</h3>
                </center>

                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel ID="Panel1" runat="server" role="alert" class="alert alert-success" Visible="false">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                        
                        </div>
                </div>
                <br />
                 
                <div class="row">
                   

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
    </div>

</asp:Content>
