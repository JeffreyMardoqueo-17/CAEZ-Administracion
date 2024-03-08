using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly TipoDocumentoBL _tdocumentBL;
        // GET: TipoDocumentoController
        public async Task<ActionResult> Index()
        {
            List<TipoDocumento> Lista = await _tdocumentBL.GetAllAsync();

            return View(Lista);
        }

        // GET: TipoDocumentoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tdocument = await _tdocumentBL.GetById(new TipoDocumento { Id = id });
            return PartialView("Details", tdocument);
        }


        // GET: TipoDocumentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TipoDocumento tipoDocumento)
        {
            try
            {
                int result = await _tdocumentBL.CreateAsync(tipoDocumento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", tipoDocumento);
            }
        }

        // GET: TipoDocumentoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tdocumento = await _tdocumentBL.GetById(new TipoDocumento { Id = id });
            return PartialView("Edit", tdocumento);
        }


        // POST: TipoDocumentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TipoDocumento tipodocumet)
        {
            try
            {
                int result = await _tdocumentBL.UpdateAsync(tipodocumet);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipodocumet);
            }
        }

        // GET: TipoDocumentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDocumentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TipoDocumento tdocumento)
        {
            try
            {
                await _tdocumentBL.DeleteAsync(tdocumento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tdocumento);
            }
        }
    }
}
