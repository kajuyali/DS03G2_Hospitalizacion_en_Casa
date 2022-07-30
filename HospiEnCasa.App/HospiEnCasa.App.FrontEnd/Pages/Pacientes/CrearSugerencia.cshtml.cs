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
    public class CrearSugerencia : PageModel
    {
        private readonly ILogger<CrearSugerencia> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioSugerencia repositorioSugerencia;
        private readonly IRepositorioMedico repositorioMedico;

        public CrearSugerencia(ILogger<CrearSugerencia> logger, IRepositorioPaciente repositorioPaciente, IRepositorioSugerencia repositorioSugerencia, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioSugerencia = repositorioSugerencia;
            this.repositorioMedico = repositorioMedico;
        }
        [BindProperty]
        public Sugerencia Sugerencia { get; set; }
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        [BindProperty]
        public MedicosPer Medico { get; set; }

        public void OnGet(int IdPaciente, int IdMedico)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            Medico = repositorioMedico.ObtenerMedico(IdMedico);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            repositorioSugerencia.CrearSugerencia(Sugerencia);
            _logger.LogInformation("Sugerencia creada");
            return RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });
        }
    }

}