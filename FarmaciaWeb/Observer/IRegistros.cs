using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Observer
{
    public interface IRegistros
    {
        void Update(int idC, int idNotify);
    }
    
    public interface ISujeto
    {
        void Activar(cliente cliente);
        void Desactivar(cliente cliente);
        void Notificar();
    }
}