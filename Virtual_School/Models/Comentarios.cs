using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtual_School.Models
{
    public class Comentarios
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public Account Accounts { get; set; }
    }
}
