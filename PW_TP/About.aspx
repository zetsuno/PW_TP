<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PW_TP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><br />
   
        <div class="jumbotron">
            <h1>Como usar o nosso site</h1>
            <p>Crie uma conta e escolha o tipo de conta que pretende</p>
            <br />
            <asp:Image runat="server" ImageUrl="~/Assets/1.PNG" Width="40%" Height="40%"/>
            <br /><br /><br />
            <p>Inicie sessão com os seus dados</p>
            <br />
            <asp:Image runat="server" ImageUrl="~/Assets/2.PNG" Width="40%" Height="40%"/>
            <br /><br /><br />
            <p>Se entrou como cliente vai-lhe aparecer esta janela</p>
            <br />
            <asp:Image runat="server" ImageUrl="~/Assets/3.PNG" Width="80%" Height="80%"/>
            <p style="color:darkgray;">Aqui pode fazer um pedido de reparação a uma ou varias oficinas a sua escolha, rever os seus pedidos anteriores, escolher a melhor oferta e dar feedback.</p>
            <br /><br /><br />
            <p>Se entrou como oficina vai-lhe aparecer esta janela</p>
            <br />
            <asp:Image runat="server" ImageUrl="~/Assets/4.PNG" Width="80%" Height="80%"/>
            <p style="color:darkgray;">Aqui pode ver os pedidos ativos, os que estão pendentes, enviar orçamentos e ver a avaliação dos seus serviços e os seus clientes.</p>
            <br /><br /><br />
            <p>Se entrou como cliente que também é oficina vai-lhe aparecer esta janela</p>
            <br />
            <asp:Image runat="server" ImageUrl="~/Assets/5.PNG" Width="20%" Height="20%"/>
            <p style="color:darkgray;">Aqui pode ver tudo o que um cliente e uma oficina pode ver.</p>
        </div>
</asp:Content>
