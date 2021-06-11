using System.Collections.Generic;
using System.Web;


namespace FarmaciaWeb.Composite
{
    public class KitMedicamentos : MedicamentosComponent
    {
        protected List<MedicamentosComponent> _medicamento = new List<MedicamentosComponent>();

        public KitMedicamentos(int id, string nombre, decimal costo = 0, decimal desc = 0, int cant = 0) : base(id, nombre, costo, desc, cant)
        {
        }

        public decimal CostoTotal
        {
            get
            {
                decimal costoT = 0;
                foreach(var medicamento in _medicamento)
                {
                    costoT += medicamento.costo;
                }
                return costoT;
            }
        }

        public decimal AhorroTotal
        {
            get
            {
                decimal ahorro = 0;
                foreach (var medcicamento in _medicamento)
                {
                    ahorro += medcicamento.descuento;
                }
                return ahorro;
            }
        }

        public int CantidadTotal
        {
            get
            {
                int cantidad = 0;
                foreach (var medcicamento in _medicamento)
                {
                    cantidad += medcicamento.cantidad;
                }
                return cantidad;
            }
        }

        public override void Add(MedicamentosComponent component)
        {
            _medicamento = GetMedicamentos();
            int index = _medicamento.FindIndex(x => x.idMed == component.idMed);
            if (index >= 0)
            {
                this._medicamento[index].descuento = component.descuento;
                this._medicamento[index].cantidad = component.cantidad;
                this._medicamento[index].costo = component.costo;
            }
            else { 
            this._medicamento.Add(component);
            }
            HttpContext.Current.Session["medicamentos"] = _medicamento;
        }

        public override void Remove(MedicamentosComponent component)
        {
            if (HttpContext.Current.Session["medicamentos"] != null)
            {
                _medicamento = GetMedicamentos();
                int index = _medicamento.FindIndex(x => x.idMed == component.idMed);
                if (index >= 0)
                {
                    this._medicamento.RemoveAt(index);
                    HttpContext.Current.Session["medicamentos"] = _medicamento;
                }
            }
        }

        public override void Cancelar()
        {
            HttpContext.Current.Session["medicamentos"] = null;
        }

        public List<MedicamentosComponent> GetMedicamentos()
        {
            if (HttpContext.Current.Session["medicamentos"] != null)
            {
                _medicamento = (List<MedicamentosComponent>)HttpContext.Current.Session["medicamentos"];
            }
            return _medicamento;
        }
    }
}