using FarmaciaWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaWeb.Strategy
{
    public class ObtenerDatosCtx
    {
        private IObtenerDatos obtenerDatos;

        public void ObtenerDatosP()
        {
            this.obtenerDatos = new PromocionesController();
        }

        public void ObtenerDatosPro()
        {
            this.obtenerDatos = new ProveedoresController();
        }
        public void ObtenerDatosS()
        {
            this.obtenerDatos = new SucursalesController();
        }
        public void ObtenerDatosTM()
        {
            this.obtenerDatos = new TipoMedicamentoController();
        }
        public void ObtenerDatosTV()
        {
            this.obtenerDatos = new TipoVentasController();
        }
        public void ObtenerDatosKit()
        {
            this.obtenerDatos = new KitController();
        }
        public void ObtenerDatosMed()
        {
            this.obtenerDatos = new MedicamentoController();
        }
        public void ObtenerDatosEmp()
        {
            this.obtenerDatos = new EmpleadoController();
        }

        public List<object> SetDatos()
        {
            return this.obtenerDatos.GetDatos();
        }
    }
}