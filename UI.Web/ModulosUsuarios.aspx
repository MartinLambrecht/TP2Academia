<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulosUsuarios.aspx.cs" Inherits="UI.Web.ModulosUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
<link type="text/css" rel="stylesheet" href="~/Style/Global.css" />
    <br />
    <br />
    <br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="id_modulo_usuario" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="8" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="3px">
       <Columns>
           <asp:BoundField HeaderText="Modulo" DataField="descripcion_modulo" />           
           <asp:BoundField HeaderText="Usuario" DataField="descripcion_usuario" />
           <asp:BoundField HeaderText="Persona" DataField="descripcion_persona" />
           <asp:CheckBoxField HeaderText="Permite Alta" DataField="alta" />
           <asp:CheckBoxField HeaderText="Permite Baja" DataField="baja" />
           <asp:CheckBoxField HeaderText="Permite Modificacion" DataField="modificacion" />
           <asp:CheckBoxField HeaderText="Permite Consulta" DataField="consulta" />
           <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ControlStyle-CssClass="btn btn-outline-primary"/>
       </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />

<SelectedRowStyle BackColor="#51d1f6" ForeColor="Black" Font-Bold="True"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    
    <asp:Panel ID="gridActionPanel" runat="server" Height="50px" HorizontalAlign="Center">
        <br />
        <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click" CssClass="btn btn-primary">Editar</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-primary">Eliminar</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" CssClass="btn btn-primary">Nuevo</asp:LinkButton>
    </asp:Panel>
        <br />

    <asp:Panel ID="formPanel" Visible="false" runat="server"  CssClass="container m-auto">
        <div class="row justify-content-md-center ">
            <asp:Label ID="lblUsuario" runat="server" Text="Seleccione Usuario: " CssClass="col-lg-2 text-end"/>
            <asp:DropDownList runat="server"  ID="ddlUsuarios" CssClass=" col-md-3"></asp:DropDownList>
        </div>
        <br />

        <div class="row justify-content-md-center ">
        <asp:Label ID="lblModulo" runat="server" Text="Seleccione el modulo: " CssClass="col-lg-2 text-end"/>
        <asp:DropDownList runat="server" ID="ddlModulo"  CssClass=" col-md-3"></asp:DropDownList>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblPermiteAlta" runat="server" Text="Permite Alta: " CssClass="col-lg-2 text-end"/>
            <asp:CheckBox ID="chkPermiteAlta" runat="server" CssClass=" col-md-3"/>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblPermiteBaja" runat="server" Text="Permite Baja: " CssClass="col-lg-2 text-end" />
            <asp:CheckBox ID="chkPermiteBaja"  runat="server"  CssClass=" col-md-3"/>
        </div>
        <br />

         <div class="row justify-content-md-center ">
            <asp:Label ID="lblPermiteModificacion" runat="server" Text="Permite Modificacion: " CssClass="col-lg-2 text-end" />
            <asp:CheckBox ID="chkPermiteModificacion"  runat="server"  CssClass=" col-md-3"/>
        </div>
        <br />

         <div class="row justify-content-md-center ">
            <asp:Label ID="lblPermiteConsulta" runat="server" Text="Permite Consulta: " CssClass="col-lg-2 text-end" />
            <asp:CheckBox ID="chkPermiteConsulta"  runat="server"  CssClass=" col-md-3"/>
        </div>
        <br />

        <asp:Panel ID="formActionPanel" runat="server" Height="50px" CssClass="container ">
            <div class="d-flex p-5 align-content-center justify-content-center">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click"  CausesValidation="true" CssClass="btn btn-primary justify-content-center m-5">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CausesValidation="false"  CssClass="btn btn-secondary justify-content-center m-5">Cancelar</asp:LinkButton>
            </div>
        </asp:Panel>

    </asp:Panel>
    
</asp:Content>
