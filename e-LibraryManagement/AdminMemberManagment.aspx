<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagment.aspx.cs" Inherits="e_LibraryManagement.AdminMemberManagment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
       $(document).ready( function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       } );
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
                                    <h4>Member Details</h4>
                                    
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/lib15.jpg" style="width:100px;" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                <hr />
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-3">
                                <label>Member ID :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtMemberId" runat="server" CssClass="form-control"
                                            placeholder="Id"></asp:TextBox>
                                        <asp:LinkButton ID="lnkGo" runat="server" CssClass="btn btn-primary" OnClick="lnkGo_Click">
                                  <i class ="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name :</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"
                                       ReadOnly="true"  placeholder="Full Name"></asp:TextBox>
                                </div>

                            </div>
                           
                            <div class="col-md-5">
                                <label>Account Status :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAccountStatus" runat="server" CssClass="form-control m-1"
                                            ReadOnly="true"></asp:TextBox>

                                        <asp:LinkButton ID="lnkA" runat="server" CssClass="btn btn-success mr-1" OnClick="lnkA_Click">
                                  <i class ="fas fa-check-circle"></i></asp:LinkButton>

                                        <asp:LinkButton ID="lnkP" runat="server" CssClass="btn btn-warning mr-1" OnClick="lnkP_Click">
                                  <i class ="far fa-pause-circle"></i></asp:LinkButton>

                                        <asp:LinkButton ID="lnkD" runat="server" CssClass="btn btn-danger mr-1" OnClick="lnkD_Click">
                                  <i class ="fas fa-times-circle"></i></asp:LinkButton>


                                    </div>
                                </div>

                            </div>
                        </div>


                         <div class="row">

                            <div class="col-md-4">
                                 <label>DOB :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control"
                                      ReadOnly="true" placeholder="DOB"></asp:TextBox>
                                 </div>

                             </div>
                             <div class="col-md-4">
                                 <label>Contact No :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"
                                         ReadOnly="true" placeholder="Contact No"></asp:TextBox>
                                 </div>
                             </div>
                             <div class="col-md-4">
                                 <label>Email ID :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                         ReadOnly="true" placeholder="Email ID"></asp:TextBox>
                                 </div>
                             </div>

                        </div>

                         

                        <div class="row">

                             <div class="col-md-4">
                                 <label>State:</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtState" runat="server" CssClass="form-control"
                                      ReadOnly="true" placeholder="State"></asp:TextBox>
                                 </div>

                             </div>
                            <div class="col-md-4">
                                <label>City :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"
                                       ReadOnly="true" placeholder="City"></asp:TextBox>
                                 </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control"
                                        ReadOnly="true"  placeholder="Pin Code"></asp:TextBox>
                                 </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Full Postal Address :</label>
                                 <div class="form-group">
                                     <asp:TextBox ID="txtFullAddress" runat="server" CssClass="form-control"
                                    ReadOnly ="true" placeholder="Address"  TextMode="MultiLine" Rows="2"></asp:TextBox>
                                 </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="btndeletedData" runat="server" Text="Delete User Permanently" 
                                    CssClass="btn btn-lg btn-block btn-danger" OnClick="btndeletedData_Click" />
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
                                    <h4>Member List</h4>
                                    
                                </center>
                            </div>
                        </div>

                         
                        <div class="row">
                            <div class="col">

                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryConnectionString %>" SelectCommand="SELECT * FROM [member_master]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GdMemberList"  runat="server" 
                                    CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="memberid" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="memberid" HeaderText=" ID" SortExpression="memberid" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
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
