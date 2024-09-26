using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace CapaNegocio
{
    public class Carrera
    {
        //carrera de coneccion
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        // mapear las columnas de la tabla en propiedades
        public string CodCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCarrera";
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
                string consulta = "insert into TCarrera values (@CodCarrera, @NombreCarrera)";
                SqlCommand comando  = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                comando.Parameters.AddWithValue("@NombreCarrera", NombreCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();   
                if (i == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "delete from TCarrera where CodCarrera = @CodCarrera";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public bool Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "update TCarrera set Carrera = @NombreCarrera where CodCarrera= @CodCarrera";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                comando.Parameters.AddWithValue("@NombreCarrera", NombreCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public DataTable Buscar(string criterio)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TCarrera WHERE CodCarrera = @Criterio OR Carrera LIKE '%' + @Criterio + '%'";
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
