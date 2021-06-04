using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmaciaWeb.Controllers;

namespace FarmaciaWeb.Factory
{
    public abstract class ReportesFarmacia 
    {
        public abstract string generarReporte();
    }
}