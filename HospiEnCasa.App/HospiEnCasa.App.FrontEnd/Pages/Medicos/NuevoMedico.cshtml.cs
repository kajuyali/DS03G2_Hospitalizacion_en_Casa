using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;

namespace HospiEnCasa.App.FrontEnd.Pages.Medicos
{
    public class NuevoMedico : PageModel
    {
        private readonly ILogger<NuevoMedico> _logger;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioMedico repositorioMedico;
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Medico Medico { get; set; }

        public NuevoMedico(ILogger<NuevoMedico> logger, IRepositorioPersona repositorioPersona, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            this.repositorioMedico = repositorioMedico;
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
            // Insertar persona
            repositorioPersona.Crear(Persona);
            Medico.IdPersona = Persona.IdPersona;
            repositorioMedico.Crear(Medico);
            return Page();
            
        }
    }
}