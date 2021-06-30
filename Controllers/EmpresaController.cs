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

        public ActionResult Update(int id)
        {
            Empresa empresa = certamenCtx.Empresas.Find(id);

            if (empresa != null)
            {
                return View(empresa);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception(), "Empresa", "Index"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Empresa empresa)
        {
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

        public ActionResult Delete(int id)
        {
            Empresa empresa = certamenCtx.Empresas.Find(id);

            if (empresa != null)
            {
                return View(empresa);
            }
            else
            {
                return View("Error", new HandleErrorInfo(new Exception(), "Empresa", "Index"));
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
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