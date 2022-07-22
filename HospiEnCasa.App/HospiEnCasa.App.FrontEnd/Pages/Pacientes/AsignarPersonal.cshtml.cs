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
    public class AsignarPersonal : PageModel
    {
        private readonly ILogger<AsignarPersonal> _logger;
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioAsignado repositorioAsignado;
        [BindProperty]
        public IEnumerable<MedicosPer> Medicos { get; set; }
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        [BindProperty]
        public Asignado Asignado { get; set; }

        public AsignarPersonal(ILogger<AsignarPersonal> logger, IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente, IRepositorioAsignado repositorioAsignado)
        {
            _logger = logger;
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioAsignado = repositorioAsignado;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            Medicos = repositorioMedico.ObtenerMedicos();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Asignado.IdPaciente = Paciente.IdPaciente;
            repositorioAsignado.CrearAsignado(Asignado);
            return RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });
        }
    }
}