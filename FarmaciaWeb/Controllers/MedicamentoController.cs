using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Controllers
{
    public class MedicamentoController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        [HttpPost]
        public JsonResult InsertarMedicamento(medicamento med)
        {
            dbc.medicamento.Add(med);
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult EliminarMedicamento(int id)
        {
            dbc.medicamento.Remove(dbc.medicamento.Find(id));
            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        [HttpPost]
        public JsonResult ModificarMedicamento(medicamento med)
        {
            medicamento m = this.dbc.medicamento.Find(med.id_medicamento);
            m.nombre_medicamento = med.nombre_medicamento;
            m.fk_tipo_medicamento = med.fk_tipo_medicamento;
            m.costo_med = med.costo_med;
            m.unidades = med.unidades;
            m.fecha_expedicion = med.fecha_expedicion;
            m.fecha_vencimiento = med.fecha_vencimiento;

            int affected = dbc.SaveChanges();
            return Json(affected > 0);
        }

        public List<SelectListItem> getComboTMedicamentos()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (tipo_medicamento med in dbc.tipo_medicamento.ToList())
            {
                items.Add(new SelectListItem() { Value = med.id_tipo_medicamento.ToString(), Text = med.tipo_medicamento1 });
            }
            return items;
        }

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<medicamento> m = dbc.medicamento.ToList();
            foreach (object obj in m)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}