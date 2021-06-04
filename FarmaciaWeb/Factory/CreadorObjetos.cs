using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaWeb.Factory
{
    public class CreadorObjetos
    {
        public static ReportesFarmacia AsignarTipo(string tipo)
        {
            switch (tipo)
            {
                case "empleado":
                    return new ReporteEmpleado();

                case "medicamento":
                    return new ReporteMedicamento();

                case "proveedor":
                    return new ReporteProveedor();

                default: return null;
            }
        }
    }
}