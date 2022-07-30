using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    [Authorize(Roles = "Medico")]
    public class DetallePaciente : PageModel
    {
        private readonly ILogger<DetallePaciente> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioSigno repositorioSigno;
        private readonly IRepositorioHistorium repositorioHistorium;
        private readonly UserManager<IdentityUser> _userManager;
        public PacientesPer Paciente { get; set; }
        public FamiliaresPer FamiliarAsignado { get; set; }
        public ListaSignosPaciente SignoVitales { get; set; } // Ultimo signo vital paciente

        public MedicosPer MedicoAsignado { get; set; }
        public IEnumerable<SignosList> RegistroSignosPaciente { get; set; } // Registro Completo Signos Vitales Paciente
        public IEnumerable<Historium> RegistroHistoriaPaciente { get; set; } // Registro Completo Historia Médica Paciente
        public Persona Persona { get; set; }
        public Historium Historia { get; set; }
        public MedicosPer Medico { get; set; }
        public string MenuPrev { get; set; }
        public int IdMedico {get; set;}

        public DetallePaciente(ILogger<DetallePaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioFamiliar repositorioFamiliar, IRepositorioPersona repositorioPersona, IRepositorioMedico repositorioMedico, IRepositorioSigno repositorioSigno, IRepositorioHistorium repositorioHistorium, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPersona = repositorioPersona;
            this.repositorioMedico = repositorioMedico;
            this.repositorioSigno = repositorioSigno;
            this.repositorioHistorium = repositorioHistorium;
            _userManager = userManager;
        }

        public IActionResult OnGet(int IdPaciente, string MenuFrom)
        {
            var userId = _userManager.GetUserId(User);
            Persona = repositorioPersona.ObtenerPorString(userId);
            Medico = repositorioMedico.ObtenerMedicoById(Persona.IdPersona);
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            SignoVitales = repositorioSigno.ObtenerSignosPaciente(IdPaciente);
            FamiliarAsignado = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            MedicoAsignado = repositorioPaciente.ObtenerMedicoAsignado(IdPaciente);
            RegistroSignosPaciente = repositorioSigno.ObtenerHistorialSignosPaciente(IdPaciente);
            RegistroHistoriaPaciente = repositorioHistorium.ObtenerHistoriaPaciente(IdPaciente);
            MenuPrev = MenuFrom;
            if(MenuFrom == "Medico") {
                IdMedico = Medico.IdMedico;
            }

            if (Paciente == null) {
                RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = IdPaciente });
            }
            return Page();
        }   
    }
}
