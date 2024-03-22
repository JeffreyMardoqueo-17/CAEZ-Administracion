using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CAEZ.Administracion.UI.Controllers
{

    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class TipoDocumentoController : Controller
    {
        private readonly TipoDocumentoBL _tdocumentBL;

        public TipoDocumentoController()
        {
            _tdocumentBL = new TipoDocumentoBL(); // Inicializamos la capa de negocio
        }

        public async Task<ActionResult> Index()
        {
            List<TipoDocumento> Lista = await _tdocumentBL.GetAllAsync();
            return View(Lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var tdocument = await _tdocumentBL.GetById(new TipoDocumento { Id = id });
            return PartialView("Details", tdocument);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

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

        public async Task<ActionResult> Edit(int id)
        {
            var tdocumento = await _tdocumentBL.GetById(new TipoDocumento { Id = id });
            return PartialView("Edit", tdocumento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TipoDocumento tipodocumento)
        {
            try
            {
                int result = await _tdocumentBL.UpdateAsync(tipodocumento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipodocumento);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var tdocument = await _tdocumentBL.GetById(new TipoDocumento { Id = id });
            return PartialView("Delete", tdocument);
        }

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
