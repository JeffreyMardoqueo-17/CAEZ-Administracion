using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CAEZ.Administracion.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class DireccionController : Controller
    {
        private readonly DireccionBL _direccionBL;

        public DireccionController()
        {
            _direccionBL = new DireccionBL(); // Inicializamos la capa de negocio
        }

        public async Task<ActionResult> Index()
        {
            List<Direccion> Lista = await _direccionBL.GetAllAsync();

            return View(Lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var direccion = await _direccionBL.GetById(new Direccion { Id = id });
            return PartialView("Details", direccion);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Direccion direccion)
        {
            try
            {
                int result = await _direccionBL.CreateAsync(direccion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", direccion);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var direccion = await _direccionBL.GetById(new Direccion { Id = id });
            return PartialView("Edit", direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Direccion direccion)
        {
            try
            {
                int result = await _direccionBL.UpdateAsync(direccion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(direccion);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var direccion = await _direccionBL.GetById(new Direccion { Id = id });
            return PartialView("Delete", direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Direccion direccion)
        {
            try
            {
                await _direccionBL.DeleteAsync(direccion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(direccion);
            }
        }
    }
}
