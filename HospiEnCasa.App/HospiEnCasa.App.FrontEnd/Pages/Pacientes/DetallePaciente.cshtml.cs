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
    public class DetallePaciente : PageModel
    {
        private readonly ILogger<DetallePaciente> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        public PacientesPer Paciente { get; set; }

        public DetallePaciente(ILogger<DetallePaciente> logger, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            if (Paciente == null) {
                return RedirectToPage("/Pacientes/ListaPacientes");
            }
            return Page();
        }
    }
}