using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Models;
using FarmaciaWeb.Observer;

namespace FarmaciaWeb.Controllers
{
    public class HomeController : Controller
    {
        arqfarmaciaEntities ctx = new arqfarmaciaEntities();
        public ActionResult Index()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                List<detalles_notificaciones> det_notify = ctx.detalles_notificaciones.OrderByDescending(x => x.fk_notificacion).Where(x => x.fk_registro == id).ToList();
                foreach (detalles_notificaciones d in det_notify)
                {
                    d.notificaciones = ctx.notificaciones.Find(d.fk_notificacion);
                }
                this.Session["notificaciones"] = det_notify; 
            }
            return View();
        }
    }
}
