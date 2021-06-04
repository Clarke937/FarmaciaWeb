using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Factory;

namespace FarmaciaWeb.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Reportes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VerReporte(string tipo)
        {
            var reporte = new ReportClass();
            ReportesFarmacia rf = CreadorObjetos.AsignarTipo(tipo);
            string ruta = rf.generarReporte();
            reporte.FileName = Server.MapPath(ruta);

            //Conexion para el reporte
            var coninfo = ReportesConexion.getConexion();
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            Tables tables;
            tables = reporte.Database.Tables;
            foreach (Table item in tables)
            {
                logoninfo = item.LogOnInfo;
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = reporte.ExportToStream(ExportFormatType.PortableDocFormat);

            return new FileStreamResult(stream, "application/pdf");            
        }
    }
}