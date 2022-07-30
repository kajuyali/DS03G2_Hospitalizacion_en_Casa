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
    public class MiInformacion : PageModel
    {
        private readonly ILogger<MiInformacion> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        public Persona Persona { get; set; }
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public MedicosPer MedicoAsignado { get; set; }

        public MiInformacion(ILogger<MiInformacion> logger, UserManager<IdentityUser> userManager, IRepositorioPersona repositorioPersona, IRepositorioPaciente repositorioPaciente, IRepositorioFamiliar repositorioFamiliar, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            this.repositorioPersona = repositorioPersona;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);
            Persona = repositorioPersona.ObtenerPorString(userId);
            Paciente = repositorioPaciente.ObtenerPacienteById(Persona.IdPersona);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(Paciente.IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(Paciente.IdPaciente);
        }
    }
}