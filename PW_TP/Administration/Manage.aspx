<%@ Page Title="Manage the Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="PW_TP.Administration.Manage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="EditTablesUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <ul class="nav nav-tabs">
                    <li class="active"><a aria-expanded="true" href="#total" data-toggle="tab">Total   <span class="badge"><%= BadgeCountAll.Text%></span></a></li>
                    <li><a aria-expanded="true" href="#toverify" data-toggle="tab">To Verify   <span class="badge"><%= BadgeCountToVerify.Text%></span></a></li>    
                </ul>
                <br />
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active in" id="total">
                        <br />
                        <h3>Users - <%=BadgeCountAll.Text %></h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDSAdminTable" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AspNetUsers]"></asp:SqlDataSource>
                        <asp:GridView ID="GridViewTotal" runat="server" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false" DataKeyNames="Id" DataSourceID="SqlDSAdminTable" OnRowCommand="GridViewTotal_RowCommand" OnRowDataBound="GridViewTotal_RowDataBound" OnRowUpdating="GridViewTotal_RowUpdating" >
                            <Columns>
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEdit" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="EditData"
                                            Text="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true" />
                                        <asp:Button ID="ButtonDelete" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="DeleteData"
                                            Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" OnClientClick="return confirm('Are you sure you want to delete the user?')" Visible="true" />
                                         <asp:Button ID="ButtonConfirmEdit" runat="server" CssClass="btn btn-primary" CausesValidation="false" CommandName="UpdateData"
                                            Text="Confirm" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="false" OnClientClick="return confirm('Are you sure you want to update the user data?')" />
                                         <asp:Button ID="ButtonCancelEdit" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="CancelEdit"
                                            Text="Cancel" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px"  Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" ></asp:BoundField> 
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmail" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EmailConfirmed" HeaderText="EmailConfirmed" SortExpression="EmailConfirmed" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEmailConfirmed" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash" SortExpression="PasswordHash" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPasswordHash" CssClass="advancedSearchTextBox" runat="server" Text='<%# Bind("PasswordHash") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SecurityStamp" HeaderText="SecurityStamp"  SortExpression="SecurityStamp" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSecurityStamp" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("SecurityStamp") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPhoneNumber" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PhoneNumberConfirmed" HeaderText="PhoneNumberConfirmed" SortExpression="PhoneNumberConfirmed" ReadOnly="true"></asp:BoundField>
                               <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPhoneNumberConfirmed" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TwoFactorEnabled" HeaderText="TwoFactorEnabled" SortExpression="TwoFactorEnabled" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTwoFactorEnabled" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LockoutEndDateUtc" HeaderText="LockoutEndDateUtc" SortExpression="LockoutEndDateUtc" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLockoutEndDateUtc" CssClass="advancedSearchTextBox"  runat="server" Text='01/01/1990 00:00:00'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LockoutEnabled" HeaderText="LockoutEnabled" SortExpression="LockoutEnabled" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlLockoutEnabled" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AccessFailedCount" HeaderText="AccessFailedCount" SortExpression="AccessFailedCount" ReadOnly="true"></asp:BoundField>
                                  <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAccessFailedCount" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("AccessFailedCount") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUserName" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="WorkshopName" SortExpression="WorkshopName" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopName" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="WorkshopPhone" HeaderText="WorkshopPhone" SortExpression="WorkshopPhone" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopPhone" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopPhone") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="WorkshopOwner" HeaderText="WorkshopOwner" SortExpression="WorkshopOwner" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopOwner" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopOwner") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="WorkshopOwnerNIF" HeaderText="WorkshopOwnerNIF" SortExpression="WorkshopOwnerNIF" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopOwnerNIF" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopOwnerNIF") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               <asp:BoundField DataField="WorkshopAddress" HeaderText="WorkshopAddress" SortExpression="WorkshopAddress" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopAddress" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopAddress") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               <asp:BoundField DataField="WorkshopRegion" HeaderText="WorkshopRegion" SortExpression="WorkshopRegion" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtWorkshopRegion" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopRegion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IsEnabled" HeaderText="IsEnabled" SortExpression="IsEnabled" ReadOnly="true"></asp:BoundField>
                                 <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlIsEnabled" runat="server">
                                            <asp:ListItem Selected="True" Value="1">True</asp:ListItem>
                                            <asp:ListItem Value="0">False</asp:ListItem> 
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDisplayName" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("DisplayName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>                        
                            </Columns>
                        </asp:GridView>
                        <br /> <br /> <br />
                        <h3>Comissions - <%= BadgeCountComissions.Text %> </h3>
                        <br />
                        <asp:SqlDataSource ID="SqlDSCommissions" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [Comissions]"></asp:SqlDataSource>
                        <asp:GridView ID="GridViewComissions" runat="server" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false" OnRowCommand="GridViewComissions_RowCommand" OnRowDataBound="GridViewComissions_RowDataBound" OnRowUpdating="GridViewComissions_RowUpdating" DataSourceID="SqlDSCommissions" OnRowUpdated="GridViewComissions_RowUpdated">
                             <Columns>
                            <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEdit" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="EditData"
                                            Text="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true" />
                                        <asp:Button ID="ButtonDelete" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="DeleteData"
                                            Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" OnClientClick="return confirm('Are you sure you want to delete the commission?')" Visible="true" />
                                         <asp:Button ID="ButtonConfirmEdit" runat="server" CssClass="btn btn-primary" CausesValidation="false" CommandName="UpdateData"
                                            Text="Confirm" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="false" OnClientClick="return confirm('Are you sure you want to update the commission data?')" />
                                         <asp:Button ID="ButtonCancelEdit" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="CancelEdit"
                                            Text="Cancel" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px"  Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                                    <asp:BoundField DataField="ClientId" HeaderText="ClientId" ReadOnly="True" SortExpression="ClientId"></asp:BoundField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtClientId" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("ClientId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="WorkshopId" HeaderText="WorkshopId" ReadOnly="True" SortExpression="WorkshopId"></asp:BoundField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtWorkshopId" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("WorkshopId") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Concluded" HeaderText="Concluded" ReadOnly="True" SortExpression="Concluded"></asp:BoundField>
                                         <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlConcluded" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True" SortExpression="CreationDate"></asp:BoundField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtCreationDate" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("CreationDate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="BicycleModel" HeaderText="BicycleModel" ReadOnly="True" SortExpression="BicycleModel"></asp:BoundField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtBicycleModel" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("BicycleModel") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="BicycleType" HeaderText="BicycleType" ReadOnly="True" SortExpression="BicycleType"></asp:BoundField>
                                         <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtBicycleType" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("BicycleType") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="YearOfAquisition" HeaderText="YearOfAquisition" ReadOnly="True" SortExpression="YearOfAquisition"></asp:BoundField>
                                         <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtYearOfAquisition" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("YearOfAquisition") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Details" HeaderText="Details" ReadOnly="True" SortExpression="Details"></asp:BoundField>
                                  <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtDetails" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("Details") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Accepted" HeaderText="Accepted" ReadOnly="True" SortExpression="Accepted"></asp:BoundField>
                                  <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlAccepted" runat="server">
                                            <asp:ListItem Selected="True" Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField DataField="ComissionNo" HeaderText="ComissionNo" ReadOnly="True" SortExpression="ComissionNo"></asp:BoundField>
                                  <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtComissionNo" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("ComissionNo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Rating" HeaderText="Rating" ReadOnly="True" SortExpression="Rating"></asp:BoundField>
                                  <asp:TemplateField>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="txtRating" CssClass="advancedSearchTextBox"  runat="server" Text='<%# Bind("Rating") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                  </Columns>
                             </asp:GridView>
                         </div>
                    <div class="tab-pane fade" id="toverify">
                        <asp:SqlDataSource ID="SqlDSToBeVerified" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AspNetUsers] WHERE ([IsEnabled] = @IsEnabled)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="FALSE" Name="IsEnabled" Type="Boolean"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridViewToValidate" runat="server" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDSToBeVerified" DataKeyNames="Id" OnRowCommand="GridViewToValidate_RowCommand">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonActivateAcc" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="ActivateAcc"
                                            Text="Ativate Account" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" OnClientClick="return confirm('Are you sure you want to activate the user?'); " />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="true"></asp:BoundField>
                                <asp:CheckBoxField DataField="EmailConfirmed" HeaderText="EmailConfirmed" SortExpression="EmailConfirmed"></asp:CheckBoxField>
                                <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash" SortExpression="PasswordHash"></asp:BoundField>
                                <asp:BoundField DataField="SecurityStamp" HeaderText="SecurityStamp" SortExpression="SecurityStamp"></asp:BoundField>
                                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber"></asp:BoundField>
                                <asp:CheckBoxField DataField="PhoneNumberConfirmed" HeaderText="PhoneNumberConfirmed" SortExpression="PhoneNumberConfirmed"></asp:CheckBoxField>
                                <asp:CheckBoxField DataField="TwoFactorEnabled" HeaderText="TwoFactorEnabled" SortExpression="TwoFactorEnabled"></asp:CheckBoxField>
                                <asp:BoundField DataField="LockoutEndDateUtc" HeaderText="LockoutEndDateUtc" SortExpression="LockoutEndDateUtc"></asp:BoundField>
                                <asp:CheckBoxField DataField="LockoutEnabled" HeaderText="LockoutEnabled" SortExpression="LockoutEnabled"></asp:CheckBoxField>
                                <asp:BoundField DataField="AccessFailedCount" HeaderText="AccessFailedCount" SortExpression="AccessFailedCount"></asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="WorkshopName" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopPhone" HeaderText="WorkshopPhone" SortExpression="WorkshopPhone"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwner" HeaderText="WorkshopOwner" SortExpression="WorkshopOwner"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwnerNIF" HeaderText="WorkshopOwnerNIF" SortExpression="WorkshopOwnerNIF"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopAddress" HeaderText="WorkshopAddress" SortExpression="WorkshopAddress" ReadOnly="true"></asp:BoundField>
                                <asp:CheckBoxField DataField="IsEnabled" HeaderText="IsEnabled" SortExpression="IsEnabled"></asp:CheckBoxField>
                                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>        
                </div>
                <asp:Label ID="BadgeCountAll" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="BadgeCountToVerify" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="BadgeCountComissions" runat="server" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
