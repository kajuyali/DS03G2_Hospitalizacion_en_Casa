using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.Enfermeros
{
    [Authorize(Roles = "Medico")]
    public class NuevoEnfermero : PageModel
    {
        private readonly ILogger<NuevoEnfermero> _logger;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioEnfermero repositorioEnfermero;
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Enfermero Enfermero { get; set; }

        public NuevoEnfermero(ILogger<NuevoEnfermero> logger, IRepositorioPersona repositorioPersona, IRepositorioEnfermero repositorioEnfermero)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            this.repositorioEnfermero = repositorioEnfermero;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        // Insertar registro en la base de datos
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //insertar persona y enfermero en la base de datos
            repositorioPersona.Crear(Persona);
            Enfermero.IdPersona = Persona.IdPersona;
            repositorioEnfermero.Crear(Enfermero);
            return Page();
        }
    }
}