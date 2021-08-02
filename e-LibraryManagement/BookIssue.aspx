<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="BookIssue.aspx.cs" Inherits="e_LibraryManagement.BookIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                       
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Books Issuing</h4>
                                    
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/lib14.png" style="width:100px;" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">

                                <hr />
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <label>Member ID :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtMemberId" runat="server" CssClass="form-control"
                                        placeholder="Member ID"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <label>Book ID :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBookId" runat="server" CssClass="form-control"
                                            placeholder="Book Id"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-dark" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                         <div class="row">

                             <div class="col-md-6">
                                 <label>Member Name :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control"
                                      ReadOnly="true" placeholder="Member Name"></asp:TextBox>
                                 </div>

                             </div>
                            <div class="col-md-6">
                                <label>Book Name :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control"
                                        ReadOnly="true" placeholder="Book Name"></asp:TextBox>
                                 </div>
                            </div>
                        </div>

                        <div class="row">

                             <div class="col-md-6">
                                 <label>Start Date :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"
                                      TextMode="Date" placeholder="Start Date"></asp:TextBox>
                                 </div>

                             </div>
                            <div class="col-md-6">
                                <label>End Date :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"
                                        TextMode="Date" placeholder="End Date"></asp:TextBox>
                                 </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="btnIssue" runat="server" Text="Issue" 
                                    CssClass="btn btn-lg btn-block btn-primary" OnClick="btnIssue_Click"/>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnReturn" runat="server" Text="Return" 
                                    CssClass="btn btn-lg btn-block btn-success" OnClick="btnReturn_Click"/>
                            </div>
                           
                        </div>

                    </div>

                    </div>
                </div>
           

             <div class="col-md-7">
                 <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                    
                                </center>
                            </div>
                        </div>

                         
                        <div class="row">
                            <div class="col">

                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryConnectionString %>" SelectCommand="SELECT * FROM [book_issue]"></asp:SqlDataSource>

                            <div class="col">
                                <asp:GridView ID="GdBookIssued"  runat="server" OnRowDataBound="GdBookIssued_RowDataBound" 
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
