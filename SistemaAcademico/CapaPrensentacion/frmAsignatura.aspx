<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignatura.aspx.cs" Inherits="CapaPrensentacion.frmAsignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h3>Mantenimiento de la tabla Asignatura</h3>

<p>
    CodAsignatura: <asp:TextBox runat="server" id="txtCodAsignatura" CssClass="form-control"/> 
</p>
<p> 
    Asignatura: <asp:TextBox runat="server" id="txtAsignatura" CssClass="form-control" />
</p>
 <p> 
    CodRequisito: <asp:TextBox runat="server" id="txtCodRequisito" CssClass="form-control"/>
</p>
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-warning" OnClick="btnActualizar_Click" />
</p>
<p>
     Buscar: <asp:TextBox runat="server" id="txtBuscar" CssClass="form-control" />
</p>
<p>
    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
</p>
<p>
    <asp:GridView runat="server" id="gvAsignatura" CssClass="table table-bordered text-center"></asp:GridView>
</p>

</asp:Content>
