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
    public class DetalleFamiliar : PageModel
    {
        private readonly ILogger<DetalleFamiliar> _logger;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        [BindProperty]
        public FamiliaresPer Familiar { get; set; }

        public DetalleFamiliar(ILogger<DetalleFamiliar> logger, IRepositorioFamiliar repositorioFamiliar)
        {
            _logger = logger;
            this.repositorioFamiliar = repositorioFamiliar;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Familiar = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            if (Familiar == null)
            {
                RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = IdPaciente });
            }
            return Page();
        }
    }
}