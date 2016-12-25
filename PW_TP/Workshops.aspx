<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workshops.aspx.cs" Inherits="PW_TP.Workshops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/star-rating.css" media="all" rel="stylesheet" type="text/css" />
    <script src="../Scripts/star-rating.js" type="text/javascript"></script>
    <asp:UpdatePanel runat="server" ID="UPWorkshopView" UpdateMode="Conditional">
        <ContentTemplate>
            <br /><br /><br />
            <div class="jumbotron">
                
                <h1>Conheça as nossas oficinas</h1>
                <br /><br /><br /><br />
                <p>Selecione a sua região:</p>
                
                <p>
                    <asp:DropDownList ID="DdlRegiao" runat="server" CssClass="form-control" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="DdlRegiao_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                        <asp:ListItem Value="Porto e Norte">Porto e Norte</asp:ListItem>
                        <asp:ListItem Value="Coimbra e Centro">Coimbra e Centro</asp:ListItem>
                        <asp:ListItem Value="Lisboa">Lisboa</asp:ListItem>
                        <asp:ListItem Value="Alentejo">Alentejo</asp:ListItem>
                        <asp:ListItem Value="Algarve">Algarve</asp:ListItem>
                        <asp:ListItem Value="Açores">Açores</asp:ListItem>
                        <asp:ListItem Value="Madeira">Madeira</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>         
                    <asp:DropDownList ID="DdlOficinas" runat="server" CssClass="form-control" AppendDataBoundItems="false" Width="280px" AutoPostBack="True" Enabled="false">
                     
                    </asp:DropDownList>
                </p>   

            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
