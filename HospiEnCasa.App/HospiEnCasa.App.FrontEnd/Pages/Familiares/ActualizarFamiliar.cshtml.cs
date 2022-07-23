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
        public FamiliaresPer Familiar { get; set; }

        public ActualizarFamiliar(ILogger<ActualizarFamiliar> logger, IRepositorioFamiliar repositorioFamiliar)
        {
            _logger = logger;
            this.repositorioFamiliar = repositorioFamiliar;
        }

        public IActionResult OnGet(int IdPaciente)
        {
            Familiar = repositorioFamiliar.ObtenerFamiliar(IdPaciente);
            if (Familiar == null)
            {
                RedirectToPage("/Pacientes/DetallePaciente");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            repositorioFamiliar.Actualizar(Familiar);
            return RedirectToPage("/Familiares/DetalleFamiliar", new { IdPaciente = Familiar.IdPaciente});

        }
    }
}