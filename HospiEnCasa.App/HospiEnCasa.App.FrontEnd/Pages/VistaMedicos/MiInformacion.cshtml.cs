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

namespace HospiEnCasa.App.FrontEnd.Pages.VistaMedicos
{
    [Authorize(Roles = "Medico")]
    public class MiInformacion : PageModel
    {
        private readonly ILogger<MiInformacion> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioMedico repositorioMedico;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Persona Persona { get; set; }
        public MedicosPer Medico { get; set; }
        public IEnumerable<PacientesPer> Pacientes { get; set; }

        public MiInformacion(ILogger<MiInformacion> logger, IRepositorioPersona repositorioPersona, IRepositorioMedico repositorioMedico, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            this.repositorioMedico = repositorioMedico;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);
            Persona = repositorioPersona.ObtenerPorString(userId);
            Medico = repositorioMedico.ObtenerMedicoById(Persona.IdPersona);
            Pacientes = repositorioMedico.ObtenerPacientesAsignados(Medico.IdMedico);
        }
    }
}