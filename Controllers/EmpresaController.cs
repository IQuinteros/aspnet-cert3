using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IgnacioQuinteros.Models;

namespace IgnacioQuinteros.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            var certamen = new certame3Entities2();
            return View(certamen.Empresas);
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }
    }
}