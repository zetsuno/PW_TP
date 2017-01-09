<%@ Page Title="Registe-se" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PW_TP.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <h4>Crie uma conta de utilizador ou de oficina</h4>
        <hr />
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" /> 
        </p>
        <asp:ValidationSummary runat="server" CssClass="text-danger" BorderColor="#fa3250" BorderStyle="Dashed" BorderWidth="1px"/>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Email é obrigatório" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="A password é obrigatória." />
                <asp:RegularExpressionValidator ID="RegExPassword" runat="server" CssClass="text-danger" 
                    Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  
                    ErrorMessage="Password requer pelo menos 8 caracteres, um caracter capitalizado, um caracter numeral e um caracter especial." 
                    ControlToValidate="Password"  ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirme a password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A confirmação de password é obrigatória." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="As passwords não coincidem uma com a outra." />
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"  >
            <ContentTemplate>
                <label class="col-md-2 control-label">Tipo de Conta</label>
                <div class="col-md-10">
                    <div class="radio">
                        <label>
                            <asp:RadioButton ID="RBtnCliente" runat="server" GroupName="RBtns" 
                                OnCheckedChanged="RBtnCliente_CheckedChanged" AutoPostBack="true"/> 
                            <strong>Cliente</strong>
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton ID="RBtnOficina" runat="server" GroupName="RBtns" 
                                OnCheckedChanged="RBtnOficina_CheckedChanged" AutoPostBack="true" /> 
                            <strong>Oficina</strong>
                        </label>
                    </div>
                </div>
        <!--</div>-->
      
                <br /><br /><br />
                <asp:Panel runat="server" ID="PainelOficina" Visible="false">
                    <br/>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Informação da Oficina</h3>
                        </div>
                        <div class="panel-body">
                            <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Nome da Oficina</asp:Label>
                            <div class="col-ld-10">
                                <asp:TextBox runat="server" ID="NomeOficina" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NomeOficina" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O nome da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExNomeOficina" runat="server" Font-Bold="true" 
                                    CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true" 
                                    ErrorMessage="Nome inválido." ControlToValidate="NomeOficina"  
                                    ValidationExpression="^[a-zA-Z''-'.àáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,40}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Morada da Oficina</asp:Label>
                                <asp:TextBox runat="server" ID="MoradaOficina" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="MoradaOficina" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A morada da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExMoradaOficina" runat="server" Font-Bold="true" 
                                    CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  
                                    ErrorMessage="Morada inválida." ControlToValidate="MoradaOficina"  
                                    ValidationExpression="^[a-zA-Z1-9''-'.,ºàáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,50}$">
                                </asp:RegularExpressionValidator><br/>
                            </div> 
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Região da Oficina</asp:Label>
                                <asp:DropDownList ID="DdlRegiao" runat="server" CssClass="form-control" AppendDataBoundItems="true" Width="280px">
                                    <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                                    <asp:ListItem Value="Porto e Norte">Porto e Norte</asp:ListItem>
                                    <asp:ListItem Value="Coimbra e Centro">Coimbra e Centro</asp:ListItem>
                                    <asp:ListItem Value="Lisboa">Lisboa</asp:ListItem>
                                    <asp:ListItem Value="Alentejo">Alentejo</asp:ListItem>
                                    <asp:ListItem Value="Algarve">Algarve</asp:ListItem>
                                    <asp:ListItem Value="Açores">Açores</asp:ListItem>
                                    <asp:ListItem Value="Madeira">Madeira</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVDdlRegiao" runat="server" CssClass="text-danger" Display="dynamic" SetFocusOnError="true" 
                                    ErrorMessage="Selecione uma Região" ControlToValidate="DdlRegiao" EnableClientScript="true" InitialValue="0">
                                </asp:RequiredFieldValidator>
                                <br />
                            </div> 
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Nº telefone da oficina</asp:Label>                    
                                <asp:TextBox runat="server" ID="TelefoneOficina" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TelefoneOficina" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O contacto da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExTelefoneOficina" runat="server" 
                                    CssClass="text-danger" Font-Bold="true" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  
                                    ErrorMessage="Formato de contacto  inválido." ControlToValidate="TelefoneOficina"  ValidationExpression="^[0-9]{9}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                            <div class="col-ld-10">
                                 <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Titular</asp:Label>                    
                                <asp:TextBox runat="server" ID="TitularOficina" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TitularOficina" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O nome do titular da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExNomeTitular" runat="server" Font-Bold="true" 
                                    CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true" 
                                    ErrorMessage="Nome inválido." ControlToValidate="TitularOficina"  
                                    ValidationExpression="^[a-zA-Z''-'.àáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,40}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">NIF do Titular da Oficina</asp:Label>                    
                                <asp:TextBox runat="server" ID="NIFTitularOficina" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NIFTitularOficina" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O NIF da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExNIFTitularOficina" runat="server" 
                                    CssClass="text-danger" Font-Bold="true" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true" 
                                    ErrorMessage="Formato de NIF inválido." ControlToValidate="NIFTitularOficina"  ValidationExpression="^[0-9]{9}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server"  ID="PainelUtilizador" Visible="false">
                    <br />
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Informação de Cliente</h3>
                        </div>
                        <div class="panel-body">     
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Nome</asp:Label>
                                <asp:TextBox runat="server" ID="NomeCliente" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NomeCliente" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O nome da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExNomeCliente" runat="server" Font-Bold="true" 
                                    CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true" 
                                    ErrorMessage="Nome inválido." ControlToValidate="NomeCliente"  
                                    ValidationExpression="^[a-zA-Z''-'.àáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,40}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                            <div class="col-ld-10">
                                <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Nº Telefone</asp:Label>                    
                                <asp:TextBox runat="server" ID="TelefoneClient" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TelefoneClient" 
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O NIF da oficina é necessário." />
                                <asp:RegularExpressionValidator ID="RegExTelefoneClient" runat="server" CssClass="text-danger" 
                                    Font-Bold="true" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  
                                    ErrorMessage="Formato de NIF inválido." ControlToValidate="TelefoneClient"  ValidationExpression="^[0-9]{9}$">
                                </asp:RegularExpressionValidator><br/>
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator id="NIFServerValidator" runat="server" Display="None" EnableClientScript="False" 
                        ErrorMessage="O NIF introduzido está a ser usado por outro utilizador!">
                    </asp:CustomValidator>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="col-mod-offset-2 col-md-10">
                <br />
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registar-me" CssClass="btn btn-default" />
            </div>
        </div>
    </div> 
</asp:Content>