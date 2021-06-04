using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Factory
{
    public class ReporteProveedor : ReportesFarmacia
    {
        public override string generarReporte()
        {
            return "/Rpts/Proveedores/ProveedoresReport.rpt";
        }
    }
}