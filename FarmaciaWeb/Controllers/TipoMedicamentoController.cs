using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Strategy;

namespace FarmaciaWeb.Controllers
{
    public class TipoMedicamentoController : Controller, IObtenerDatos
    {
        arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        public List<tipo_medicamento> ObtenerTMedicamento()
        {
            return dbc.tipo_medicamento.ToList();
        }

        [HttpPost]
        public JsonResult InsertarTipoMedicamento(string tipo, string descripcion, string expedicion, string expiracion)
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

        public List<object> GetDatos()
        {
            List<object> list = new List<object>();
            List<tipo_medicamento> tm = dbc.tipo_medicamento.ToList();
            foreach (object obj in tm)
            {
                list.Add(obj);
            }
            return list;
        }
    }
}