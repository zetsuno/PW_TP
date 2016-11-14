<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidationRequired.aspx.cs" Inherits="PW_TP.Account.ValidationRequired" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><br />

  <div class="alert alert-dismissible alert-warning">
    <button class="close" type="button" data-dismiss="alert">&times;</button>
    <h4>Informação</h4>
  <p>Conta do tipo Oficina criada com sucesso, no entanto, antes de poder usar o website, este tipo de conta precisará da verificação de credenciais por parte de um administrador. <br /> Caso este processo esteje a demorar mais que 24h, por favor contacte a nossa administração em <a class="alert-link" href="#">admin@(Dominio)</a>.</p>
</div>
</asp:Content>
