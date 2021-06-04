using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Observer
{
    public interface IRegistros
    {
        void Update(int idRes, int idNotify);
    }
    
    public interface ISujeto
    {
        void Activar(registro registros);
        void Desactivar(registro registros);
        void Notificar();
    }
}