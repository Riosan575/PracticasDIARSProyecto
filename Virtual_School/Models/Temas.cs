using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class Temas
    {
        public int Id { get; set; }
        public string Videos { get; set; }
        public int CursoId { get; set; }
        public int IdTemaContent { get; set; }
        public Curso Cursos { get; set; }
        public TemaContenido temaContent { get; set; }
    }
}
