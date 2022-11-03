<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="UI.Web.Informes" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
    <br />
    <div class="d-flex justify-content-around">
        <asp:Button ID="btnMateriasPorPlanes" runat="server" Text="Listado de Materias por Plan" OnClick="btnMateriasPorPlanes_Click" CssClass="btn btn-primary"/>
        <asp:Button ID="btnCupoPorMateria" runat="server" Text="Cupo por Materias" OnClick="btnCupoPorMateria_Click" CssClass="btn btn-primary"/>
    </div>
    <CR:CrystalReportViewer ID="crv" runat="server" AutoDataBind="true" />
    </asp:Content>
