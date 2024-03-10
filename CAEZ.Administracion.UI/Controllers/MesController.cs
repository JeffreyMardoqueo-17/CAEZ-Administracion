﻿using CAEZ.Administracion.BL;
using CAEZ.Administracion.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAEZ.Administracion.UI.Controllers
{
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
