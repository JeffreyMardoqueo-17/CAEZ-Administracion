using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAEZ.Administracion.UI.Controllers
{
    public class GradoController : Controller
    {
        private readonly GradoBL _gradoBL;

        public GradoController()
        {
            _gradoBL = new GradoBL(); // Inicializamos la capa de negocio
        }

        public async Task<ActionResult> Index()
        {
            List<Grado> Lista = await _gradoBL.GetAllAsync();
            return View(Lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var grado = await _gradoBL.GetById(new Grado { Id = id });
            return PartialView("Details", grado);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Grado grado)
        {
            try
            {
                int result = await _gradoBL.CreateAsync(grado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", grado);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var grado = await _gradoBL.GetById(new Grado { Id = id });
            return PartialView("Edit", grado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Grado grado)
        {
            try
            {
                int result = await _gradoBL.UpdateAsync(grado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(grado);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var grado = await _gradoBL.GetById(new Grado { Id = id });
            return PartialView("Delete", grado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _gradoBL.DeleteAsync(new Grado { Id = id });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(id);
            }
        }
    }
}
