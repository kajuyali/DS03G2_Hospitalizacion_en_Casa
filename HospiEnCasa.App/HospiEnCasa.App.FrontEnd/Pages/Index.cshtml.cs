using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.Models;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.FrontEnd.Pages
{
    [Authorize(Roles = "Medico, Paciente, Admin")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioMedico repositorioMedico;
        private readonly IRepositorioEnfermero repositorioEnfermero;
        private readonly IRepositorioPersona repositorioPersona;
        public int countvalPac { get; private set; } = 0;
        public int countvalMed { get; private set; } = 0;
        public int countvalEnf { get; private set; } = 0;
        public Persona Persona { get; set; }

        public IndexModel(ILogger<IndexModel> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IRepositorioPaciente repositorioPaciente, IRepositorioMedico repositorioMedico, IRepositorioEnfermero repositorioEnfermero, IRepositorioPersona repositorioPersona)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioMedico = repositorioMedico;
            this.repositorioEnfermero = repositorioEnfermero;
            this.repositorioPersona = repositorioPersona;
        }

        public IActionResult OnGet()
        {
            var userId = _userManager.GetUserId(User);
            countvalPac = repositorioPaciente.Contar();
            countvalMed = repositorioMedico.Contar();
            countvalEnf = repositorioEnfermero.Contar();
            Persona = repositorioPersona.ObtenerPorString(userId);
            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        public IActionResult OnPostDontLogout()
        {
            return RedirectToPage("/Index");
        }
    }
}
