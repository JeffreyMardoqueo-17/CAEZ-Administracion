using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CAEZ.Administracion.UI.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly EncargadoBL _encargadoBL;

        public EncargadoController()
        {
            _encargadoBL = new EncargadoBL();
        }

        // GET: Encargado/Index
        public async Task<ActionResult> Index()
        {
            List<Encargado> listaEncargados = await _encargadoBL.ObtenerTodosLosEncargadosAsync();
            return View(listaEncargados);
        }

        // GET: Encargado/Crear
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encargado/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Encargado encargado)
        {
            try
            {
                // Obtener el Id del usuario logueado
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Asignar el Id del usuario logueado al encargado
                encargado.IdAdministrador = int.Parse(userId);

                int resultado = await _encargadoBL.CrearEncargadoAsync(encargado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(encargado);
            }
        }

        // GET: Encargado/Editar/5
        public async Task<ActionResult> Edit(int id)
        {
            Encargado encargado = await _encargadoBL.ObtenerEncargadoPorIdAsync(id);
            return View(encargado);
        }

        // POST: Encargado/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Encargado encargado)
        {
            try
            {
                int resultado = await _encargadoBL.ActualizarEncargadoAsync(encargado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(encargado);
            }
        }

        // GET: Encargado/Eliminar/5
        public async Task<ActionResult> Delete(int id)
        {
            Encargado encargado = await _encargadoBL.ObtenerEncargadoPorIdAsync(id);
            return View(encargado);
        }

        // POST: Encargado/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Encargado encargado)
        {
            try
            {
                int resultado = await _encargadoBL.EliminarEncargadoAsync(encargado);
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