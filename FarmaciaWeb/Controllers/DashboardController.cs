using System.Web.Mvc;
using FarmaciaWeb.Models;
using FarmaciaWeb.Strategy;
using FarmaciaWeb.Utilidades;

namespace FarmaciaWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        private CheckLogin chk = new CheckLogin();
        private arqfarmaciaEntities dbc = new arqfarmaciaEntities();

        //Variable para acceder a los datos obtenido desde el patron Strategy
        private ObtenerDatosCtx odc = new ObtenerDatosCtx();

        public ActionResult Index()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            return View();
        }

        #region PROMOCIONES
        public ActionResult Promociones()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            //Aca selecciono los datos de que estrategia quiero
            odc.ObtenerDatosP();
            //Aca los recibo
            //Posdata cada uno de las demas ActionResult aca funciona asi
            ViewBag.Promociones = odc.SetDatos();
            return View();
        }
        #endregion

        #region PROVEEDORES
        public ActionResult Proveedores()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosPro();
            ViewBag.Proveedores = odc.SetDatos();
            return View();
        }
        #endregion

        #region SUCURSALES
        public ActionResult Sucursales()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosS();
            ViewBag.Sucursales = odc.SetDatos();
            return View();
        }
        #endregion

        #region TIPODEMEDICAMENTO
        public ActionResult TipoMedicamentos()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosTM();
            ViewBag.TipoMedicamentos = odc.SetDatos();
            return View();
        }
        #endregion

        #region TIPODEVENTAS
        public ActionResult TipoVentas()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosTV();
            ViewBag.Ventas = odc.SetDatos();
            return View();
        }
        #endregion

        #region KIT
        public ActionResult Kit()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosKit();
            ViewBag.kit = odc.SetDatos();
            return View();
        }
        #endregion

        #region MEDICAMENTOS
        public ActionResult Medicamentos()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosMed();
            ViewBag.Medicamentos = odc.SetDatos();
            ViewBag.tmedicamentos = new MedicamentoController().getComboTMedicamentos();
            return View();
        }
        #endregion

        #region REPORTES
        public ActionResult Reporte()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            return View();
        }

        #endregion
          
        #region EMPLEADOS
        public ActionResult Empleado()
        {
            if (!chk.ValidarLogin()) return RedirectToAction("Index", "Home");

            odc.ObtenerDatosEmp();
            ViewBag.Empleados = odc.SetDatos();
            return View();
        }
        #endregion
    }
}