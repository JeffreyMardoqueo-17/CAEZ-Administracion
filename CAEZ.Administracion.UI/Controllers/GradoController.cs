using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
    public class GradoController : Controller
    {
        private readonly GradoBL _gradoBL;

        // GET: GradoController
          public async Task<ActionResult> Index()
        {
            List<Grado> Lista = await _gradoBL.GetAllAsync();

            return View(Lista);
        }

        // GET: GradoController/Details/5
        public async Task<ActionResult> DetailsPartial(int id)
        {
            var grado = await _gradoBL.GetById(new Grado { Id = id });
            return PartialView("Details", grado);
        }

        // GET: GradoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Grado grado)
        {
            try
            {
                int result = await _gradoBL.CreateAsync(grado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", grado);
            }
        }

        // GET: GradoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var grado = await _gradoBL.GetById(new Grado { Id = id });
            return PartialView("Edit", grado);
        }


        // POST: GradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Grado grado)
        {
            try
            {
                int result = await _gradoBL.UpdateAsync(grado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(grado);
            }
        }

        // GET: GradoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GradoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Grado grado)
        {
            try
            {
                await _gradoBL.DeleteAsync(grado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(grado);
            }
        }
    }
    
}
