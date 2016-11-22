<%@ Page Title="Marter Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="PW_TP.Administration.Manage" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br /><br />
        <ul class="nav nav-pills">
        <li class="active"><a href="#">Total<span class="badge">42</span></a></li>
        <li><a href="#">Requer Validação<span class="badge">3</span></a></li>
        </ul>
        <br />
        <asp:SqlDataSource ID="SqlDSAdminTable" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDSAdminTable" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" AllowSorting="True">
        </asp:GridView>
        <br />
        <asp:Button ID="BtEditar" runat="server" Text="Editar" CssClass="btn btn-success"/>
    </div>
</asp:Content>
