<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="e_LibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/lib9.jpg" style="width:150px;" />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
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
                                <center>
                                   <div class="form-group">
                                     <asp:TextBox ID ="txtAdminId" runat="server" CssClass="form-control" placeholder="Enter Admin ID"></asp:TextBox>
                                   </div>

                                    <div class="form-group">
                                     <asp:TextBox ID ="txtAdminPassword" runat="server" CssClass="form-control" placeholder="Enter Admin Password" TextMode="Password"></asp:TextBox>
                                   </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnlogin" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="btnlogin_Click"/>

                                   </div>
                                      
                                </center>
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
