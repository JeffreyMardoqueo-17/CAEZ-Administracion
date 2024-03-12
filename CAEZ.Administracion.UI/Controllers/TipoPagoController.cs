using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAEZ.Administracion.UI.Controllers
{
    public class TipoPagoController : Controller
    {
        private readonly TipoPagoBL _tpagoBL;

        public TipoPagoController()
        {
            _tpagoBL = new TipoPagoBL(); // Inicializamos la capa de negocio
        }

        public async Task<ActionResult> Index()
        {
            List<TipoPago> Lista = await _tpagoBL.GetAllAsync();
            return View(Lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var tpago = await _tpagoBL.GetById(new TipoPago { Id = id });
            return PartialView("Details", tpago);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TipoPago tipopago)
        {
            try
            {
                int result = await _tpagoBL.CreateAsync(tipopago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", tipopago);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id)
        {
            var tpago = await _tpagoBL.GetById(new TipoPago { Id = id });
            return PartialView("Edit", tpago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TipoPago tipoPago)
        {
            try
            {
                int result = await _tpagoBL.UpdateAsync(tipoPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipoPago);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var tpago = await _tpagoBL.GetById(new TipoPago { Id = id });
            return PartialView("Delete", tpago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TipoPago tpago)
        {
            try
            {
                await _tpagoBL.DeleteAsync(tpago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tpago);
            }
        }
    }
}
