using IgnacioQuinteros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IgnacioQuinteros.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            var certamen = new certame3Entities2();
            return View(certamen.Personas);
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