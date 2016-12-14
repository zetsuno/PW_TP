<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Workshop.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="WorkshopUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                
                <ul class="nav nav-tabs" id="mytabs" role="tablist">
                    <li class="active"><a aria-expanded="true" role="tab"  href="#tab1" data-toggle="tab">Comissões Ativas   <span class="badge"><%= LabelComissoesAtivas.Text %></span></a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab2" data-toggle="tab">Comissões Pendentes     <span class="badge"><%= LabelComissoesPendentes.Text %></span></a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab3" data-toggle="tab">Histórico de Comissões</a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab4" data-toggle="tab">Clientes</a></li>
                    
                </ul>
                <br />
                <div class="tab-content"  id="myTabContent">
                    <div class="tab-pane fade active in" id="tab1">
                        <h3>Comissões Ativas - <%= LabelComissoesAtivas.Text%></h3><br />
                         <asp:GridView ID="ActiveComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                              <Columns>
                                  <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="BtnConcludeComission" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="ConcludeComission"
                                            Text="Concluir" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true"  OnClientClick="return confirm('De certeza que quer concluir a comissão?')"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de Criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                <asp:BoundField DataField="DisplayName" HeaderText="Nome de Utilizador" SortExpression="DisplayName"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                            </Columns>
                         </asp:GridView>
                    </div>
                    <div class="tab-pane fade" id="tab2">
                        <h3>Comissões Pendentes - <%= LabelComissoesPendentes.Text%></h3><br />
                         <asp:GridView ID="PendingComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                             <Columns>
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="BtnAcceptComission" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="AcceptComission"
                                            Text="Aceitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true"  OnClientClick="return confirm('De certeza que quer aceitar a comissão?')"/>
                                        <asp:Button ID="BtnRejectComission" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="RejectComission"
                                            Text="Rejeitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" OnClientClick="return confirm('De certeza que quer rejeitar a comissão?')" Visible="true" />  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de Criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                <asp:BoundField DataField="DisplayName" HeaderText="Nome de Utilizador" SortExpression="DisplayName"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                            </Columns>
                         </asp:GridView>
                    </div>
                    <div class="tab-pane fade" id="tab3">
                     <h3>Histórico de Comissões</h3><br />
                         <asp:GridView ID="HistoryOfComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false">
                             <Columns>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de Criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                <asp:BoundField DataField="DisplayName" HeaderText="Nome de Utilizador" SortExpression="DisplayName"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                            </Columns>
                         </asp:GridView>
                    </div>
                    <div class="tab-pane fade" id="tab4">
                     <h3>Clientes</h3><br />
                         <asp:GridView ID="Clientes" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false">
                             <Columns>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                                <asp:BoundField DataField="DisplayName" HeaderText="Nome de Utilizador" SortExpression="DisplayName"></asp:BoundField>
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Número de Telemóvel" SortExpression="PhoneNumber"></asp:BoundField>
                            </Columns>
                         </asp:GridView>
                    </div>
                </div>
                <asp:Label ID="LabelComissoesAtivas" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="LabelComissoesPendentes" runat="server" Visible="false"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
