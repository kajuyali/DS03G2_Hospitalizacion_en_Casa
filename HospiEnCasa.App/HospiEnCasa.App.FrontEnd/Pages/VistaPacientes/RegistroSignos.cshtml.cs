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
    [Authorize(Roles = "Paciente")]
    public class RegistroSignos : PageModel
    {
        private readonly ILogger<RegistroSignos> _logger;
        private readonly IRepositorioSigno repositorioSigno;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPersona repositorioPersona;

        public RegistroSignos(ILogger<RegistroSignos> logger, IRepositorioSigno repositorioSigno, IRepositorioPaciente repositorioPaciente, UserManager<IdentityUser> userManager, IRepositorioPersona repositorioPersona)
        {
            _logger = logger;
            _userManager = userManager;
            this.repositorioSigno = repositorioSigno;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPersona = repositorioPersona;
        }

        public Persona Persona { get; set; }
        public ListaSignosPaciente SignoVitales { get; set; }
        public PacientesPer Paciente { get; set; }
        public IEnumerable<SignosList> RegistroSignosPaciente { get; set; } // Registro Completo Signos Vitales Paciente

        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);
            Persona = repositorioPersona.ObtenerPorString(userId);
            Paciente = repositorioPaciente.ObtenerPacienteById(Persona.IdPersona);
            SignoVitales = repositorioSigno.ObtenerSignosPaciente(Paciente.IdPaciente);
            RegistroSignosPaciente = repositorioSigno.ObtenerHistorialSignosPaciente(Paciente.IdPaciente);
        }
    }
}