using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
namespace CapaPrensentacion
{
    public partial class frmAlumno : System.Web.UI.Page
    {
        private void Listar()
        {
            Alumno alumno = new Alumno();
            gvAlumno.DataSource = alumno.Listar();
            gvAlumno.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cargar la lista solo la primera vez que se carga la página
            if (!Page.IsPostBack)
            {
                Listar();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtApPaterno.Text.Trim();
            alumno.AMaterno = txtApMaterno.Text.Trim();
            alumno.NombresAlumno = txtNombres.Text.Trim();
            alumno.UsuarioAlumno = txtUsuario.Text.Trim();
            alumno.CodCarrera = txtCodCarrera.Text.Trim();

            if (alumno.Agregar())
            {
                Listar();
            }
            else
            {
                Response.Write("No se agregó el alumno");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();

            if (alumno.Eliminar())
            {
                Listar();
            }
            else
            {
                Response.Write("No se eliminó el alumno");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtApPaterno.Text.Trim();
            alumno.AMaterno = txtApMaterno.Text.Trim();
            alumno.NombresAlumno = txtNombres.Text.Trim();
            alumno.UsuarioAlumno = txtUsuario.Text.Trim();
            alumno.CodCarrera = txtCodCarrera.Text.Trim();

            if (alumno.Actualizar())
            {
                Listar();
            }
            else
            {
                Response.Write("No se actualizó el alumno");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim(); // Obtener el criterio de búsqueda

            // Llamar al método Buscar
            DataTable resultado = new Alumno().Buscar(criterio);

            if (resultado.Rows.Count > 0)
            {
                gvAlumno.DataSource = resultado; // Asignar el DataTable al GridView
                gvAlumno.DataBind(); // Realizar el binding
            }
            else
            {
                Response.Write("No se encontraron resultados");
                gvAlumno.DataSource = null; // Limpiar el GridView si no hay resultados
                gvAlumno.DataBind(); // Realizar el binding para limpiar la vista
            }
        }
    }
}