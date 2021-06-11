using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Composite
{
    public abstract class MedicamentosComponent
    {

        public int idMed { get; set; }
        public string nombreMed { get; set; }
        public decimal costo { get; set; }
        [Required(ErrorMessage = "Debe ingresar un descuento", AllowEmptyStrings = false)]
        [RegularExpression("^\\d+$", ErrorMessage = "Solo se permiten números")]
        public decimal descuento { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Range(1,int.MaxValue, ErrorMessage = "Cantidad debe ser mayor a 0")]
        public int cantidad { get; set; }
        public MedicamentosComponent(int id, string nombre, decimal costo, decimal desc, int cant)
        {
            this.idMed = id;
            this.nombreMed = nombre;
            this.costo = costo;
            this.descuento = desc;
            this.cantidad = cant;
        }

        public MedicamentosComponent(int id)
        {
            this.idMed = id;
        }

        public virtual void Add(MedicamentosComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(MedicamentosComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void Cancelar()
        {
            throw new NotImplementedException();

        }
    }
}