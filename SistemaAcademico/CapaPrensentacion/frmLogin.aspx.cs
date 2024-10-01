using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPrensentacion
{
    public partial class frmLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();

            // Obtener la cadena de conexión desde Web.config
            string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

            // Asegúrate de que la cadena de conexión se haya obtenido correctamente
            if (string.IsNullOrEmpty(cadena))
            {
                Response.Write("Error en la cadena de conexión.");
                return; // Salir si la cadena de conexión es nula o vacía
            }

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT COUNT(1) FROM TUsuario WHERE Usuario = @Usuario AND Contrasena = @Contrasena";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);

                conexion.Open();
                int count = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

                if (count == 1)
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("frmCarrera.aspx");
                }
                else
                {
                    Response.Write("Usuario o contraseña incorrectos.");
                }
            }
        }
    }
}