using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Alumno
    {
        // mapear las columnas de la tabla en propiedades
        public string CodAlumno { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string NombresAlumno { get; set; }
        public string UsuarioAlumno { get; set; }
        public string CodCarrera { get; set; }
    }
}
