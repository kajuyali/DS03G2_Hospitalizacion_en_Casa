using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages.VistaMedicos
{
    [Authorize(Roles = "Medico")]
    public class ActualizarInformacion : PageModel
    {
        private readonly ILogger<ActualizarInformacion> _logger;
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioPersona repositorioPersona;
        public MedicosPer Medico { get; set; }

        public ActualizarInformacion(ILogger<ActualizarInformacion> logger, IRepositorioPersona repositorioPersona, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            this.repositorioPersona = repositorioPersona;
            this.repositorioMedico = repositorioMedico;
        }

        public void OnGet(int IdMedico)
        {
            Medico = repositorioMedico.ObtenerMedico(IdMedico);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repositorioPersona.ActualizarMedico(Medico);
            Medico = repositorioMedico.Actualizar(Medico);
            return RedirectToPage("/VistaMedicos/MiInformacion");
        }
    }
}