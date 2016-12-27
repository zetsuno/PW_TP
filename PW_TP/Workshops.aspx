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
                <h1>Conheça as nossas oficinas</h1>
                <br /><br /><br /><br />
                <div id="one">
                <p>
                      Selecione a Região:   
                </p>
                <p>
                    <asp:DropDownList ID="DdlRegiao" runat="server" CssClass="form-control" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="DdlRegiao_SelectedIndexChanged">
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
                    <asp:DropDownList ID="DdlOficinas" runat="server" CssClass="form-control" AppendDataBoundItems="false" Width="280px" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="DdlOficinas_SelectedIndexChanged">
                    </asp:DropDownList>
                </p>
                <div>
                   <br /><br />
                  <asp:DetailsView runat="server" ID="DescOficina"   AllowPaging="false" Visible="false" HorizontalAlign="left" AutoGenerateRows="false"  >
                      <Fields>
                        <asp:BoundField DataField="WorkshopName" HeaderText="Nome" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopAddress" HeaderText="Morada" ReadOnly="True" />
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopPhone" HeaderText="Contacto" ReadOnly="True" />
                        <asp:BoundField DataField="WorkshopOwner" HeaderText="Titular" ReadOnly="True" />
                      </Fields>
                  </asp:DetailsView>
                </div>
               </div>
                <div id="two">
                    <p>Ou, pesquise por nome:</p>
                    <div class="w3-container" style="position:relative; display:inline-block"> 
                            <input runat="server" type="text" class='w3-input w3-border' name='sendmsg' id='txtSearchWorkshop' style="padding-right:30px; width:1500px"  required placeholder="Nome a procurar..." />
                            <button runat="server" class="w3-btn w3-green w3-border  w3-round-xlarge " id="btnSearchWorkshop" style="position:absolute; top: 2px; right: 16px;"  onServerClick="SearchWorkshop_OnClick">Procurar</button>
                       
                    </div>
                    <br /><br /><br />
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
            
          </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
