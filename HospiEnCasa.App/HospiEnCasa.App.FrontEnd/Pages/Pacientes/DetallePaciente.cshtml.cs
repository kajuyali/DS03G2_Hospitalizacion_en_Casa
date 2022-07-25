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
        private readonly IRepositorioFamiliar repositorioFamiliar;
        private readonly IRepositorioSigno repositorioSigno;
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public ListaSignosPaciente SignoVitales { get; set; }
        public MedicosPer MedicoAsignado { get; set; }

        public DetallePaciente(ILogger<DetallePaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioFamiliar repositorioFamiliar,IRepositorioSigno repositorioSigno)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioSigno = repositorioSigno;
        }
        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            SignoVitales = repositorioSigno.ObtenerSignosPaciente(IdPaciente);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(IdPaciente);
            if (Paciente == null) {
                RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = IdPaciente });
            }
            return Page();
        }   
    }
}
