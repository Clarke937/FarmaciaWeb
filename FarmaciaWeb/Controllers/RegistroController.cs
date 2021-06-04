using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Models;
using CryptSharp;

namespace FarmaciaWeb.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        public ActionResult Index()
        {
            ViewBag.Generos = getGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCliente(Login_Registro lr)
        {
            login login = new login();
            login.usuario = lr.usuario;
            login.contrasenia = Crypter.MD5.Crypt(lr.contrasenia);
            login.fk_nivel = 3;
            //
            dbc.login.Add(login);
            dbc.SaveChanges();
            //
            registro registro = new registro();
            registro.nombres = lr.nombres;
            registro.apellidos = lr.apellidos;
            registro.dui = lr.dui;
            registro.estado_notificaciones = true;
            registro.nit = lr.nit;
            registro.direccion = lr.direccion;
            registro.genero = getGeneros()[lr.genero].Value;
            registro.edad = lr.edad;
            registro.fecha_registro = DateTime.Now.Date.ToShortDateString();
            registro.fk_login = login.id_login;
            //
            dbc.registro.Add(registro);
            dbc.SaveChanges();

            return RedirectToAction("Index","Registro");
        }

        [HttpPost]
        public JsonResult CheckUserExist(string username)
        {
            login login = dbc.login.Where(x => x.usuario.ToLower().Equals(username.ToLower())).FirstOrDefault();
            return Json(login == null);
        }


        private List<SelectListItem> getGeneros()
        {
            List<SelectListItem> generos = new List<SelectListItem>();
            generos.Add(new SelectListItem() { Value = "0", Text = "Seleccionar" });
            generos.Add(new SelectListItem() { Value = "1", Text = "Masculino" });
            generos.Add(new SelectListItem() { Value = "2", Text = "Femenino" });
            generos.Add(new SelectListItem() { Value = "3", Text = "Otro" });
            return generos;
        }


    }
}
