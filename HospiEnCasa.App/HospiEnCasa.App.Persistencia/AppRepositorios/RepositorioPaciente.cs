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
        public IEnumerable<PacientesPer> ObtenerPacientes()
        {
            var pacientes = from p in _context.Pacientes
                            from p1 in _context.Personas
                            where p.IdPersona == p1.IdPersona
                            select new PacientesPer()
                            {
                                Id = p1.Id,
                                Nombres = p1.Nombres,
                                Apellidos = p1.Apellidos,
                                Genero = p1.Genero,
                                Telefono = p1.Telefono,
                                FechaNacimiento = p.FechaNacimiento,
                                Ciudad = p.Ciudad,
                                Direccion = p.Direccion,
                                Latitud = p.Latitud,
                                Longitud = p.Longitud,
                            };
            IEnumerable<PacientesPer> pacientesPer = pacientes;
            return pacientesPer;
        }
    }
}