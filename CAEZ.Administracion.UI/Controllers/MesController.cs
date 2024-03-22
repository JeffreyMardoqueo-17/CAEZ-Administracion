using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CAEZ.Administracion.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Administrador")]
    public class MesController : Controller
    {
        private readonly MesBL _mesBL;

        public MesController()
        {
            _mesBL = new MesBL(); // Inicializamos la capa de negocio
        }
        // GET: MesController
        public async Task<ActionResult> Index()
        {
            List<Mes> Lista = await _mesBL.GetAllAsync();

            return View(Lista);
        }
    }
}
