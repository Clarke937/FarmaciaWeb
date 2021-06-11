using FarmaciaWeb.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using FarmaciaWeb.Observer;
using FarmaciaWeb.Utilidades;

namespace FarmaciaWeb.Controllers
{
    public class KitController : Controller, IObtenerDatos
    {
        private CheckLogin chk = new CheckLogin();
        private arqfarmaciaEntities dbc = new arqfarmaciaEntities();
        private Sujeto sujeto = new Sujeto();
        private string Titulo = "";
        private int idKit = 0;
        public ActionResult Kit()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            KitMedicamentos km = new KitMedicamentos(1,null);
            ViewBag.medicamentos = km.GetMedicamentos();
            ViewBag.list_med = getComboMedicamentos();
            ViewBag.costoT = km.CostoTotal - km.AhorroTotal;
            ViewBag.ahortoT = km.AhorroTotal;
            ViewBag.cantidadT = km.CantidadTotal;
            return View();
        }

        //Metodo que recibe los datos para ser enviado al Composite
        [HttpPost]
        public JsonResult Kit(int id, int cantidad, int tipo, decimal ahorro )
        {
            try
            {             
                List<object> obj = new List<object>();
                decimal costoT = 0;
                var med = dbc.medicamento.Find(id);

                obj.Add(id);
                obj.Add(med.nombre_medicamento);
                obj.Add(costoT = (decimal)(cantidad * med.costo_med));
                if (tipo == 1) ahorro *= costoT;
                obj.Add(ahorro);
                obj.Add(cantidad);
                //Llama al metodo
                Agregar(obj);

                return Json(new { success = true, msg = "La dirección ha sido eliminada de su catalogo." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex }, JsonRequestBehavior.AllowGet);
            }
        }

        //Aca agrega el objeto
        private void Agregar(List<object> obj)
        {
            Medicamentos med = new Medicamentos(int.Parse(obj[0].ToString()), obj[1].ToString(),decimal.Parse(obj[2].ToString()), decimal.Parse(obj[3].ToString()), int.Parse(obj[4].ToString()));
            KitMedicamentos km = new KitMedicamentos(idKit,Titulo);
            km.Add(med);
        }


        //Aca eliminamos los objetos dentro de la liste composite
        [HttpPost]
        public JsonResult Eliminar(int id)
        {            
            try
            {
                Medicamentos med = new Medicamentos(id);
                KitMedicamentos km = new KitMedicamentos(idKit, Titulo);
                km.Remove(med); return Json(new { success = true, msg = "La dirección ha sido eliminada de su catalogo." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex }, JsonRequestBehavior.AllowGet);
            }
        }

        //Aca limpia la lista composita
        [HttpPost]
        public ActionResult Cancelar()
        {
            KitMedicamentos km = new KitMedicamentos(idKit, Titulo);
            km.Cancelar();
            return RedirectToAction("Kit", "Dashboard");
        }


        //Con este recuperamos los datos del composite y guarda en la base
        [HttpPost]
        public JsonResult Finalizar(kit kit)
        {
            try
            {
                //Creando kit
                dbc.kit.Add(kit);
                dbc.SaveChanges();
                int idK = kit.id_kit;
                KitMedicamentos km = new KitMedicamentos(idK, kit.nombre);
                foreach (Medicamentos med in km.GetMedicamentos())
                {
                    detalles_kit dk = new detalles_kit();
                    dk.fk_kit = idK;
                    dk.fk_medicamento = med.idMed;
                    dk.descuento = med.descuento;
                    dk.costo_total = med.costo;
                    dk.cantidad = med.cantidad;
                    dbc.detalles_kit.Add(dk);
                    dbc.SaveChanges();
                }
                sujeto.CrearNotificacion(kit.nombre,kit.descripcion,kit.costo);
                return Json(new { success = true, msg = "Datos guardados" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EliminarKit(int id)
        {
            List<detalles_kit> dk = dbc.detalles_kit.Where(x => x.fk_kit == id).ToList();
            foreach(detalles_kit d in dk)
            {
                dbc.detalles_kit.Remove(dbc.detalles_kit.FirstOrDefault(x => x.fk_kit == d.fk_kit));
                dbc.SaveChanges();
            }
            dbc.kit.Remove(dbc.kit.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        private List<SelectListItem> getComboMedicamentos()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(medicamento med in dbc.medicamento.ToList())
            {
                items.Add(new SelectListItem() { Value = med.id_medicamento.ToString(), Text = med.nombre_medicamento });
            }
            return items;
        }

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<kit> kt = dbc.kit.ToList();
            foreach (object obj in kt)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}