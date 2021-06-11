using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Models
{
    public class ReportesConexion
    {
        public static CrystalDecisions.Shared.ConnectionInfo getConexion()
        {
            CrystalDecisions.Shared.ConnectionInfo infocon = new CrystalDecisions.Shared.ConnectionInfo();
            infocon.ServerName = @"DESKTOP-9IECHGT";
            infocon.DatabaseName = "neptuno";
            infocon.IntegratedSecurity = true;

            return infocon;
        }
    }
}