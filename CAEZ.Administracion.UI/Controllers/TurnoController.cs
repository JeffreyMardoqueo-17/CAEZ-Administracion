using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAEZ.Administracion.UI.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnoBL _turnoBL;

        public TurnoController()
        {
            _turnoBL = new TurnoBL(); // Inicializamos la capa de negocio
        }

        public async Task<ActionResult> Index()
        {
            List<Turno> Lista = await _turnoBL.GetAllAsync();
            return View(Lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var turno = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Details", turno);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Turno turno)
        {
            try
            {
                int result = await _turnoBL.CreateAsync(turno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", turno);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var turno = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Edit", turno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Turno turno)
        {
            try
            {
                int result = await _turnoBL.UpdateAsync(turno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(turno);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var turno = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Delete", turno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Turno turno)
        {
            try
            {
                await _turnoBL.DeleteAsync(turno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(turno);
            }
        }
    }
}
