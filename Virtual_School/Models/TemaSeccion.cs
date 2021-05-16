using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class TemaSeccion
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdSeccion { get; set; }
        public string TemaSeccions { get; set; }
        public Curso Cursos { get; set; }
        public Seccion Seccions { get; set; }
    }
}
