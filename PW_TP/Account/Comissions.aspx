<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comissions.aspx.cs" Inherits="PW_TP.Account.Comissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/star-rating.css" media="all" rel="stylesheet" type="text/css" />
    <script src="../Scripts/star-rating.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="../Scripts/locales/pt-BR.js"></script>
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
    <script>
        $(function () {
            $('#star-input').click(function (e) {
                //alert("test");
                document.getElementById('ratings').value = document.getElementById('star-input').value;
            })
        }) 
    </script>
    <div class="row">
        <br />
        <br />
        <asp:UpdatePanel runat="server" ID="EditTablesUpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                            <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" ValidationGroup="CreateCom" BorderStyle="Dashed" BorderWidth="2px" EnableClientScript="true" />
                            <br />
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbModelo" CssClass="col-md-4 control-label">Modelo</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="TbModelo" CssClass="form-control" />
                                    <asp:RegularExpressionValidator ID="RegExModelo" runat="server" ValidationGroup="CreateCom" CssClass="text-danger"  Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Modelo Inválido" ControlToValidate="TbModelo"  ValidationExpression="^[a-zA-Z0-9.-]*$"></asp:RegularExpressionValidator>
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
                                        InitialValue="0" ValidationGroup="CreateCom"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="DdlOficinasRegiao" CssClass="col-md-4 control-label">Região:</asp:Label>
                                <div class="col-md-5">
                                    
                                    <asp:DropDownList ID="DdlOficinasRegiao" runat="server" CssClass="form-control" AppendDataBoundItems="false" OnSelectedIndexChanged="DdlOficinasRegiao_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                                        <asp:ListItem Value="Total">Todas as Oficinas</asp:ListItem>
                                        <asp:ListItem Value="Porto e Norte">Porto e Norte</asp:ListItem>
                                        <asp:ListItem Value="Coimbra e Centro">Coimbra e Centro</asp:ListItem>
                                        <asp:ListItem Value="Lisboa">Lisboa</asp:ListItem>
                                        <asp:ListItem Value="Alentejo">Alentejo</asp:ListItem>
                                        <asp:ListItem Value="Algarve">Algarve</asp:ListItem>
                                        <asp:ListItem Value="Açores">Açores</asp:ListItem>
                                        <asp:ListItem Value="Madeira">Madeira</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVDdlOficinasRegiao" runat="server" CssClass="text-danger"
                                        ErrorMessage="Selecione uma Região" ControlToValidate="DdlOficinasRegiao"
                                        InitialValue="0" ValidationGroup="CreateCom"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="LbOficinas" CssClass="col-md-4 control-label">Escolha Oficina(s)</asp:Label>
                                <div class="col-md-5">
                                    <asp:ListBox ID="LbOficinas" runat="server" CssClass="form-control"  SelectionMode="Multiple">
                                    </asp:ListBox>
                                   <asp:RequiredFieldValidator ID="RFVLbOficinas" runat="server" CssClass="text-danger"
                                        ErrorMessage="Selecione pelo menos uma oficina!" ControlToValidate="LbOficinas"
                                        InitialValue="" ValidationGroup="CreateCom"></asp:RequiredFieldValidator>      
                                </div>
                            </div>
                             <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbAno" CssClass="col-md-4 control-label">Ano de Aquisição</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="TbAno" CssClass="form-control" TextMode="Number" />
                                    <asp:RangeValidator runat="server" ID="RngValTbAno"  ValidationGroup="CreateCom" CssClass="text-danger" Display="Dynamic" EnableClientScript="true" ErrorMessage="Ano inválido!" SetFocusOnError="true" MinimumValue="1950" MaximumValue="2017"  Type="Integer" ControlToValidate="TbAno"></asp:RangeValidator> 
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="TbDetails" CssClass="col-md-4 control-label">Detalhes</asp:Label>
                                <div class="col-md-8">
                                   <asp:TextBox id="TbDetails" Height="180px" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RFVDetails" ValidationGroup="CreateCom" CssClass="text-danger"  Display="Dynamic" EnableClientScript="true" ErrorMessage="Os detalhes do problema são obrigatórios!" SetFocusOnError="true" ControlToValidate="TbDetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="BtnCreateComission" runat="server" CssClass="btn btn-primary col-md-3 col-md-offset-1" Text="Criar Comissão" OnClick="BtnCreateComission_Click" CausesValidation="true" ValidationGroup="CreateCom" />
                            </div>
                        </div>
                    
                        </div>  
                    <div class="tab-pane fade" id="tab3">
                        <div class="form-group">
                            <h3>Comissões Aceites - <%=BadgeCountActiveComissions.Text %></h3>
                        
                        <asp:GridView ID="GridViewActiveComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" >
                            <Columns>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de Criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:TemplateField HeaderText="Aceite?" SortExpression="Accepted">
                                    <ItemTemplate><%# (Boolean.Parse(Eval("Accepted").ToString())) ? "Sim" : "Não" %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopPhone" HeaderText="Contacto da Oficina" SortExpression="WorkshopPhone"></asp:BoundField>
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Orçamento(€)" SortExpression="Orçamento(€)" />
                            </Columns>
                        </asp:GridView>
                            </div>
                        <br /><br />    
                        <div class="form-group">
                            <h3>Comissões Pendentes - <%=BadgeCountPendingComissions.Text %></h3>
                            <br />
                            <h4>De grupo</h4>
                            <br />
                            <div id="one">
                            <asp:GridView ID="GridViewGroupComissions" runat="server"  ShowHeaderWhenEmpty="true" Width="550px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="GroupNo" HeaderText="Número de Grupo" SortExpression="GroupNo"></asp:BoundField>
                                <asp:BoundField DataField="CDate" HeaderText="Data de criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:BoundField DataField="BType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="Det" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="BtnShowDetails" runat="server" CssClass="btn btn-success" CommandName="ShowGroupDetails"
                                            Text="Detalhes" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            <br />
                             </div>
                            <div id="two">
                             <asp:GridView ID="GridViewGroupDetails" runat="server"  ShowHeaderWhenEmpty="true" Width="550px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True" Visible="true"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Número da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                 <asp:TemplateField HeaderText="Orçamento(€)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LabelPrice" Text="N/A" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>     
                                        <asp:Button ID="BtnAcceptComission" runat="server" CssClass="btn btn-success" CausesValidation="true" CommandName="AcceptComission"
                                            Text="Aceitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="80px" Visible="true"  OnClientClick="return confirm('De certeza que quer aceitar esta comissão?')"/>
                                        <asp:Button ID="BtnRejectComission" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="RejectComission"
                                            Text="Rejeitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="80px"  OnClientClick="return confirm('De certeza que quer rejeitar a comissão?')" Visible="true" />  
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                                </div>
                            <br /><br /><br /><br />
                            <h4>Para uma única oficina</h4>
                            <br />
                        <asp:GridView ID="GridViewComissionsPending" runat="server"  ShowHeaderWhenEmpty="true" Width="1000px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                            <Columns>
                                 <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>     
                                        <asp:Button ID="BtnAcceptComission" runat="server" CssClass="btn btn-success" CausesValidation="true" CommandName="AcceptComissionNonGroup"
                                            Text="Aceitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px" Visible="true"  OnClientClick="return confirm('De certeza que quer aceitar esta comissão?')"/>
                                        <asp:Button ID="BtnRejectComission" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="RejectComissionNonGroup"
                                            Text="Rejeitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px"  OnClientClick="return confirm('De certeza que quer rejeitar a comissão?')" Visible="true" />  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:TemplateField HeaderText="Aceite?" SortExpression="Accepted">
                                    <ItemTemplate><%# (Boolean.Parse(Eval("Accepted").ToString())) ? "Sim" : "Não" %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopPhone" HeaderText="Contacto da Oficina" SortExpression="WorkshopPhone"></asp:BoundField> 
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details"></asp:BoundField>
                                <asp:TemplateField HeaderText="Orçamento(€)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="LabelPrice" Text="N/A" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                            </div>

                    </div> 
                    <div class="tab-pane fade" id="tab4">
                        <h3>Comissões Concluídas</h3>
                         <asp:GridView ID="HistoryOfComissions" runat="server" ShowHeaderWhenEmpty="true" Width="1200px" CssClass="list-group-item table-condensed table-hover table-responsive" AllowPaging="True"  AutoGenerateColumns="false" OnRowCommand="Comissions_RowCommand">
                        <Columns>
                                <asp:BoundField DataField="ComissionNo" HeaderText="Identificador da Comissão" SortExpression="ComissionNo"></asp:BoundField>
                                <asp:BoundField DataField="CreationDate" HeaderText="Data de criação" SortExpression="CreationDate"></asp:BoundField>
                                <asp:BoundField DataField="BicycleModel" HeaderText="Modelo da Bicicleta" SortExpression="BicycleModel"></asp:BoundField>
                                <asp:BoundField DataField="BicycleType" HeaderText="Tipo da Bicicleta" SortExpression="BicycleType"></asp:BoundField>
                                <asp:BoundField DataField="YearOfAquisition" HeaderText="Ano de Aquisição" SortExpression="YearOfAquisition"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopName" HeaderText="Oficina Encarregue" SortExpression="WorkshopName"></asp:BoundField>
                                <asp:BoundField DataField="WorkshopPhone" HeaderText="Contacto da Oficina" SortExpression="WorkshopPhone"></asp:BoundField>    
                                <asp:BoundField DataField="Details" HeaderText="Detalhes" SortExpression="Details" ItemStyle-Width="150px"></asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Orçamento(€)" SortExpression="Price" />
                                <asp:TemplateField HeaderText="Aceite?" SortExpression="Accepted">
                                    <ItemTemplate><%# (Boolean.Parse(Eval("Accepted").ToString())) ? "Sim" : "Não" %></ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField ShowHeader="true" HeaderText="Avalie o Serviço" ItemSTyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <input id="starating" runat="server" visible="true" name="input-4" type="number" class="rating rating-loading"  data-show-clear="false" data-show-caption="false" data-min="0" data-max="5" data-step="1">
                                        <asp:Label runat="server" ID="labelrejected" Text="Comissão Rejeitada" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false" ItemSTyle-Width="100px">
                                    <ItemTemplate>  
                                        <asp:Button ID="BtnSubmitRating" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="SubmitRating"
                                            Text="Submeter" CommandArgument="<%# ((GridViewRow) Container).RowIndex%>" Width="100px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
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



