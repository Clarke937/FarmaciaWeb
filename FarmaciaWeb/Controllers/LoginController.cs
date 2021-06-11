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
            
            if (usuario != null)
            {
                if (Crypter.CheckPassword(login.contrasenia, usuario.contrasenia))
                {
                    if (usuario.fk_nivel.Equals(3))
                    {
                        registro registro = dbc.registro.Where(x => x.fk_login.Equals(usuario.id_login)).FirstOrDefault();
                        cliente cliente = dbc.cliente.Where(x => x.fk_registro.Equals(registro.id_registro)).FirstOrDefault();
                        this.Session["currentUser"] = usuario;
                        this.Session["id_user"] = cliente.id_cliente;
                        this.Session["user"] = usuario.usuario;
                        this.Session["name"] = registro.nombres.ToUpper();
                        this.Session["ape"] = registro.apellidos.ToUpper();
                        return RedirectToAction("Index", "Home");
                    } 
                    else
                    {
                        this.Session["currentUser"] = usuario;
                        return RedirectToAction("Index", "Dashboard");
                    }
                    
                }
            }
            return RedirectToAction("Index","Registro");
        }

        public ActionResult CerrarSesion()
        {
            this.Session["currentUser"] = null;
            return RedirectToAction("Index");
        }
    }
}
