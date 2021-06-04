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


namespace FarmaciaWeb.Factory
{
    public class ReporteEmpleado : ReportesFarmacia
    {
        public override string generarReporte()
        {
            return "/Rpts/Empleados/EmpleadosReport.rpt";
        }
    }
}