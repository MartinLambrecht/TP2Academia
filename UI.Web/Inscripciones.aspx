<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server" >
    <link type="text/css" rel="stylesheet" href="~/Style/Global.css" />
    <br />
    <br />
    <br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="id_inscripcion" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="8" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="3px">
       <Columns>
           <asp:BoundField HeaderText="Inscripcion" DataField="id_inscripcion" />
           <asp:BoundField HeaderText="Legajo" DataField="legajo" />           
           <asp:BoundField HeaderText="Nombre" DataField="nombre" />
           <asp:BoundField HeaderText="Apellido" DataField="apellido" />
           <asp:BoundField HeaderText="Comision" DataField="desc_comision" />
           <asp:BoundField HeaderText="Materia" DataField="desc_materia" />
           <asp:BoundField HeaderText="Condicion" DataField="condicion" />
           <asp:BoundField HeaderText="Nota" DataField="nota" />
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
            <asp:Label ID="lblAlumno" runat="server" Text="Seleccione Alumno: " CssClass="col-lg-2 text-end"/>
            <asp:DropDownList runat="server"  ID="ddlAlumnos" CssClass=" col-md-3"></asp:DropDownList>
        </div>
        <br />

        <div class="row justify-content-md-center ">
        <asp:Label ID="lblCurso" runat="server" Text="Seleccione el curso: " CssClass="col-lg-2 text-end"/>
        <asp:DropDownList runat="server" ID="ddlCurso"  CssClass=" col-md-3"></asp:DropDownList>
        
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblCondicion" runat="server" Text="Condicion: " CssClass="col-lg-2 text-end"/>
            <asp:TextBox ID="txtCondicion" runat="server" CssClass=" col-md-3"/>
            <asp:RequiredFieldValidator runat="server"  ControlToValidate="txtCondicion" runat="server" ErrorMessage="La condicion es requerida." CssClass="col-lg-2 "></asp:RequiredFieldValidator>
        </div>
        <br />

        <div class="row justify-content-md-center ">
            <asp:Label ID="lblNota" runat="server" Text="Nota: " CssClass="col-lg-2 text-end" />
            <asp:TextBox ID="txtNota" type="number"  runat="server"   CssClass=" col-md-3"/>
            <asp:RangeValidator runat="server"  MaximumValue="10" MinimunValue="0" ControlToValidate="txtNota"  runat="server" ErrorMessage="La nota debe ser un valor entre 0 y 10." CssClass="col-lg-2 "></asp:RangeValidator>
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


