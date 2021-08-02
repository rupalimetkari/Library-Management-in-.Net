<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="e_LibraryManagement.userlogin" %>
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
                                    <img src="img/lib8.jpg" style="width:150px;" />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                                     <asp:TextBox ID ="txtMemberId" runat="server" CssClass="form-control" placeholder="Enter Member ID"></asp:TextBox>
                                   </div>

                                    <div class="form-group">
                                     <asp:TextBox ID ="txtMemberPassword" runat="server" CssClass="form-control" placeholder="Enter Member Password" TextMode="Password"></asp:TextBox>
                                   </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnlogin" runat="server" Text="Login" class="btn btn-success btn-block" OnClick="btnlogin_Click"/>

                                   </div>
                                      <div class="form-group">
                                         <a href="SignUp.aspx"><asp:Button ID="btnSignUp" runat="server" Text="Sign Up"  class="btn btn-info btn-block" OnClick="btnSignUp_Click"/></a>

                                   </div>
                                </center>
                            </div>
                        </div>

                    </div>

                </div>

                <a href="home.aspx"><< Back to Home</a>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
