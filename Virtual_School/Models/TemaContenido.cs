using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class TemaContenido
    {
        public int Id { get; set; }
        public int IdTemaSeccion { get; set; }
        public int IdSecciones { get; set; }
        public string TemaContent {get;set;}
        public Temas Tems { get; set; }
        public Seccion Secciones { get; set; }
    }
}
