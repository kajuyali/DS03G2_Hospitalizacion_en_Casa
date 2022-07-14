using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioPaciente : IRepositorioPaciente
    {

        private readonly HospiEnCasaContext _context;

        public RepositorioPaciente(HospiEnCasaContext context)
        {
            _context = context;
        }
        public Paciente Crear(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }
    }
}