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

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    [Authorize(Roles = "Medico")]
    public class ConsultarHistoria : PageModel
    {
        private readonly ILogger<ConsultarHistoria> _logger;
        private readonly IRepositorioHistorium repositorioHistorium;
        private readonly IRepositorioSugerencia repositorioSugerencia;
        private readonly IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Historium> RegistroHistoriaPaciente { get; set; } // Registro Completo Historia Médica Paciente
        public Persona Persona { get; set; }
        public PacientesPer Paciente { get; set; }
        public IEnumerable<Sugerencia> Sugerencias { get; set; }


        public ConsultarHistoria(ILogger<ConsultarHistoria> logger, IRepositorioHistorium repositorioHistorium, IRepositorioSugerencia repositorioSugerencia, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            this.repositorioHistorium = repositorioHistorium;
            this.repositorioSugerencia = repositorioSugerencia;
            this.repositorioPaciente = repositorioPaciente;
        }

        public void OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPacienteById(IdPaciente);
            RegistroHistoriaPaciente = repositorioHistorium.ObtenerHistoriaPaciente(IdPaciente);
            Sugerencias = repositorioSugerencia.ObtenerSugerencias(IdPaciente);
        }
    }
}