using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Models;

namespace FarmaciaWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();
        public ActionResult Index()
        {
            return View();
        }


        #region PROMOCIONES
        public ActionResult Promociones()
        {
            ViewBag.Promociones = dbc.promocion.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult InsertarPromocion(string titulo, string descripcion, decimal ahorro)
        {
            promocion pro = new promocion();
            pro.titulo = titulo;
            pro.descripcion = descripcion;
            pro.ahorro = ahorro;

            dbc.promocion.Add(pro);
            int affected = dbc.SaveChanges();
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

        #endregion

        #region PROVEEDORES
        public ActionResult Proveedores()
        {
            ViewBag.Proveedores = dbc.proveedor.ToList();
            return View();
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

        #endregion

        #region SUCURSALES
        public ActionResult Sucursales()
        {
            ViewBag.Sucursales = dbc.sucursal.ToList();
            return View();
        }

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


        #endregion

        #region TIPODEMEDICAMENTO
        public ActionResult TipoMedicamentos()
        {
            ViewBag.TipoMedicamentos = dbc.tipo_medicamento.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult InsertarTipoMedicamento(string tipo, string descripcion, string expedicion, string expiracion )
        {
            tipo_medicamento pro = new tipo_medicamento();
            pro.tipo_medicamento1 = tipo;
            pro.descripcion = descripcion;
            pro.fecha_expedicion = expedicion;
            pro.fecha_vencimiento = expiracion;

            dbc.tipo_medicamento.Add(pro);
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarTipoMedicamento(int id)
        {
            dbc.tipo_medicamento.Remove(dbc.tipo_medicamento.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarTipoMedicamento(int id, string tipo, string descripcion, string expedicion, string expiracion)
        {
            tipo_medicamento pro = this.dbc.tipo_medicamento.Find(id);
            pro.tipo_medicamento1 = tipo;
            pro.descripcion = descripcion;
            pro.fecha_expedicion = expedicion;
            pro.fecha_vencimiento = expiracion;

            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        #endregion

        #region TIPODEVENTAS
        public ActionResult TipoVentas()
        {
            ViewBag.Ventas = dbc.tipo_venta.ToList();
            return View();
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

        #endregion


    }
}