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
        Certame3Context certamenCtx = new Certame3Context();

        // GET: Persona
        public ActionResult Index()
        {
            return View(certamenCtx.Personas);
        }

        public ActionResult Detail(string id)
        {
            Persona persona = certamenCtx.Personas.Find(Persona.DigitsToRut(id));

            if (persona != null)
            {
                return View(persona);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la persona para ver detalles"), "Persona", "Index"));
            }
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
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la persona para editar"), "Persona", "Index"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Persona persona, string prerut)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Persona found = certamenCtx.Personas.Find(prerut);
                if(found == null) return View("Error", new HandleErrorInfo(new Exception("Found is null"), "Persona", "Index"));

                if (prerut.Equals(persona.Rut))
                {
                    found.Nombres = persona.Nombres;
                    found.Fecha = persona.Fecha;
                    found.Edad = persona.Edad;
                }
                else
                {
                    certamenCtx.Personas.Remove(found);
                    certamenCtx.Personas.Add(persona);
                }
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
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la persona para eliminar"), "Persona", "Index"));
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                persona.Rut = Persona.DigitsToRut(persona.RutOnlyDigits);

                if (certamenCtx.Personas.Find(persona.Rut) != null) throw new Exception("El rut ya existe");

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