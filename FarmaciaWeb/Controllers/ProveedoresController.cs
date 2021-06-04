using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{
    public class ProveedoresController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        // GET: Proveedores
        public List<proveedor> ObtenerProveedores()
        {
            return dbc.proveedor.ToList();
        }

        [HttpPost]
        public JsonResult InsertarProveedor(string nombre, string direccion, string telefono)
        {
            proveedor pro = new proveedor();
            pro.nombre_proveedor = nombre;
            pro.direccion = direccion;
            pro.telefono = telefono;

            dbc.proveedor.Add(pro);
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarProveedor(int id)
        {
            dbc.proveedor.Remove(dbc.proveedor.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarProveedor(int id, string nombre, string direccion, string telefono)
        {
            proveedor pro = this.dbc.proveedor.Find(id);
            pro.nombre_proveedor = nombre;
            pro.direccion = direccion;
            pro.telefono = telefono;

            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<proveedor> pro =  dbc.proveedor.ToList();
            foreach(object obj in pro)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}