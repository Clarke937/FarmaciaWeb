using System.Web.Mvc;
using FarmaciaWeb.Models;
using FarmaciaWeb.Observer;
using FarmaciaWeb.Strategy;

namespace FarmaciaWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        ObtenerDatosCtx odc = new ObtenerDatosCtx();
        public ActionResult Index()
        {
            return View();
        }

        #region PROMOCIONES
        public ActionResult Promociones()
        {
            odc.ObtenerDatosP();
            ViewBag.Promociones = odc.SetDatos();
            return View();
        }
        #endregion

        #region PROVEEDORES
        public ActionResult Proveedores()
        {
            odc.ObtenerDatosPro();
            ViewBag.Proveedores = odc.SetDatos();
            return View();
        }
        #endregion

        #region SUCURSALES
        public ActionResult Sucursales()
        {
            odc.ObtenerDatosS();
            ViewBag.Sucursales = odc.SetDatos();
            return View();
        }
        #endregion

        #region TIPODEMEDICAMENTO
        public ActionResult TipoMedicamentos()
        {
            odc.ObtenerDatosTM();
            ViewBag.TipoMedicamentos = odc.SetDatos();
            return View();
        }
        #endregion

        #region TIPODEVENTAS
        public ActionResult TipoVentas()
        {
            odc.ObtenerDatosTV();
            ViewBag.Ventas = odc.SetDatos();
            return View();
        }
        #endregion
    }
}