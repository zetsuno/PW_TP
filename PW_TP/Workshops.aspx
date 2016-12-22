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
            <div class="modal" id="modalbox" runat="server" visible="false">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button class="close" aria-hidden="true" type="button" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Modal title</h4>
                        </div>
                        <div class="modal-body">
                            <p>One fine body…</p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-default" type="button" data-dismiss="modal">Close</button>
                            <button class="btn btn-primary" type="button">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
