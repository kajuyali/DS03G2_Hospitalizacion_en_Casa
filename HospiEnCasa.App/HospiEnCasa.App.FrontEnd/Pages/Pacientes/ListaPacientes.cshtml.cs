using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class ListaPacientes : PageModel
    {
        private readonly ILogger<ListaPacientes> _logger;

        public ListaPacientes(ILogger<ListaPacientes> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}