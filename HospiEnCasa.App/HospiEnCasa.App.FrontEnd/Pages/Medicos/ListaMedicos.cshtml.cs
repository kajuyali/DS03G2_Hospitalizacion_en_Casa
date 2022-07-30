using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.Medicos
{
    [Authorize(Roles = "Medico")]
    public class ListaMedicos : PageModel
    {
        private readonly ILogger<ListaMedicos> _logger;
        private readonly IRepositorioMedico _repositorioMedico;
        public IEnumerable<MedicosPer> Medicos { get; set; }

        public ListaMedicos(ILogger<ListaMedicos> logger, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            _repositorioMedico = repositorioMedico;
        }

        public void OnGet()
        {
            Medicos = _repositorioMedico.ObtenerMedicos();
        }
    }
}