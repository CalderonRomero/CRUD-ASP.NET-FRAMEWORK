using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Login
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        // mapear las columnas de la tabla en propiedades
        public string Usuario { get; set; }
        public string Password { get; set; }

        public bool ValidarUsuario()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT COUNT(1) FROM TUsuario WHERE Usuario = @Usuario AND Contrasena = @Password";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@Password", Password);

                conexion.Open();
                int count = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

                return count == 1;
            }
        }
    }
}
