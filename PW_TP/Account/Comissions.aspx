<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Account.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#BtnRedirect').click(function (e) {
                //alert("test");
                e.preventDefault();
                $('#mytabs li:eq(1) a').tab('show');
                $('#mytabs li:eq(1) a').trigger('click');
                $('#mytabs li:eq(1) a').parent().addClass('active');
            })
        })
       
    </script>
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
                            
                        </div>     
                         </div>
                    <div class="tab-pane fade" id="CreateComission">
                         <br /><br />
                        <div class="form-horizontal col-md-6">
                            <h4>Crie uma Comissão</h4>
                            <hr />
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="ErrorMessage" />
                            </p>
                            <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" BorderStyle="Dashed" BorderWidth="2px" />
                            <br />
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbModelo" CssClass="col-md-4 control-label">Modelo</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="TbModelo" CssClass="form-control" />
                                    <asp:RegularExpressionValidator ID="RegExModelo" runat="server" CssClass="text-danger"  Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Modelo Inválido" ControlToValidate="TbModelo"  ValidationExpression="^[a-zA-Z0-9.-]*$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-4 control-label">Tipo</asp:Label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="DdlTipo" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Urbana">Urbana</asp:ListItem>
                                        <asp:ListItem Value="Dobrável">Dobrável</asp:ListItem>
                                        <asp:ListItem Value="Montanha">Montanha</asp:ListItem>
                                        <asp:ListItem Value="Estrada">Estrada</asp:ListItem>
                                        <asp:ListItem Value="BMX">BMX</asp:ListItem>
                                        <asp:ListItem Value="Infantil">Infantil</asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="DdlOficinas" CssClass="col-md-4 control-label">Oficina</asp:Label>
                                <div class="col-md-5">
                                    <asp:SqlDataSource ID="SqlDataSourceDdlOficinas" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="GetWorkshopNames" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    <asp:DropDownList ID="DdlOficinas" runat="server"   CssClass="form-control" DataSourceID="SqlDataSourceDdlOficinas" DataTextField="WorkshopName" DataValueField="WorkshopName"></asp:DropDownList>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbAno" CssClass="col-md-4 control-label">Ano de Aquisição</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="TbAno" CssClass="form-control" />
                                    <asp:RegularExpressionValidator ID="RegExAno" runat="server" CssClass="text-danger"  Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Ano Inválido" ControlToValidate="TbAno"  ValidationExpression="^(1950|2017)\d{0}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbDetails" CssClass="col-md-4 control-label">Detalhes</asp:Label>
                                <div class="col-md-8">
                                   <asp:TextBox id="TbDetails" Height="180px" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RFVDetails" CssClass="text-danger"  Display="Dynamic" EnableClientScript="true" ErrorMessage="* Os detalhes do problema são obrigatórios!" SetFocusOnError="true" ControlToValidate="TbDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="BtnCreateComission" runat="server" CssClass="btn btn-primary col-md-3 col-md-offset-1" Text="Criar Comissão" OnClick="BtnCreateComission_Click" />
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



