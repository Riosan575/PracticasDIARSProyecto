using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.DB;
using Virtual_School.Models;

namespace Virtual_School.Controllers
{
    public class CursoTemasController : Controller
    {
        private SchoolContext _context;
        public CursoTemasController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index(int id)
        {
            var claim = HttpContext.User.Claims.First();
            string username = claim.Value;
            var user = _context.Accounts.First(o => o.Usuario == username);

            var cursos = _context.Temas.Include("Cursos")
                .Include("temaContent")
                .Where(o => o.CursoId == id).FirstOrDefault();


            ViewBag.Seccion = _context.temaSeccions.Include("Cursos")
                .Include("Seccions")
                .Where(o => o.IdCurso == id).ToList();

            ViewBag.TemaContent = _context.TemaContenidos.Include("Secciones")
                .Where(o => o.IdTemaSeccion == id).ToList();
            

            return View(cursos);
        }
        [HttpGet]
        public IActionResult Video(int idTemaContenido,int idCurso)
        {
            var video = _context.Temas.Where(o => o.IdTemaContent == idTemaContenido && o.CursoId == idCurso).FirstOrDefault();
            return Json(video);
        }

    }
}
