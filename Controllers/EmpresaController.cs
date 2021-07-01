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
        certame3Entities2 certamenCtx = new certame3Entities2();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(certamenCtx.Empresas);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            Empresa empresa = certamenCtx.Empresas.Find(id);

            if (empresa != null)
            {
                return View(empresa);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la empresa para ver detalles"), "Empresa", "Index"));
            }
        }

        public ActionResult Update(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            Empresa empresa = certamenCtx.Empresas.Find(id);

            if (empresa != null)
            {
                return View(empresa);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la empresa para editar"), "Empresa", "Index"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Empresa found = certamenCtx.Empresas.Find(empresa.Id);
                found.Popularidad = empresa.Popularidad;
                found.Fecha = empresa.Fecha;
                found.Descripcion = empresa.Descripcion;
                found.Correo = empresa.Correo;
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Empresa", "Index"));
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            Empresa empresa = certamenCtx.Empresas.Find(id);

            if (empresa != null)
            {
                return View(empresa);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception("No se ha encontrado a la empresa para eliminar"), "Empresa", "Index"));
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            try
            {
                Empresa found = certamenCtx.Empresas.Find(id);
                certamenCtx.Empresas.Remove(found);
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View("Error", new HandleErrorInfo(e, "Empresa", "Index"));
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                certamenCtx.Empresas.Add(empresa);
                certamenCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View("Error", new HandleErrorInfo(e, "Empresa", "Index"));
            }
        }
    }
}