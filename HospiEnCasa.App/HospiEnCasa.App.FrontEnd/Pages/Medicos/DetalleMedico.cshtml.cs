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

namespace HospiEnCasa.App.FrontEnd.Pages.Medicos
{
    [Authorize(Roles = "Medico, Paciente")]
    public class DetalleMedico : PageModel
    {
        private readonly ILogger<DetalleMedico> _logger;
        private readonly IRepositorioMedico repositorioMedico;
        public MedicosPer Medico { get; set; }
        public IEnumerable<PacientesPer> Pacientes { get; set; }
        public string MenuFrom { get; set; } = "Medico";


        public DetalleMedico(ILogger<DetalleMedico> logger, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            this.repositorioMedico = repositorioMedico;
        }

        public IActionResult OnGet(int IdMedico, string MenuFromMed)
        {
            Medico = repositorioMedico.ObtenerMedico(IdMedico);
            Pacientes = repositorioMedico.ObtenerPacientesAsignados(IdMedico);

            if (Medico == null)
            {
                RedirectToPage("/Medicos/ListaMedicos");
            }
            return Page();
        }
    }
}