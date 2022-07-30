using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class ListaPacientes : PageModel
    {
        private readonly ILogger<ListaPacientes> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        public IEnumerable<PacientesPer> Pacientes { get; set; }
        public string MenuFrom { get; set; } = "ListaPacientes";
        public ListaPacientes(ILogger<ListaPacientes> logger, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
        }

        public void OnGet()
        {
            Pacientes = repositorioPaciente.ObtenerPacientes();
        }
    }
}