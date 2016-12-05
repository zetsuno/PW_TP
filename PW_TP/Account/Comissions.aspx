<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Account.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="EditTablesUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <ul class="nav nav-tabs">
                    <li class="active"><a aria-expanded="true" href="#CreateComission" data-toggle="tab">Criar Comissão   </a></li>
                    <li><a aria-expanded="true" href="#SeeComissions" data-toggle="tab">Comissões Ativas   <span class="badge"><%= BadgeCountActiveComissions.Text%></span></a></li>
                </ul>
                <br />
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active in" id="CreateComission">
                        
                        
                    </div>
                    <div class="tab-pane fade active in" id="SeeComissions">
                        
                        
                    </div>
                </div>
                <asp:Label ID="BadgeCountActiveComissions" runat="server" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
