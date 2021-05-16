using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Virtual_School.DB;
using System.Security.Cryptography;
using Virtual_School.Models;

namespace Virtual_School.Controllers
{    
    public class LoginController : Controller
    {
        private SchoolContext context;
        private IConfiguration configuration;
        public LoginController(SchoolContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View("Register",new Account());
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.Accounts
                .FirstOrDefault(o => o.Usuario == username && o.Contraseña == CreateHash(password));

            if (user == null)
            {
                TempData["AuthMessage"] = "Usuario o Contraseña incorrecto";
                return RedirectToAction("Login");
            }

            // Autenticar
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Usuario),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrincipal);


            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Register(Account account, string usuario, string contraseña, string correo, string verfcontraseña) // POST
        {
            var accounts = context.Accounts.ToList();
            foreach (var item in accounts)
            {
                if (item.Usuario == usuario)
                    ModelState.AddModelError("Usuario", "El Usuario ya existe, ingrese otro Usuario");
            }
            foreach (var item in accounts)
            {
                if (item.Correo == correo)
                    ModelState.AddModelError("Correo", "El correo ya existe, ingrese otro correo");
            }

            if (ModelState.IsValid)
            {
                account.Contraseña = CreateHash(contraseña);
                account.VerfContraseña = CreateHash(verfcontraseña);
                context.Accounts.Add(account);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Register", account);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        private string CreateHash(string input)
        {
            var sha = SHA512.Create();
            input += configuration.GetValue<string>("Key");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
