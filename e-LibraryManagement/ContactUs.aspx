<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="e_LibraryManagement.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/lib13.jpg" style="width:150px;" />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Contact Us</h4>
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
                                <label>Full Name :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtFullName" runat="server" CssClass="form-control"
                                         placeholder="Enter Full Name"></asp:TextBox>
                                   </div>
                               
                            </div>

                             <div class="col-md-6">
                                <label>Address :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtAddress" runat="server" CssClass="form-control"
                                         placeholder="Enter Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                   </div>
                               
                            </div>
                             
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>Contact No :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtMobileNo" runat="server" CssClass="form-control"
                                         placeholder="Enter Mobile No"  TextMode="Number"></asp:TextBox>
                                   </div>
                               
                            </div>
                              <div class="col-md-6">
                                  <label>Email ID :</label>
                                  <div class="form-group">
                                     <asp:TextBox ID ="txtEmailID" runat="server" CssClass="form-control" 
                                         placeholder="Enter EmailID" TextMode="Email"></asp:TextBox>
                                   </div>
                               
                            </div>
                        </div>
                       
                        <div class="row">
                            <div class="col">
                                <label>Message :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtMessage" runat="server" CssClass="form-control"
                                         TextMode="MultiLine" Rows="2"></asp:TextBox>
                                   </div>
                               
                            </div>
                              
                        </div>

                      
                       


                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="btnSend" runat="server"
                                        Text="Send" class="btn btn-success btn-block" OnClick="btnSend_Click"/>
                                </div>
                                
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
