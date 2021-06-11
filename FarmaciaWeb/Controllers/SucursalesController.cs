using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{
    public class SucursalesController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        [HttpPost]
        public JsonResult InsertarSucursal(string nombre, string direccion, int nempleados)
        {
            sucursal pro = new sucursal();
            pro.nombre_sucursal = nombre;
            pro.direccion = direccion;
            pro.num_empleados = nempleados;

            dbc.sucursal.Add(pro);
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarSucursal(int id)
        {
            dbc.sucursal.Remove(dbc.sucursal.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarSucursal(int id, string nombre, string direccion, int nempleados)
        {
            sucursal pro = this.dbc.sucursal.Find(id);
            pro.nombre_sucursal = nombre;
            pro.direccion = direccion;
            pro.num_empleados = nempleados;

            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<sucursal> su = dbc.sucursal.ToList();
            foreach (object obj in su)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}