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
    public class DiagnosticoPaciente : PageModel
    {
        private readonly ILogger<DiagnosticoPaciente> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioHistorium repositorioHistorium;
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        [BindProperty]
        public Historium Historia { get; set; }

        public DiagnosticoPaciente(ILogger<DiagnosticoPaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioPersona repositorioPersona, IRepositorioHistorium repositorioHistorium)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPersona = repositorioPersona;
            this.repositorioHistorium = repositorioHistorium;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Historia.Fecha = DateTime.Now;
                Historia.IdPaciente = Paciente.IdPaciente;
                repositorioHistorium.CrearDiagnostico(Historia);
                return RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });
            }
            return Page();
        }
    }
}