using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Models;
using CryptSharp;

namespace FarmaciaWeb.Controllers
{
    public class LoginController : Controller
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CheckLogin(login login)
        {

            login usuario = dbc.login.Where(x => x.usuario.ToLower().Equals(login.usuario.ToLower())).FirstOrDefault();
            
            if(usuario != null)
            {
                if (Crypter.CheckPassword(login.contrasenia, usuario.contrasenia))
                {
                    this.Session["currentUser"] = usuario;
                    return RedirectToAction("Index","Login");
                }
            }

            return RedirectToAction("Index","Registro");
        }

    }
}
