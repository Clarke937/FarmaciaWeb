using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Strategy;

namespace FarmaciaWeb.Controllers
{
    public class TipoVentasController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        public List<tipo_venta> ObtenerTVenta()
        {
            return dbc.tipo_venta.ToList();
        }

        [HttpPost]
        public JsonResult InsertarTipoVenta(string nombre)
        {
            tipo_venta tv = new tipo_venta();
            tv.tipo = nombre;

            dbc.tipo_venta.Add(tv);
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarTipoVenta(int id)
        {
            dbc.tipo_venta.Remove(dbc.tipo_venta.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarTipoVenta(int id, string nombre)
        {
            tipo_venta pro = this.dbc.tipo_venta.Find(id);
            pro.tipo = nombre;
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        public List<object> GetDatos()
        {
            List<object> list =new List<object>();
            List<tipo_venta> tv = dbc.tipo_venta.ToList();
            foreach (object obj in tv)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}