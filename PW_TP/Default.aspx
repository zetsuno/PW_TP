<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PW_TP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background-color:white">
        <!--
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        -->
        <img src="Assets/bikefix.jpg" style="Width:100%; Height:100%; padding:4%" >
        <!--
        <asp:Image ImageUrl="~/Assets/bikefix.jpg" runat="server" Width="90%" Height="90%"/>
        -->
    
    <div class="row" style="padding:4%;">
        <h2>
             Precisa de arranjar a sua bicicleta mas não sabe onde?
        </h2>
        <div class="col-md-8">
            <h3>
                Conheça as nossas oficinas e escolha melhor para si.
            </h3>
            
        </div>
        <div class="col-md-4" >
            <asp:ImageButton ImageUrl="~/Assets/peca_orcamento.png" OnClick="Orcament_Click" runat="server" Width="70%" Height="70%" ImageAlign="Right"/>
        </div>
    </div>
        </div>
    <!--
    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    -->

</asp:Content>
