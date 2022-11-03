<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server" >
    <link type="text/css" rel="stylesheet" href="~/Style/Global.css" />
    <br />
    <br />
    <br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="8" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="3px">
       <Columns>
           <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
           <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
           <asp:BoundField HeaderText="Email" DataField="Email" />
           <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
           <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
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
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtNombre" runat="server" CssClass=" col-md-3"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ControlToValidate="txtNombre" runat="server" ErrorMessage="El Nombre es requerido." CssClass="col-lg-2 "></asp:RequiredFieldValidator>
        </div>
        <br />

        <div class="row justify-content-md-center ">
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: " CssClass="col-lg-2 text-end"/>
        <asp:TextBox ID="txtApellido" runat="server" CssClass=" col-md-3"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ControlToValidate="txtApellido"   ErrorMessage="El Apellido es requerido."  CssClass="col-lg-2 "></asp:RequiredFieldValidator>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtEmail" runat="server" CausesValidation="true" CssClass=" col-md-3"/>
            <div class="col-lg-2">
                <asp:CustomValidator ID="CustomValidatorEmail" ControlToValidate="txtEmail" OnServerValidate="ValidateEmail" runat="server" ErrorMessage="El Email no es valido."  CssClass="position-relative "/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="El Email es requerido." CssClass="position-relative "/>
            </div>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: " CssClass="col-lg-2 text-end" />
            <asp:CheckBox ID="chkHabilitado" runat="server" CssClass=" col-md-3 justify-content-center"/>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass=" col-md-3"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombreUsuario" controlToValidate="txtNombreUsuario" runat="server" ErrorMessage="El Usuario es requerido." CssClass="col-lg-2 "></asp:RequiredFieldValidator>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblClave" runat="server" Text="Clave: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtClave" TextMode="Password" runat="server" CssClass=" col-md-3" />
            <div class="col-lg-2">
                <asp:CustomValidator ID="CustomValidatorClave" controlToValidate="txtClave" OnServerValidate="ValidatePassword" runat="server" ErrorMessage="La Clave no es valida."  CssClass="position-relative "></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClave" controlToValidate="txtClave" runat="server" ErrorMessage="La clave es requerida." CssClass="position-relative  " ></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir clave: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server" CssClass=" col-md-3"/>
            <asp:CompareValidator ID="CompareValidatorPassword" ControlToValidate="txtRepetirClave" ControlToCompare="txtClave" runat="server" ErrorMessage="Las claves no coinciden."  CssClass="col-lg-2 "/>
        </div>

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblPersona" runat="server" Text="Seleccione la persona: " CssClass="col-lg-2 text-end"/>
            <asp:DropDownList ID="ddlPersona" runat="server" CssClass=" col-md-3"/>
        </div>

        <asp:Panel ID="formActionPanel" runat="server" Height="50px" CssClass="container ">
            <div class="d-flex p-5 align-content-center justify-content-center">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click"  CausesValidation="true" CssClass="btn btn-primary justify-content-center m-5">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CausesValidation="false"  CssClass="btn btn-secondary justify-content-center m-5">Cancelar</asp:LinkButton>
            </div>
        </asp:Panel>

    </asp:Panel>
    
</asp:Content>


