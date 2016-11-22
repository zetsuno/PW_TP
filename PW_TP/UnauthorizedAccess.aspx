<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="PW_TP.UnauthorizedAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="alert alert-dismissible alert-danger">
        <button class="close" type="button" data-dismiss="Acesso não autorizado">&times;</button>
        <h3>Oops!</h3><br />Parece que aconteceu algo inesperado, ou a página que tentou aceder não existe, ou não possui permissões para a visitar!
    </div>
</asp:Content>
