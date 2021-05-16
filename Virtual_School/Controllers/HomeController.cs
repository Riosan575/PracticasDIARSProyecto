using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.DB;
using Virtual_School.Models;

namespace Virtual_School.Controllers
{
    public class HomeController : Controller
    {
        public class ComentDetalle
        {
            public Curso Curso { get; set; }
            public List<ContenidoCurso> Comentarios { get; set; }
        }
        private SchoolContext _context;
        public HomeController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cursos = _context.Cursos;
            return View(cursos);
        }
        [HttpGet]
        public ViewResult Detalle(int id)
        {
            var contenidos = _context.Contenidos.Include("Cursos")
                .Where(o => o.IdCurso == id).ToList();
            ViewBag.Comentarios = _context.Coments.Include("Accounts").Where(o => o.CursoId == id).ToList(); ;
            return View("Detalle", contenidos);
        }
        [HttpPost]
        [Authorize]
        public IActionResult TomarCurso(int id)
        {
            var claim = HttpContext.User.Claims.First();
            string username = claim.Value;
            var user = _context.Accounts.First(o => o.Usuario == username);

            var miscursos = _context.TomarCursos.Where(o => o.IdUsuario == user.Id).ToList();
            foreach (var item in miscursos)
            {
                if (item.IdCurso == id && item.IdUsuario == user.Id)
                {
                    ModelState.AddModelError("Error","Curso ya inscrito");
                    TempData["Error"] = "Curso isncrito anteriormente";
                }                
            }
            if (ModelState.IsValid)
            {
                TempData["Inscrito"] = "Curso inscrito con éxito";
                _context.TomarCursos.Add(new TomarCurso { IdUsuario = user.Id, IdCurso = id });
                _context.SaveChanges();
                return RedirectToAction("Index", "TomarCurso");
            }
            return RedirectToAction("Index", "TomarCurso");

        }
        [HttpPost]
        [Authorize]
        public IActionResult AddComentario(Comentarios coments, string detalle)
        {

            var claim = HttpContext.User.Claims.First();
            string username = claim.Value;
            var user = _context.Accounts.First(o => o.Usuario == username);
            var time = DateTime.Now;
            if (ModelState.IsValid) // no hay mensajes => 0 mensaje
            {
                _context.Coments.Add(new Comentarios { UsuarioId = user.Id, CursoId = coments.CursoId, Fecha = time, Comentario = detalle });
                _context.SaveChanges();
                return RedirectToAction("Detalle", new { id = coments.CursoId });
            }
            else
            {
                return RedirectToAction("Detalle");
            }

        }
    }
}
