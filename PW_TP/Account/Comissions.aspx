<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Account.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.dropdown-toggle').dropdown();
        });
    </script>
    <script>
        $(function () {
            $('#BtnRedirect').click(function (e) {
                //alert("test");
                e.preventDefault();
                $('#mytabs a[href="#tab2"]').tab('show');
            })
        }) 
    </script>
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="EditTablesUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <ul class="nav nav-tabs" id="mytabs" role="tablist">
                    <li class="active"><a aria-expanded="true" role="tab"  href="#tab1" data-toggle="tab">Informação   </a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab2" data-toggle="tab">Criar Comissão</a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab3" data-toggle="tab">Comissões Ativas   <span class="badge"><%= BadgeComissions.Text%></span></a></li>
                    <li><a aria-expanded="true" role="tab"  href="#tab4" data-toggle="tab">Comissões Concluídas </a></li>
                </ul>
                <br />
                <div class="tab-content"  id="myTabContent">
                    <div class="tab-pane fade active in" id="tab1">
                        <div class="jumbotron">
                            <h1>Crie uma Comissão</h1>
                            <br />
                            <p>Caso tenha problemas técnicos com a sua bicicleta, requisite ajuda de uma das várias oficinas disponíveis no website, localizadas por todo o país.</p>
                            <br />
                            <button type="button" class="btn btn-primary btn-lg" id="BtnRedirect">Criar Comissão</button>
                            
                        </div>     
                         </div>
                    <div class="tab-pane fade" id="tab2">
                         <br /><br />
                        <div class="form-horizontal col-md-6">
                            <h3>Crie uma Comissão</h3>
                            <hr />
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="ErrorMessage" />
                            </p>
                            <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" BorderStyle="Dashed" BorderWidth="2px" EnableClientScript="true" />
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
                                    <asp:DropDownList ID="DdlTipo" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                                        <asp:ListItem Value="Urbana">Urbana</asp:ListItem>
                                        <asp:ListItem Value="Dobrável">Dobrável</asp:ListItem>
                                        <asp:ListItem Value="Montanha">Montanha</asp:ListItem>
                                        <asp:ListItem Value="Estrada">Estrada</asp:ListItem>
                                        <asp:ListItem Value="BMX">BMX</asp:ListItem>
                                        <asp:ListItem Value="Infantil">Infantil</asp:ListItem>
                                    </asp:DropDownList> 
                                    <asp:RequiredFieldValidator ID="RFVDdlTipo" runat="server" CssClass="text-danger"
                                        ErrorMessage="Selecione um Tipo de Bicicleta" ControlToValidate="DdlTipo"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="DdlOficinas" CssClass="col-md-4 control-label">Oficina</asp:Label>
                                <div class="col-md-5">
                                    <asp:SqlDataSource ID="SqlDataSourceDdlOficinas" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="GetWorkshopNames" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    <asp:DropDownList ID="DdlOficinas" runat="server"  AppendDataBoundItems="true"  CssClass="form-control" DataSourceID="SqlDataSourceDdlOficinas" DataTextField="WorkshopName" DataValueField="WorkshopName">
                                        <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVDdlOficinas" runat="server" CssClass="text-danger"
                                        ErrorMessage="Selecione uma Oficina" ControlToValidate="DdlOficinas"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbAno" CssClass="col-md-4 control-label">Ano de Aquisição</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="TbAno" CssClass="form-control" TextMode="Number" />
                                    <asp:RangeValidator runat="server" ID="RngValTbAno"  CssClass="text-danger" Display="Dynamic" EnableClientScript="true" ErrorMessage="Ano inválido!" SetFocusOnError="true" MinimumValue="1950" MaximumValue="2017"  Type="Integer" ControlToValidate="TbAno"></asp:RangeValidator> 
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbDetails" CssClass="col-md-4 control-label">Detalhes</asp:Label>
                                <div class="col-md-8">
                                   <asp:TextBox id="TbDetails" Height="180px" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RFVDetails" CssClass="text-danger"  Display="Dynamic" EnableClientScript="true" ErrorMessage="Os detalhes do problema são obrigatórios!" SetFocusOnError="true" ControlToValidate="TbDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="BtnCreateComission" runat="server" CssClass="btn btn-primary col-md-3 col-md-offset-1" Text="Criar Comissão" OnClick="BtnCreateComission_Click" />
                            </div>
                        </div>
                    
                        </div>  
                    <div class="tab-pane fade" id="tab3">
                        <div class="form-group">
                            <h3>Comissões Aceites - <%=BadgeCountActiveComissions.Text %></h3>
                        
                        <asp:GridView ID="GridViewActiveComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" >
                            <Columns>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de Criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                            </div>
                        <br /><br />    
                        <div class="form-group">
                            <h3>Comissões Pendentes - <%=BadgeCountPendingComissions.Text %></h3>
                           
                        <asp:GridView ID="GridViewComissionsPending" runat="server"  ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                            </div>

                    </div> 
                    <div class="tab-pane fade" id="tab4">
                        <h3>Comissões Concluídas</h3>
                         <asp:GridView ID="HistoryOfComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false">
                        <Columns>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:CheckBoxField DataField="Accepted" HeaderText="Aceite" SortExpression="Accepted"></asp:CheckBoxField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                </div>
                <asp:Label ID="BadgeCountActiveComissions" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="BadgeCountPendingComissions" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="BadgeComissions" runat="server" Visible="false"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>



