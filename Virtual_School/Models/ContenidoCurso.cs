using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class ContenidoCurso
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Aprender { get; set; }
        public string Contenido { get; set; }
        public string Requisitos { get; set; }
        public string Descripción { get; set; }
        public string ParaQuienEs { get; set; }
        public Curso Cursos { get; set; }
    }
}
