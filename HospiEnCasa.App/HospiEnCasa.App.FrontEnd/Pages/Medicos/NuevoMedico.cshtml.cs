using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.FrontEnd.Pages.Medicos
{
    public class NuevoMedico : PageModel
    {
        private readonly ILogger<NuevoMedico> _logger;

        public NuevoMedico(ILogger<NuevoMedico> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}