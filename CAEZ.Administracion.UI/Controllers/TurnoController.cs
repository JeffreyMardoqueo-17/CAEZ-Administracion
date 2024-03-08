using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnoBL _turnoBL;

        // GET: CargoController
        public async Task<ActionResult> Index()
        {
            List<Turno> Lista = await _turnoBL.GetAllAsync();

            return View(Lista);
        }

        // GET: CargoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cargo = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Details", cargo);
        }

        // GET: CargoController/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: CargoController/Create
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

        // GET: CargoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var turno = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Edit", turno);
        }

        // POST: CargoController/Edit/5
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

        // GET: CargoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var turno = await _turnoBL.GetById(new Turno { Id = id });
            return PartialView("Delete", turno);

        }

        // POST: CargoController/Delete/5
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
