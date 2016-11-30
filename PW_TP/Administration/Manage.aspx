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
                        <asp:SqlDataSource ID="SqlDSAdminTable" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AspNetUsers]"></asp:SqlDataSource>
                        <asp:GridView ID="GridViewTotal" runat="server" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false" DataKeyNames="Id" DataSourceID="SqlDSAdminTable" OnRowCommand="GridViewTotal_RowCommand">
                            <Columns>
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEdit" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="EditData"
                                            Text="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" />
                                        <asp:Button ID="ButtonDelete" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="DeleteData"
                                            Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" OnClientClick="return confirm('Are you sure you want to delete the user?')" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                                <asp:BoundField DataField="EmailConfirmed" HeaderText="EmailConfirmed" SortExpression="EmailConfirmed"></asp:BoundField>
                                <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash" SortExpression="PasswordHash"></asp:BoundField>
                                <asp:BoundField DataField="SecurityStamp" HeaderText="SecurityStamp" SortExpression="SecurityStamp"></asp:BoundField>
                                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber"></asp:BoundField>
                                <asp:BoundField DataField="PhoneNumberConfirmed" HeaderText="PhoneNumberConfirmed" SortExpression="PhoneNumberConfirmed"></asp:BoundField>
                                <asp:BoundField DataField="TwoFactorEnabled" HeaderText="TwoFactorEnabled" SortExpression="TwoFactorEnabled"></asp:BoundField>
                                <asp:BoundField DataField="LockoutEndDateUtc" HeaderText="LockoutEndDateUtc" SortExpression="LockoutEndDateUtc"></asp:BoundField>
                                <asp:BoundField DataField="LockoutEnabled" HeaderText="LockoutEnabled" SortExpression="LockoutEnabled"></asp:BoundField>
                                <asp:BoundField DataField="AccessFailedCount" HeaderText="AccessFailedCount" SortExpression="AccessFailedCount"></asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="WorkshopName" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopNIF" HeaderText="WorkshopNIF" SortExpression="WorkshopNIF"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwner" HeaderText="WorkshopOwner" SortExpression="WorkshopOwner"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwnerNIF" HeaderText="WorkshopOwnerNIF" SortExpression="WorkshopOwnerNIF"></asp:BoundField>
                                <asp:BoundField DataField="IsEnabled" HeaderText="IsEnabled" SortExpression="IsEnabled"></asp:BoundField>
                                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <br />
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
                                <asp:BoundField DataField="WorkshopNIF" HeaderText="WorkshopNIF" SortExpression="WorkshopNIF"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwner" HeaderText="WorkshopOwner" SortExpression="WorkshopOwner"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopOwnerNIF" HeaderText="WorkshopOwnerNIF" SortExpression="WorkshopOwnerNIF"></asp:BoundField>
                                <asp:CheckBoxField DataField="IsEnabled" HeaderText="IsEnabled" SortExpression="IsEnabled"></asp:CheckBoxField>
                                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Label ID="BadgeCountAll" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="BadgeCountToVerify" runat="server" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
