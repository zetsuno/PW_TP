<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workshops.aspx.cs" Inherits="PW_TP.Workshops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/star-rating.css" media="all" rel="stylesheet" type="text/css" />
    <script src="../Scripts/star-rating.js" type="text/javascript"></script>
    <asp:UpdatePanel runat="server" ID="UPWorkshopView" UpdateMode="Conditional">
        <ContentTemplate>
    <h1>INFO</h1>
    <br /><br /><br /><br /><br />
    <h3>Oficinas</h3>
    <asp:SqlDataSource ID="SqlDSWorkshops" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="GetWorkshopNames" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <br /><br />
            <asp:DropDownList ID="ddlOficinas" runat="server" DataSourceID="SqlDSWorkshops" DataTextField="WorkshopName" DataValueField="WorkshopName" OnSelectedIndexChanged="ddlOficinas_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
             <asp:ListItem Value="0" Selected="True">-- Selecione --</asp:ListItem>
            </asp:DropDownList><br />       
            <asp:Label runat="server" ID="labelstar" Text=""></asp:Label>
            <input runat="server" id="starrating" name="input-2" class="rating rating-loading" data-min="0" data-max="5" data-step="0.1" readonly="readonly">
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
