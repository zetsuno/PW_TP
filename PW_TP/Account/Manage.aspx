<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="PW_TP.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
    <asp:UpdatePanel runat="server" ID="ManageUP">
        <ContentTemplate>
    
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="http://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <dt>Two-Factor Authentication:</dt>
                    <dd>
                        <p>
                            There are no two-factor authentication providers configured. See <a href="http://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                            for details on setting up this ASP.NET application to support two-factor authentication.
                        </p>
                        <% if (TwoFactorEnabled)
                          { %> 
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                          else
                          { %> 
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    </dd>
                    <dt>Tipo de Conta:</dt>
                    <dd>
                        <asp:Label runat="server" ID="accTypeLabel"></asp:Label>
                    </dd>
                    <p></p>
                    <dd>
                        <asp:Button runat="server" ID="ShowWorkshopForm" CssClass="btn btn-primary" Visible="false" OnClick="ShowWorkshopForm_Click"  CausesValidation="false" />
                        
                        
                    </dd>
                    
                </dl>
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
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NomeOficina" CssClass="text-danger" Display="Dynamic" ErrorMessage="O nome da oficina é necessário." />
                    <asp:RegularExpressionValidator ID="RegExNomeOficina" runat="server" Font-Bold="true" CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Nome inválido." ControlToValidate="NomeOficina"  ValidationExpression="^[a-zA-Z''-'.àáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,40}$"></asp:RegularExpressionValidator><br/>
                </div>
                <div class="col-ld-10">
                    <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Morada da Oficina</asp:Label>
                    <asp:TextBox runat="server" ID="MoradaOficina" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="MoradaOficina" CssClass="text-danger" Display="Dynamic" ErrorMessage="A morada da oficina é necessário." />
                    <asp:RegularExpressionValidator ID="RegExMoradaOficina" runat="server" Font-Bold="true" CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Morada inválida." ControlToValidate="MoradaOficina"  ValidationExpression="^[a-zA-Z1-9''-'.,ºàáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,50}$"></asp:RegularExpressionValidator><br/>
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
                            ErrorMessage="Selecione uma Região" ControlToValidate="DdlRegiao" EnableClientScript="true"
                            InitialValue="0"></asp:RequiredFieldValidator>
                        <br />
                    </div> 
                <div class="col-ld-10">
                    <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Nº telefone da oficina</asp:Label>                    
                    <asp:TextBox runat="server" ID="TelefoneOficina" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TelefoneOficina" CssClass="text-danger" Display="Dynamic" ErrorMessage="O contacto da oficina é necessário." />
                    <asp:RegularExpressionValidator ID="RegExTelefoneOficina" runat="server" CssClass="text-danger" Font-Bold="true" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Formato de contacto  inválido." ControlToValidate="TelefoneOficina"  ValidationExpression="^[0-9]{9}$"></asp:RegularExpressionValidator><br/>
                </div>
                <div class="col-ld-10">
                     <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">Titular</asp:Label>                    
                    <asp:TextBox runat="server" ID="TitularOficina" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TitularOficina" CssClass="text-danger" Display="Dynamic" ErrorMessage="O nome do titular da oficina é necessário." />
                    <asp:RegularExpressionValidator ID="RegExNomeTitular" runat="server" Font-Bold="true" CssClass="text-danger" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Nome inválido." ControlToValidate="TitularOficina"  ValidationExpression="^[a-zA-Z''-'.àáâäãåacceèéêëeiìíîïlnòóôöõøùúûüuuÿýzzñçcšžÀÁÂÄÃÅACCEEÈÉÊËÌÍÎÏILNÒÓÔÖÕØÙÚÛÜUUŸÝZZÑßÇŒÆCŠŽ?ð\s]{1,40}$"></asp:RegularExpressionValidator><br/>
                </div>
                <div class="col-ld-10">
                    <asp:Label runat="server" Font-Bold="true" CssClass="col-md-2 control-label">NIF do Titular da Oficina</asp:Label>                    
                    <asp:TextBox runat="server" ID="NIFTitularOficina" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NIFTitularOficina" CssClass="text-danger" Display="Dynamic" ErrorMessage="O NIF da oficina é necessário." />
                    <asp:RegularExpressionValidator ID="RegExNIFTitularOficina" runat="server" CssClass="text-danger"  Font-Bold="true" Display="Dynamic"  EnableClientScript="true" SetFocusOnError="true"  ErrorMessage="Formato de NIF inválido." ControlToValidate="NIFTitularOficina"  ValidationExpression="^[0-9]{9}$"></asp:RegularExpressionValidator><br/>
                </div>
                    <asp:Button runat="server" ID="btnRequestDualRole" CssClass="btn btn-primary" Text="Submeter" OnClick="btnRequestDualRole_Click" />
              </div>
         </div>
        </asp:Panel>
                        
                
            </div>
        </div>
    </div>
        <asp:CustomValidator id="NIFServerValidator" runat="server" 
        Display="None" EnableClientScript="False" ErrorMessage="O NIF introduzido está a ser usado por outro utilizador!"></asp:CustomValidator>  
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
