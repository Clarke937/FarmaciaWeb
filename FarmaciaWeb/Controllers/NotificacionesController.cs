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

        //Variable para crear observador
        private Sujeto sujeto = new Sujeto();
        
        public ActionResult Notificaciones()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                List<detalles_notificaciones> det_notify = ctx.detalles_notificaciones.OrderByDescending(x => x.fk_notificacion).Where(x => x.fk_cliente == id).ToList();
                foreach (detalles_notificaciones d in det_notify)
                {
                    d.notificaciones = ctx.notificaciones.Find(d.fk_notificacion);
                }
                this.Session["notificaciones"] = det_notify;

                ViewBag.sucursales = ctx.sucursal.ToList();
                ViewBag.registro = ctx.cliente.Find(id);
            }
            return View();
        }

        //Aca implemento el metodo para crear observador
        [HttpPost]
        public JsonResult Activar()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                cliente cl = ctx.cliente.Find(id);
                //Lo crea
                sujeto.Activar(cl);
            }
            return Json(true);
        }

        //Aca implemento el metodo para eliminar el observador
        [HttpPost]
        public JsonResult Desactivar()
        {
            if (Session["id_user"] != null)
            {
                int id = int.Parse(Session["id_user"].ToString());
                cliente cl = ctx.cliente.Find(id);
                //Lo elimina
                sujeto.Desactivar(cl);
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
                    List<detalles_notificaciones> detalles = ctx.detalles_notificaciones.Where(x => x.fk_cliente == id).ToList();
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
                    List<detalles_notificaciones> detalles = ctx.detalles_notificaciones.Where(x => x.fk_cliente == id).ToList();
                    foreach (detalles_notificaciones d in detalles)
                    {
                        ctx.detalles_notificaciones.Remove(ctx.detalles_notificaciones.FirstOrDefault(x => x.fk_cliente == d.fk_cliente));
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                detalles_notificaciones detalles = ctx.detalles_notificaciones.Where(x => x.fk_notificacion == idP && x.fk_cliente == idR).FirstOrDefault();
                detalles.estado = false;
                ctx.SaveChanges();
            }
            return Json(true);
        }
    }
}