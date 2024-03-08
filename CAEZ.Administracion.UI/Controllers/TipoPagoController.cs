using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class TipoPagoController : Controller
    {
        private readonly TipoPagoBL _tpagoBL;
        // GET: TipoPagoController
        public async Task<ActionResult> Index()
        {
            List<TipoPago> Lista = await _tpagoBL.GetAllAsync();

            return View(Lista);
        }

        // GET: TipoPagoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tpago = await _tpagoBL.GetById(new TipoPago { Id = id });
            return PartialView("Details", tpago);
        }


        // GET: TipoPagoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagoController/Create
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


        // GET: TipoPagoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tpago = await _tpagoBL.GetById(new TipoPago { Id = id });
            return PartialView("Edit", tpago);
        }

        // POST: TipoPagoController/Edit/5
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

        // GET: TipoPagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoPagoController/Delete/5
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
