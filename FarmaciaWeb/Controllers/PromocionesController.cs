using FarmaciaWeb.Models;
using FarmaciaWeb.Observer;
using FarmaciaWeb.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{

    public class PromocionesController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        //Variable para el observable
        private Sujeto sujeto = new Sujeto();

        [HttpPost]
        public JsonResult InsertarPromocion(string titulo, string descripcion, decimal ahorro)
        {
            promocion pro = new promocion();
            pro.titulo = titulo;
            pro.descripcion = descripcion;
            pro.ahorro = ahorro;

            dbc.promocion.Add(pro);
            int affected = dbc.SaveChanges();

            //Aca agrego un nuevo evento que activa los observadores
            sujeto.CrearNotificacion(titulo,descripcion,ahorro);
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarPromocion(int id)
        {
            dbc.promocion.Remove(dbc.promocion.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarPromocion(int id, string titulo, string descripcion, decimal ahorro)
        {
            promocion pro = this.dbc.promocion.Find(id);
            pro.titulo = titulo;
            pro.descripcion = descripcion;
            pro.ahorro = ahorro;

            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }


        //Este metodo heredado recupera los datos para obtener por medio de la estrategia
        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<promocion> prom = dbc.promocion.ToList();
            foreach (object obj in prom)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}