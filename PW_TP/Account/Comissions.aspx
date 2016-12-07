<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Account.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
     <script src="../Scripts/bootstrap.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="EditTablesUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <ul class="nav nav-tabs" id="mytabs" role="tablist">
                    <li class="active"><a aria-expanded="true" role="tab" href="#HelpCreatingComission" data-toggle="tab">Informação   </a></li>
                    <li><a aria-expanded="true" role="tab" href="#CreateComission" data-toggle="tab">Criar Comissão</a></li>
                    <li><a aria-expanded="true" role="tab" href="#SeeComissions" data-toggle="tab">Comissões Ativas   <span class="badge"><%= BadgeCountActiveComissions.Text%></span></a></li>
                </ul>
                <br />
                <div class="tab-content"  id="myTabContent">
                    <div class="tab-pane fade active in" id="HelpCreatingComission">
                        <div class="jumbotron">
                            <h1>Crie uma Comissão</h1>
                            <br />
                            <p>Caso tenha problemas técnicos com a sua bicicleta, requisite ajuda de uma das várias oficinas disponíveis no website, localizadas por todo o país.</p>
                            <br />
                            <button type="button" class="btn btn-primary btn-lg" id="BtnRedirect">Criar Comissão</button>
                            <script>
                                $(function () {
                                    $('#BtnRedirect').click(function (e) {
                                        //alert("test");
                                        e.preventDefault();
                                        $('#mytabs li:eq(1) a').tab('show');
                                        $('#mytabs li:eq(1) a').trigger('click');
                                    })
                                })
                            </script>
                        </div>     
                         </div>
                    <div class="tab-pane fade" id="CreateComission">
                         <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" BorderStyle="Dashed" BorderWidth="2px"/>
                         <br /><br />
                        <div class="form-horizontal">
                            <h4>Crie uma Comissão</h4>
                            <hr />
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="ErrorMessage" />
                            </p>
                            <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" BorderStyle="Dashed" BorderWidth="2px" />
                            <br />
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbModelo" CssClass="col-md-2 control-label">Modelo</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="TbModelo" CssClass="form-control" />
                                    <asp:RegularExpressionValidator ID="RegExModelo" runat="server" CssClass="text-danger"  Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Modelo Inválido" ControlToValidate="TbModelo"  ValidationExpression="^[a-zA-Z0-9.-]*$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Tipo</asp:Label>
                                <div class="col-md-10">
                                    <select class="form-control" id="DdlTipo" style="width: 280px">
                                        <option value="Urbana" selected="selected">Urbana</option>
                                        <option value="Dobravel">Dobrável</option>
                                        <option value="Montanha">Montanha</option>
                                        <option value="Estrada">Estrada</option>
                                        <option value="BMX">BMX</option>
                                        <option value="Infantil">Infantil</option>
                                    </select>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="DdlOficinas" CssClass="col-md-2 control-label">Oficina</asp:Label>
                                <div class="col-md-10">
                                    <asp:SqlDataSource ID="SqlDataSourceDdlOficinas" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [WorkshopName] FROM [AspNetUsers] WHERE ([WorkshopName] IS NOT NULL)"></asp:SqlDataSource>
                                    <asp:DropDownList ID="DdlOficinas" runat="server" CssClass="form-control" DataSourceID="SqlDataSourceDdlOficinas" DataTextField="WorkshopName" DataValueField="WorkshopName"></asp:DropDownList>
                                </div>
                            </div>


                        </div>
                    <div class="tab-pane fade active in" id="SeeComissions">
                        
                        
                    </div>
                        </div>
                        
                           
                    
                    
                </div>
                <asp:Label ID="BadgeCountActiveComissions" runat="server" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>



