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
    public class Asignatura
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        public string CodAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public string CodRequisito { get; set; }

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAsignatura";
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
                string consulta = "INSERT INTO TAsignatura (CodAsignatura, Asignatura, CodRequisito) VALUES (@CodAsignatura, @NombreAsignatura, @CodRequisito)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodRequisito", CodRequisito ?? (object)DBNull.Value);
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
                string consulta = "DELETE FROM TAsignatura WHERE CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
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
                string consulta = "UPDATE TAsignatura SET Asignatura = @NombreAsignatura, CodRequisito = @CodRequisito WHERE CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodRequisito", CodRequisito ?? (object)DBNull.Value);
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
                string consulta = "SELECT * FROM TAsignatura WHERE CodAsignatura = @Criterio OR Asignatura LIKE '%' + @Criterio + '%'";
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
