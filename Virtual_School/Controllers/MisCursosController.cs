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
    public class MisCursosController : Controller
    {
        private SchoolContext _context;
        public MisCursosController(SchoolContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var claim = HttpContext.User.Claims.First();
            string username = claim.Value;
            var user = _context.Accounts.First(o => o.Usuario == username);
            ViewBag.tomarcurso = _context.TomarCursos.Include("Cursos").Where(o => o.IdUsuario == user.Id).ToList();
            return View();
        }
    }
}
