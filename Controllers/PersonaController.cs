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
        certame3Entities2 certamenCtx = new certame3Entities2();

        // GET: Persona
        public ActionResult Index()
        {
            return View(certamenCtx.Personas);
        }

        public ActionResult Update(string id)
        {
            Persona persona = certamenCtx.Personas.Find(Persona.DigitsToRut(id));

            if(persona != null)
            {
                return View(persona);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception(), "Persona", "Index"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Persona persona)
        {
            try
            {
                Persona found = certamenCtx.Personas.Find(persona.Rut);
                found.Nombres = persona.Nombres;
                found.Fecha = persona.Fecha;
                found.Edad = persona.Edad;
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            } catch(Exception e) {
                return View("Error", new HandleErrorInfo(e, "Persona", "Index"));
            }
        }

        public ActionResult Delete(string id)
        {
            Persona persona = certamenCtx.Personas.Find(Persona.DigitsToRut(id));

            if (persona != null)
            {
                return View(persona);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception(), "Persona", "Index"));
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string Rut)
        {
            try
            {
                Persona found = certamenCtx.Personas.Find(Rut);
                certamenCtx.Personas.Remove(found);
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View("Error", new HandleErrorInfo(e, "Persona", "Index"));
            }
        }


        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Persona persona)
        {
            try
            {
                persona.Rut = Persona.DigitsToRut(persona.RutOnlyDigits);
                certamenCtx.Personas.Add(persona);
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View("Error", new HandleErrorInfo(e, "Persona", "Index"));
            }
        }
    }
}