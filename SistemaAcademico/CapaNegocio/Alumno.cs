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
    public class Alumno
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        // mapear las columnas de la tabla en propiedades
        public string CodAlumno { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string NombresAlumno { get; set; }
        public string UsuarioAlumno { get; set; }
        public string CodCarrera { get; set; }

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAlumno";
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
                string consulta = "INSERT INTO TAlumno (CodAlumno, APaterno, AMaterno, Nombres, Usuario, CodCarrera) VALUES (@CodAlumno, @APaterno, @AMaterno, @Nombres, @Usuario, @CodCarrera)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", NombresAlumno);
                comando.Parameters.AddWithValue("@Usuario", UsuarioAlumno);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
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
                string consulta = "DELETE FROM TAlumno WHERE CodAlumno = @CodAlumno";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
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
                string consulta = "UPDATE TAlumno SET APaterno = @APaterno, AMaterno = @AMaterno, Nombres = @Nombres, Usuario = @Usuario, CodCarrera = @CodCarrera WHERE CodAlumno = @CodAlumno";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", NombresAlumno);
                comando.Parameters.AddWithValue("@Usuario", UsuarioAlumno);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
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
                string consulta = "SELECT * FROM TAlumno WHERE CodAlumno = @Criterio OR APaterno LIKE '%' + @Criterio + '%' OR AMaterno LIKE '%' + @Criterio + '%' OR Nombres LIKE '%' + @Criterio + '%'";
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
