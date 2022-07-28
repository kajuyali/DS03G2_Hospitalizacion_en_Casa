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
        private readonly IRepositorioHistorium repositorioHistorium;
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public ListaSignosPaciente SignoVitales { get; set; } // Ultimo signo vital paciente
        public MedicosPer MedicoAsignado { get; set; }
        public IEnumerable<SignosList> RegistroSignosPaciente { get; set; } // Registro Completo Signos Vitales Paciente
        public IEnumerable<Historium> RegistroHistoriaPaciente { get; set; } // Registro Completo Historia Médica Paciente

        public DetallePaciente(ILogger<DetallePaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioFamiliar repositorioFamiliar, IRepositorioSigno repositorioSigno, IRepositorioHistorium repositorioHistorium)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioSigno = repositorioSigno;
            this.repositorioHistorium = repositorioHistorium;
        }
        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            SignoVitales = repositorioSigno.ObtenerSignosPaciente(IdPaciente);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(IdPaciente);
            RegistroSignosPaciente = repositorioSigno.ObtenerHistorialSignosPaciente(IdPaciente);
            RegistroHistoriaPaciente = repositorioHistorium.ObtenerHistoriaPaciente(IdPaciente);
            if (Paciente == null) {
                return RedirectToPage("/Pacientes/ListaPacientes");
            }
            return Page();
        }   
    }
}