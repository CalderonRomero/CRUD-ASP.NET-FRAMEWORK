<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAlumno.aspx.cs" Inherits="CapaPrensentacion.frmAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento de la tabla Alumno</h3>

<p>
    CodAlumno: <asp:TextBox runat="server" id="txtCodAlumno" CssClass="form-control"/> 
</p>
<p> 
    Apellido Paterno: <asp:TextBox runat="server" id="txtApPaterno" CssClass="form-control"/>
</p>
<p> 
    Apellido Materno: <asp:TextBox runat="server" id="txtApMaterno" CssClass="form-control"/>
</p>
<p> 
    Nombres: <asp:TextBox runat="server" id="txtNombres" CssClass="form-control"/>
</p>
 <p> 
    Usuario: <asp:TextBox runat="server" id="txtUsuario" CssClass="form-control"/>
</p>
 <p> 
    CodCarrera: <asp:TextBox runat="server" id="txtCodCarrera" CssClass="form-control"/>
</p>
<p>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
    <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-warning" OnClick="btnActualizar_Click" />

</p>
<p>
     Buscar: <asp:TextBox runat="server" id="txtBuscar" CssClass="form-control"/>
</p>
<p>
    <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
</p>
<p>
    <asp:GridView runat="server" id="gvAlumno" CssClass="table table-bordered text-center"></asp:GridView>
</p>
</asp:Content>
