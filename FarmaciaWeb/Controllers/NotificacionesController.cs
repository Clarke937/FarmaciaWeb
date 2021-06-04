using FarmaciaWeb.Models;
using FarmaciaWeb.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{
    public class NotificacionesController : Controller
    {
        arqfarmaciaEntities ctx = new arqfarmaciaEntities();
        private Sujeto sujeto = new Sujeto();
        
        public ActionResult Notificaciones()
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

                ViewBag.sucursales = ctx.sucursal.ToList();
                ViewBag.registro = ctx.registro.Find(id);
            }
            return View();
        }

        [HttpPost]
        public JsonResult Activar()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                registro res = ctx.registro.Find(id);
                sujeto.Activar(res);
            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult Desactivar()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                registro res = ctx.registro.Find(id);
                sujeto.Desactivar(res);
            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult Vista(int idP, int idR)
        {
            if (idP == 0 && idR == 0)
            {
                if (Session["id_user"] != null)
                {
                    int id = int.Parse(Session["id_user"].ToString());
                    List<detalles_notificaciones> detalles = ctx.detalles_notificaciones.Where(x => x.fk_registro == id).ToList();
                    foreach (detalles_notificaciones d in detalles)
                    {
                        d.estado = false;
                        ctx.SaveChanges();
                    }
                }
            }
            else if (idR == -1 && idP == -1)
            {
                if (Session["id_user"] != null)
                {
                    int id = int.Parse(Session["id_user"].ToString());
                    List<detalles_notificaciones> detalles = ctx.detalles_notificaciones.Where(x => x.fk_registro == id).ToList();
                    foreach (detalles_notificaciones d in detalles)
                    {
                        ctx.detalles_notificaciones.Remove(ctx.detalles_notificaciones.FirstOrDefault(x => x.fk_registro == d.fk_registro));
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                detalles_notificaciones detalles = ctx.detalles_notificaciones.Where(x => x.fk_notificacion == idP && x.fk_registro == idR).FirstOrDefault();
                detalles.estado = false;
                ctx.SaveChanges();
            }
            return Json(true);
        }
    }
}