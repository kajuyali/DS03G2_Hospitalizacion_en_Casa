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
        private readonly IRepositorioSigno repositorioSigno;
        public PacientesPer Paciente { get; set; }
        public ListaSignosPaciente SignoVitales { get; set; }

        public DetallePaciente(ILogger<DetallePaciente> logger, IRepositorioPaciente repositorioPaciente, IRepositorioSigno repositorioSigno)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioSigno = repositorioSigno;
        }
        public IActionResult OnGet(int IdPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(IdPaciente);
            SignoVitales = repositorioSigno.ObtenerSignosPaciente(IdPaciente);
            if (Paciente == null) {
                return RedirectToPage("/Pacientes/ListaPacientes");
            }
            return Page();
        }   
    }
}