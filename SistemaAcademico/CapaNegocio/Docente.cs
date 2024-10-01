using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Docente
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        public string CodDocente { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string NombresDocente { get; set; }
        public string UsuarioDocente { get; set; }

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TDocente";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool Agregar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "INSERT INTO TDocente (CodDocente, APaterno, AMaterno, Nombres, Usuario) VALUES (@CodDocente, @APaterno, @AMaterno, @Nombres, @Usuario)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", NombresDocente);
                comando.Parameters.AddWithValue("@Usuario", UsuarioDocente);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                return i == 1;
            }
        }

        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM TDocente WHERE CodDocente = @CodDocente";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                return i == 1;
            }
        }

        public bool Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "UPDATE TDocente SET APaterno = @APaterno, AMaterno = @AMaterno, Nombres = @Nombres, Usuario = @Usuario WHERE CodDocente = @CodDocente";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodDocente", CodDocente);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", NombresDocente);
                comando.Parameters.AddWithValue("@Usuario", UsuarioDocente);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                return i == 1;
            }
        }

        public DataTable Buscar(string criterio)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TDocente WHERE CodDocente = @Criterio OR APaterno LIKE '%' + @Criterio + '%' OR AMaterno LIKE '%' + @Criterio + '%' OR Nombres LIKE '%' + @Criterio + '%'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Criterio", criterio);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
