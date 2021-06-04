using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Strategy
{
    interface IObtenerDatos
    {
        List<Object> GetDatos();
    }
}