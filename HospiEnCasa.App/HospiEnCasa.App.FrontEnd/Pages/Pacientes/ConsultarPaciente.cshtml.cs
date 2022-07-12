using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class ConsultarPaciente : PageModel
    {
        private readonly ILogger<ConsultarPaciente> _logger;

        public ConsultarPaciente(ILogger<ConsultarPaciente> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}