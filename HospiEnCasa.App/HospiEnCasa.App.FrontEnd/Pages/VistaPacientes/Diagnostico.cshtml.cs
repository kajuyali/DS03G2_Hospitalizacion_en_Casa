using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.VistaPacientes
{
    public class Diagnostico : PageModel
    {
        private readonly ILogger<Diagnostico> _logger;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioHistorium repositorioHistorium;
        private readonly IRepositorioSugerencia repositorioSugerencia;
        public IEnumerable<Historium> RegistroHistoriaPaciente { get; set; } // Registro Completo Historia Médica Paciente
        public Persona Persona { get; set; }
        public PacientesPer Paciente { get; set; }
        public IEnumerable<Sugerencia> Sugerencias { get; set; }

        public Diagnostico(ILogger<Diagnostico> logger, IRepositorioPersona repositorioPersona, SignInManager<IdentityUser> signInManager, IRepositorioPaciente repositorioPaciente, UserManager<IdentityUser> userManager, IRepositorioHistorium repositorioHistorium, IRepositorioSugerencia repositorioSugerencia)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            _signInManager = signInManager;
            this.repositorioPaciente = repositorioPaciente;
            _userManager = userManager;
            this.repositorioHistorium = repositorioHistorium;
            this.repositorioSugerencia = repositorioSugerencia;
        }

        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);
            Persona = repositorioPersona.ObtenerPorString(userId);
            Paciente = repositorioPaciente.ObtenerPacienteById(Persona.IdPersona);
            RegistroHistoriaPaciente = repositorioHistorium.ObtenerHistoriaPaciente(Paciente.IdPaciente);
            Sugerencias = repositorioSugerencia.ObtenerSugerencias(Paciente.IdPaciente);
        }
    }
}