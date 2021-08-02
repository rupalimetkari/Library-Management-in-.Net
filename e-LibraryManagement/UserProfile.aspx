<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="e_LibraryManagement.UserProfile" %>
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
                                    <img src="img/lib11.png" style="width:100px;" />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span >Account Status - </span>
                                    <asp:Label ID ="lblProfile" runat="server" CssClass="badge badge-pill badge-info" Text="Your Status"></asp:Label>
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
                                  <label>Date of Birth :</label>
                                  <div class="form-group">
                                     <asp:TextBox ID ="txtDateOfBirth" runat="server" CssClass="form-control" 
                                          TextMode="Date"></asp:TextBox>
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
                                         Plplaceholder="Enter EmailID" TextMode="Email"></asp:TextBox>
                                   </div>
                               
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State :</label>
                                 <div class="form-group">
                                     <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" >
                                         <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                         <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
        <asp:ListItem>Andhra Pradesh</asp:ListItem>
        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
        <asp:ListItem>Assam</asp:ListItem>
        <asp:ListItem>Bihar</asp:ListItem>
        <asp:ListItem>Chandigarh</asp:ListItem>
        <asp:ListItem>Chattisgarh</asp:ListItem>
        <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
        <asp:ListItem>Daman and Diu</asp:ListItem>
        <asp:ListItem>Delhi</asp:ListItem>
        <asp:ListItem>Goa</asp:ListItem>
        <asp:ListItem>Gujarat</asp:ListItem>
        <asp:ListItem>Haryana</asp:ListItem>
        <asp:ListItem>Himachal Pradesh</asp:ListItem>
        <asp:ListItem>Jammu and Kashmir</asp:ListItem>
        <asp:ListItem>Jharkhand</asp:ListItem>
        <asp:ListItem>Karnataka</asp:ListItem>
        <asp:ListItem>Kerala</asp:ListItem>
        <asp:ListItem>Lakshadweep</asp:ListItem>
        <asp:ListItem>Madhya Pradesh</asp:ListItem>
        <asp:ListItem>Maharashtra</asp:ListItem>
        <asp:ListItem>Manipur</asp:ListItem>
        <asp:ListItem>Meghalaya</asp:ListItem>
        <asp:ListItem>Mizoram</asp:ListItem>
        <asp:ListItem>Nagaland</asp:ListItem>
        <asp:ListItem>Orissa</asp:ListItem>
        <asp:ListItem>Pondicherry</asp:ListItem>
        <asp:ListItem>Punjab</asp:ListItem>
        <asp:ListItem>Rajasthan</asp:ListItem>
        <asp:ListItem>Sikkim</asp:ListItem>
        <asp:ListItem>Tamil Nadu</asp:ListItem>
        <asp:ListItem>Tripura</asp:ListItem>
        <asp:ListItem>Uttarakhand</asp:ListItem>
        <asp:ListItem>Uttaranchal</asp:ListItem>
        <asp:ListItem>Uttar Pradesh</asp:ListItem>
        <asp:ListItem>West Bengal</asp:ListItem>
                                     </asp:DropDownList>
                                   </div>
                               
                            </div>
                              <div class="col-md-4">
                                  <label>City :</label>
                                  <div class="form-group">
                                     <asp:TextBox ID ="txtCity" runat="server" CssClass="form-control">
                                          </asp:TextBox>
                                   </div>
                               
                            </div>

                             <div class="col-md-4">
                                  <label>PinCode :</label>
                                  <div class="form-group">
                                     <asp:TextBox ID ="txtPinCode" runat="server" CssClass="form-control" 
                                         Plplaceholder="Enter PinCode" TextMode="Number"></asp:TextBox>
                                   </div>
                               
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Address :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtAddress" runat="server" CssClass="form-control"
                                         placeholder="Enter Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                   </div>
                               
                            </div>
                              
                        </div>

                        <div class="row">
                            
                            <div class="col">
                               <center> <span class ="badge badge-pill badge-info">Login Credentials</span></center>
                            </div>
                                
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Member ID :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID ="txtMemberID" runat="server" CssClass="form-control" placeholder="Member ID" 
                                         ReadOnly ="true"></asp:TextBox>
                                   </div>
                               
                            </div>

                            <div class="col-md-4">
                                  <label> Old Password :</label>
                                  <div class="form-group">
                                      <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control"
                                           ReadOnly="true"></asp:TextBox>
                                   </div>
                               
                            </div>

                              <div class="col-md-4">
                                  <label> New Password :</label>
                                  <div class="form-group">
                                     <asp:TextBox ID ="txtPassword" runat="server" CssClass="form-control" 
                                          TextMode="Password"></asp:TextBox>
                                   </div>
                               
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                <div class="form-group">
                                    <asp:Button ID="btnUpdate" runat="server"
                                        Text="Update" class="btn btn-primary btn-block" OnClick="btnUpdate_Click" />
                                </div>
                                </center>
                            </div>
                        </div>

                    </div>

                </div>

                <a href="home.aspx"><< Back to Home</a>
            </div>

            <div class="col-lg-7">
               
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/bookLogo.png" style="width:100px;" />
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    
                                    <asp:Label ID ="lblBookInfo" runat="server" CssClass="badge badge-pill badge-success" 
                                        Text="Your Books Info"></asp:Label>
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

                                <hr />
                            </div>
                        </div>

                         
                         <div class="row">
                            <div class="col">
                                <asp:GridView ID="GdUserIssuedBooks"  runat="server"
                                    CssClass="table table-striped table-bordered" OnRowDataBound="GdUserIssuedBooks_RowDataBound"></asp:GridView>
                                
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
