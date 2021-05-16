using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string NombreProfesor { get; set; }
        public string NombreCurso { get; set; }
        public string Caratula { get; set; }
        public string Detalle { get; set; }
    }
}
