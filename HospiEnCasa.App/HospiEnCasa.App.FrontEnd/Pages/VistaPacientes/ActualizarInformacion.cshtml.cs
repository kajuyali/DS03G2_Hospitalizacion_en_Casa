using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.VistaPacientes
{
    [Authorize(Roles = "Paciente")]
    public class ActualizarInformacion : PageModel
    {
        private readonly ILogger<ActualizarInformacion> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public MedicosPer MedicoAsignado { get; set; }

        public ActualizarInformacion(ILogger<ActualizarInformacion> logger, IRepositorioPaciente repositorioPaciente, IRepositorioPersona repositorioPersona, IRepositorioFamiliar repositorioFamiliar)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPersona = repositorioPersona;
            this.repositorioFamiliar = repositorioFamiliar;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(IdPaciente);
            if (Paciente == null) {
                return RedirectToPage("/VistaPacientes/MiInformacion");
            }
            return Page();
        } 
         public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            repositorioPersona.ActualizarPaciente(Paciente);
            Paciente = repositorioPaciente.Actualizar(Paciente);
            return RedirectToPage("/VistaPacientes/MiInformacion");

        }  
    }
}