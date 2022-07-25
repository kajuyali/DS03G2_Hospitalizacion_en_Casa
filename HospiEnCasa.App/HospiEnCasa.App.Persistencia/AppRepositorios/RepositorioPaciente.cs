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
                                IdPaciente = p.IdPac,
                                IdPersona = p1.IdPersona,
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
        public PacientesPer ObtenerPaciente(int IdPaciente)
        {
            var pacientes = from p in _context.Pacientes
                            from p1 in _context.Personas
                            where p.IdPac == IdPaciente
                            where p.IdPersona == p1.IdPersona
                            select new PacientesPer()
                            {
                                IdPaciente = p.IdPac,
                                IdPersona = p1.IdPersona,
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
            PacientesPer pacientesPer = pacientes.FirstOrDefault();
            return pacientesPer; 
        }
        public int Contar()
        {
            int countval = _context.Pacientes.Count();
            return countval;
        }
        public MedicosPer ObtenerMedicoAsignado(int IdPaciente)
        {
            var asignado = from p1 in _context.Medicos
                            from p2 in _context.Asignados
                            from p3 in _context.Personas
                            where p2.IdPaciente == IdPaciente
                            where p1.IdMedico == p2.IdMedico
                            where p1.IdPersona == p3.IdPersona
                            select new MedicosPer()
                            {
                                IdMedico = p1.IdMedico,
                                IdPersona = p1.IdPersona,
                                Id = p3.Id,
                                Nombres = p3.Nombres,
                                Apellidos = p3.Apellidos,
                                Genero = p3.Genero,
                                Telefono = p3.Telefono,
                                Especialidad = p1.Especialidad,
                                Registro = p1.Registro
                            };
            MedicosPer Medico = asignado.FirstOrDefault();
            return Medico;
        }
     
        public PacientesPer Actualizar(PacientesPer paciente)
        {
            var pacienteActualizar = (from f in _context.Pacientes.Where(p => p.IdPac == paciente.IdPaciente) select f).FirstOrDefault();

            if(pacienteActualizar != null){
                pacienteActualizar.Direccion = paciente.Direccion;
                pacienteActualizar.Ciudad = paciente.Ciudad;
                pacienteActualizar.Latitud = paciente.Latitud;
                pacienteActualizar.Longitud = paciente.Longitud;
                _context.Update(pacienteActualizar);
                _context.SaveChanges();
            }
            var pacienteActualizado = from f in _context.Pacientes
                            from p in _context.Personas
                            where f.IdPac == paciente.IdPaciente
                            where f.IdPersona == p.IdPersona
                            select new PacientesPer()
                            {
                                IdPaciente = f.IdPac,
                                IdPersona = p.IdPersona,
                                Id = p.Id,
                                Nombres = p.Nombres,
                                Apellidos = p.Apellidos,
                                Genero = p.Genero,
                                Telefono = p.Telefono,
                                FechaNacimiento = f.FechaNacimiento,
                                Ciudad = f.Ciudad,
                                Direccion = f.Direccion,
                                Latitud = f.Latitud,
                                Longitud = f.Longitud,
                            };
            PacientesPer pacienteActualizadoPer = pacienteActualizado.FirstOrDefault();
            return pacienteActualizadoPer;
        }
        
    }
}

