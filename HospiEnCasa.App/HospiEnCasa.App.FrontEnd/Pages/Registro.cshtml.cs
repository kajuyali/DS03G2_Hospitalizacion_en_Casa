using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospiEnCasa.App.Persistencia.AppRepositorios;
using HospiEnCasa.App.Persistencia.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HospiEnCasa.App.FrontEnd.Pages
{
    public class Registro : PageModel
    {
        private readonly ILogger<Registro> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositorioPersona _repositorioPersona;
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IRepositorioMedico _repositorioMedico;

        [BindProperty]
        public RegistroUsuario RegistroUsuario { get; set; }
        [BindProperty]
        public Persona Persona { get; set; }
        [BindProperty]
        public Paciente Paciente { get; set; }
        [BindProperty]
        public Medico Medico { get; set; }

        public Registro(ILogger<Registro> logger, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IRepositorioPersona repositorioPersona, IRepositorioPaciente repositorioPaciente, IRepositorioMedico repositorioMedico)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _repositorioPersona = repositorioPersona;
            _repositorioPaciente = repositorioPaciente;
            _repositorioMedico = repositorioMedico;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //Si el usuario selecciono Paciente
                if(RegistroUsuario.Tipo.Equals("Paciente"))
                {
                    var user = new IdentityUser(){ UserName = RegistroUsuario.Correo, Email = RegistroUsuario.Correo };

                    var result = await _userManager.CreateAsync(user, RegistroUsuario.Contraseña);
                    var rol = await _userManager.AddToRoleAsync(user, "Paciente");
                    if (result.Succeeded)
                    {
                        Persona.IdUsuario = user.Id;
                        _repositorioPersona.Crear(Persona);
                        Paciente.IdPersona = Persona.IdPersona;
                        _repositorioPaciente.Crear(Paciente);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToPage("Index");
                    } else {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                //Si el usuario selecciono Medico
                if (RegistroUsuario.Tipo.Equals("Medico"))
                {
                    var user = new IdentityUser(){ UserName = RegistroUsuario.Correo, Email = RegistroUsuario.Correo };
                    var result = await _userManager.CreateAsync(user, RegistroUsuario.Contraseña);
                    var rol = await _userManager.AddToRoleAsync(user, "Medico");
                    if (result.Succeeded)
                    {
                        Persona.IdUsuario = user.Id;
                        _repositorioPersona.Crear(Persona);
                        Medico.IdPersona = Persona.IdPersona;
                        _repositorioMedico.Crear(Medico);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToPage("Index");
                    } else {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                } 
            }
            return Page();
        }
    }
}