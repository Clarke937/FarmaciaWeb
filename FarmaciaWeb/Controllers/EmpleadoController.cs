using CryptSharp;
using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using FarmaciaWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{
    public class EmpleadoController : Controller, IObtenerDatos
    {
        private arqfarmaciaEntities dbc = new arqfarmaciaEntities();
        private CheckLogin chk = new CheckLogin();
        // GET: Empleado
        public ActionResult NuevoEmpleado()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");


            if (Session["estado"] != null) ViewBag.creado = true;
            else ViewBag.creado = null;

            ViewBag.sucursales = getComboSucursales();
            ViewBag.Generos = getGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Registro_Empleado lr)
        {
            login login = new login();
            login.usuario = lr.usuario;
            login.contrasenia = Crypter.MD5.Crypt(lr.contrasenia);
            login.fk_nivel = 2;
            //
            dbc.login.Add(login);
            dbc.SaveChanges();
            //
            registro registro = new registro();
            registro.nombres = lr.nombres;
            registro.apellidos = lr.apellidos;
            registro.dui = lr.dui;
            registro.nit = lr.nit;
            registro.direccion = lr.direccion;
            registro.genero = getGeneros()[lr.genero].Value;
            registro.edad = lr.edad;
            registro.fecha_registro = DateTime.Now.Date.ToShortDateString();
            registro.fk_login = login.id_login;
            //
            dbc.registro.Add(registro);
            dbc.SaveChanges();
            //
            vendedor vendedor = new vendedor();
            vendedor.carnet = lr.carnet;
            vendedor.salario = lr.salario;
            vendedor.fk_sucursal = lr.sucursal;
            vendedor.fk_registro = registro.id_registro;
            //
            dbc.vendedor.Add(vendedor);
            dbc.SaveChanges();

            Session["estado"] = true;
            return RedirectToAction("NuevoEmpleado", "Empleado");
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                vendedor vendedor = dbc.vendedor.Where(x => x.id_vendedor == id).FirstOrDefault();
                if(vendedor != null)
                {
                    registro registro = dbc.registro.Where(x => x.id_registro == vendedor.fk_registro).FirstOrDefault();
                    if (registro != null)
                    {
                        login login = dbc.login.Where(x => x.id_login == registro.fk_login).FirstOrDefault();
                        if (login != null)
                        {
                            dbc.vendedor.Remove(vendedor);
                            dbc.registro.Remove(registro);
                            dbc.login.Remove(login);
                            dbc.SaveChanges();
                        }
                    }
                }
                return Json( new { success = true, msg = "Eliminado con exito!"},JsonRequestBehavior.AllowGet);
            } 
            catch(Exception ex)
            {
                return Json(new { success = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public List<SelectListItem> getGeneros()
        {
            List<SelectListItem> generos = new List<SelectListItem>();
            generos.Add(new SelectListItem() { Value = "0", Text = "Seleccionar" });
            generos.Add(new SelectListItem() { Value = "1", Text = "Masculino" });
            generos.Add(new SelectListItem() { Value = "2", Text = "Femenino" });
            generos.Add(new SelectListItem() { Value = "3", Text = "Otro" });
            return generos;
        }

        public List<SelectListItem> getComboSucursales()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (sucursal med in dbc.sucursal.ToList())
            {
                items.Add(new SelectListItem() { Value = med.id_sucursal.ToString(), Text = med.nombre_sucursal });
            }
            return items;
        }

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<vendedor> m = dbc.vendedor.ToList();
            foreach (object obj in m)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}