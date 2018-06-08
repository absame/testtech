using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen.UI.Servicios.Cliente;

namespace Examen.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerCliente()
        {
            ServiceClient servicioWCF = new ServiceClient();

            try
            {
                return this.Json(servicioWCF.ObtenerCliente(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                servicioWCF.Abort();
                throw;
            }
            finally
            {
                servicioWCF.Close();
            } 
        }

        public JsonResult GuardarCliente(Cliente cliente)
        {
            ServiceClient servicioWCF = new ServiceClient();

            try
            {
                return this.Json(servicioWCF.GuardarCliente(cliente), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                servicioWCF.Abort();
                throw;
            }
            finally
            {
                servicioWCF.Close();
            } 
        }

        public JsonResult EliminarCliente(Cliente cliente)
        {
            ServiceClient servicioWCF = new ServiceClient();

            try
            {
                return this.Json(servicioWCF.EliminarCliente(cliente.ClienteId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                servicioWCF.Abort();
                throw;
            }
            finally
            {
                servicioWCF.Close();
            } 
        }
    }
}