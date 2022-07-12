using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.FrontEnd.Pages.Listado
{
    public class Listado : PageModel
    {
        private readonly ILogger<Listado> _logger;

        public Listado(ILogger<Listado> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}