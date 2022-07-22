using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;

namespace HospiEnCasa.App.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioMedico repositorioMedico;
        public int countvalPac { get; private set; } = 0;
        public int countvalMed { get; private set; } = 0;
        public int countvalEnf { get; private set; } = 0; // Falta Implementar Enfermero


        public IndexModel(ILogger<IndexModel> logger, IRepositorioPaciente repositorioPaciente, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioMedico = repositorioMedico;
        }

        public void OnGet()
        {
            countvalPac = repositorioPaciente.Contar();
            countvalMed = repositorioMedico.Contar();
            countvalEnf = 0;
        }
    }
}
