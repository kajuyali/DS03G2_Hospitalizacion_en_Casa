using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class ActualizarPaciente : PageModel
    {
        private readonly ILogger<ActualizarPaciente> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public MedicosPer MedicoAsignado { get; set; }

        public ActualizarPaciente(ILogger<ActualizarPaciente> logger, IRepositorioPaciente repositorioPaciente,  IRepositorioPersona repositorioPersona,  IRepositorioFamiliar repositorioFamiliar)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPersona = repositorioPersona;
        }
        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(IdPaciente);
            if (Paciente == null) {
                return RedirectToPage("/Pacientes/ListaPacientes");
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
            return RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });

        }  
    }
}


