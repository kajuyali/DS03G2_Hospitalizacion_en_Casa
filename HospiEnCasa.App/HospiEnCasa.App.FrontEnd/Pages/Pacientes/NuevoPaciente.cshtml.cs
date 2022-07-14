using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class NuevoPaciente : PageModel
    {
        private readonly ILogger<NuevoPaciente> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioPersona repositorioPersona;
        [BindProperty]
        public Persona Persona { get; set; }
        public Paciente Paciente { get; set; }

        public NuevoPaciente(ILogger<NuevoPaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioPersona repositorioPersona)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPersona = repositorioPersona;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            repositorioPersona.Crear(Persona);
            //Paciente.IdPersona = Persona.IdPersona;
            //repositorioPaciente.Crear(Paciente);
            return RedirectToPage("Index");
        }
    }
}