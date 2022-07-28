using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.FrontEnd.Pages.Pacientes
{
    public class RegistrarSigno : PageModel
    {
        private readonly ILogger<RegistrarSigno> _logger;
        private readonly IRepositorioSigno repositorioSigno;
        private readonly IRepositorioPaciente repositorioPaciente;
        [BindProperty]
        public SignosPaciente SignoPaciente { get; set; }
        [BindProperty]
        public PacientesPer Paciente { get; set; }
        [BindProperty]
        public SignosVitale SignoVital { get; set; }

        public RegistrarSigno(ILogger<RegistrarSigno> logger, IRepositorioSigno repositorioSigno, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            this.repositorioSigno = repositorioSigno;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int IdSigno, int idPaciente)
        {
            Paciente = repositorioPaciente.ObtenerPaciente(idPaciente);
            SignoVital = repositorioSigno.ObtenerSigno(IdSigno);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SignoPaciente.Fecha = DateTime.Now;
                SignoPaciente.IdPaciente = Paciente.IdPaciente;
                SignoPaciente.IdSigno = SignoVital.IdSigno;
                repositorioSigno.CrearSignoPaciente(SignoPaciente);
                return RedirectToPage("/Pacientes/DetallePaciente", new { IdPaciente = Paciente.IdPaciente });
            }
            return Page();
        }
    }
}