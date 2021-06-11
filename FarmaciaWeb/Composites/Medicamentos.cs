using FarmaciaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Composite
{
    public class Medicamentos : MedicamentosComponent
    {
        public Medicamentos(int id, string nombre, decimal costo, decimal desc, int cant) 
            : base(id, nombre, costo, desc, cant)
        {

        }

        public Medicamentos (int id) : base(id)
        {

        }
    }
}