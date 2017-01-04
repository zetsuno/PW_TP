<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Workshops.aspx.cs" Inherits="PW_TP.Workshops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UPWorkshopView" UpdateMode="Conditional">
        <ContentTemplate>
            <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css">
            <script type="text/javascript">
                function validateForm() {
                    var a = txtSearchWorkshop.value;
                    if (a == null || a == "") {
                        alert("Por favor introduza um nome");
                        return false;
                    }
                }
            </script>
            <br /><br /><br />
            <section>
            <div class="jumbotron container-fluid">
                <h3>Conheça as nossas oficinas</h3>
                <br /><br />
                 

                <div id="one" class="col-md-3">
                <p>
                      Selecione a Região:   
                </p>
                <p>
                    <asp:DropDownList ID="DdlRegiao" runat="server" CssClass="form-control" Width="150%" AutoPostBack="True" OnSelectedIndexChanged="DdlRegiao_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                        <asp:ListItem Value="Porto e Norte">Porto e Norte</asp:ListItem>
                        <asp:ListItem Value="Coimbra e Centro">Coimbra e Centro</asp:ListItem>
                        <asp:ListItem Value="Lisboa">Lisboa</asp:ListItem>
                        <asp:ListItem Value="Alentejo">Alentejo</asp:ListItem>
                        <asp:ListItem Value="Algarve">Algarve</asp:ListItem>
                        <asp:ListItem Value="Açores">Açores</asp:ListItem>
                        <asp:ListItem Value="Madeira">Madeira</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    Selecione a Oficina: 
                </p>
                <p>   
                    <asp:DropDownList ID="DdlOficinas" runat="server" CssClass="form-control" AppendDataBoundItems="false" Width="150%" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="DdlOficinas_SelectedIndexChanged">
                    </asp:DropDownList>
                </p>
                <div>
                   <br /><br />
                  <asp:DetailsView runat="server" ID="DescOficina" CssClass=" w3-table"  AllowPaging="false" Visible="false" HorizontalAlign="left" AutoGenerateRows="false"  >
                      <Fields>
                        <asp:BoundField DataField="WorkshopName" HeaderText="Nome" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopAddress" HeaderText="Morada" ReadOnly="True" />
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopPhone" HeaderText="Contacto" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopOwner" HeaderText="Titular" ReadOnly="True" />
                         <asp:TemplateField HeaderText="Avaliação">
                             <ItemTemplate>
                                 <asp:Label runat="server" ID="ratinglabel"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                      </Fields>
                  </asp:DetailsView>
                </div>
               </div>
                <div id="two" class="col-md-8" style="padding-left:30%;">
                    <p>
                        Ou pesquise por nome:
                    </p>
                    
                    <div class="w3-container" >
                        <div class="input-group">
                            <input runat="server" type="text" class="w3-input w3-border" name="sendmsg" id="txtSearchWorkshop" Width="150%" required placeholder="Nome a procurar..." />
                            <span class="input-group-btn">
                                <button runat="server" class="w3-btn w3-green w3-large" id="btnSearchWorkshop" type="button" onServerClick="SearchWorkshop_OnClick">Procurar</button>
                            </span>
                        </div>
                     </div>

                    <br /><br />
                    <div class="alert alert-dismissible alert-danger" runat="server" id="DivErrorMsg" visible="false" style="width:400px; float:left">  
                        <button class="close" type="button" data-dismiss="alert">&times;</button>   
                        <strong>Oops!</strong><br /><br />Oficina não encontrada no website!
                    </div>
                    <div class="alert alert-dismissible alert-warning" runat="server" id="DivTxtEmpty" visible="false" style="width:400px; float:left">
                        <button class="close" type="button" data-dismiss="alert">&times;</button>
                        <h4>Oops!</h4><br /><br />Parece que não introduziu algo para procurar!
                         <br />Por favor introduza um nome a pesquisar!
                    </div>
                </div>  
                    
                </div>
               
               
            
          </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
