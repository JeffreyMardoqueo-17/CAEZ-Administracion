using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly EncargadoBL _encargadoBL;

        public EncargadoController()
        {
            _encargadoBL = new EncargadoBL();
        }

        // GET: EncargadoController
        public async Task<ActionResult> Index()
        {
            List<Encargado> listaEncargados = await EncargadoBL.GetAllAsync();

            return View(listaEncargados);
        }

        // GET: EncargadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncargadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Encargado encargado)
        {
            try
            {
                // Obtener el Id del usuario logueado
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Asignar el Id del usuario logueado al encargado
                encargado.IdAdministrador = Convert.ToInt32(userId);
                encargado.FechaRegistro = DateTime.Now;

                int result = await EncargadoBL.CreateAsync(encargado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(encargado);
            }
        }

        // GET: EncargadoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var encargado = await EncargadoBL.GetByIdAsync(new Encargado { Id = id });
            return View(encargado);
        }

        // POST: EncargadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Encargado encargado)
        {
            try
            {
                int result = await EncargadoBL.UpdateAsync(encargado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(encargado);
            }
        }

        // GET: EncargadoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var encargado = await EncargadoBL.GetByIdAsync(new Encargado { Id = id });
            return View(encargado);
        }

        // POST: EncargadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Encargado encargado)
        {
            try
            {
                int result = await EncargadoBL.DeleteAsync(encargado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(encargado);
            }
        }
    }
}
