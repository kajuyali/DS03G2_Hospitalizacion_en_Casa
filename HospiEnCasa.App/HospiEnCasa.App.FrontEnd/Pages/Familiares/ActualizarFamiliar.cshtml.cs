using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;

namespace HospiEnCasa.App.FrontEnd.Pages.Familiares
{
    public class ActualizarFamiliar : PageModel
    {
        private readonly ILogger<ActualizarFamiliar> _logger;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public FamiliaresPer Familiar { get; set; }
        [BindProperty]
        public PacientesPer Paciente { get; set; }

        public ActualizarFamiliar(ILogger<ActualizarFamiliar> logger, IRepositorioFamiliar repositorioFamiliar, IRepositorioPersona repositorioPersona, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPersona = repositorioPersona;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Familiar = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            if (Familiar == null)
            {
                RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repositorioPersona.ActualizarFamiliar(Familiar);
            Familiar = repositorioFamiliar.Actualizar(Familiar);
            return RedirectToPage("/Familiares/DetalleFamiliar", new { IdPaciente = Paciente.IdPaciente });
        }
    }
}