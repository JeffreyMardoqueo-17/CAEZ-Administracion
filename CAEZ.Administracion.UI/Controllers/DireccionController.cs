using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class DireccionController : Controller
    {
        private readonly DireccionBL _direcBD;

        public DireccionController()
        {
            _direcBD = new DireccionBL(); // Inicializamos la capa de negocio
        }

        // GET: DireccionController
        public async Task<ActionResult> Index()
        {
            List<Direccion> Lista = await _direcBD.GetAllAsync();

            return View(Lista);
        }

        // GET: DireccionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var direccion = await _direcBD.GetById(new Direccion { Id = id });
            return PartialView("Details", direccion);
        }

        // GET: DireccionController/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: DireccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Direccion direccion)
        {
            try
            {
                int result = await _direcBD.CreateAsync(direccion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", direccion);
            }
        }

        // GET: DireccionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var direccion = await _direcBD.GetById(new Direccion { Id = id });
            return PartialView("Edit", direccion);
        }

        // POST: DireccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Direccion direccion)
        {
            try
            {
                int result = await _direcBD.UpdateAsync(direccion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(direccion);
            }
        }

        // GET: DireccionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var direccion = await _direcBD.GetById(new Direccion { Id = id });
            return PartialView("Delete", direccion);

        }

        // POST: DireccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Direccion direccion)
        {
            try
            {
                await _direcBD.DeleteAsync(direccion);
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
