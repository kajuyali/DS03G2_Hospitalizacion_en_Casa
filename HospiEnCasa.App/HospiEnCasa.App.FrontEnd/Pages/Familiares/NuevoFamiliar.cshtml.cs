using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    [Authorize(Roles = "Paciente")]
    public class NuevoFamiliar : PageModel
    {

        private readonly ILogger<NuevoFamiliar> _logger;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Familiar Familiar { get; set; }
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        public int IdPacient  { get; set; }

        public NuevoFamiliar(ILogger<NuevoFamiliar> logger, IRepositorioPersona repositorioPersona, IRepositorioPaciente repositorioPaciente, IRepositorioFamiliar repositorioFamiliar)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            IdPacient = IdPaciente;
            if (Paciente == null)
            {
                return RedirectToPage("/VistaPaciente/MiInformacion");
            }
            
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repositorioPersona.Crear(Persona);
            Familiar.IdPersona = Persona.IdPersona;
            Familiar.IdPaciente = Paciente.IdPaciente;
            repositorioFamiliar.Crear(Familiar);
            return RedirectToPage("/VistaPacientes/MiInformacion");
        }
    }
}

