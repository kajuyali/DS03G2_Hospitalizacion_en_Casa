using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioPersona(HospiEnCasaContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> ObtenerTodos()
        {
            return _context.Personas;
        }
        public Persona Crear(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
            return persona;
        }
        public void ActualizarFamiliar(FamiliaresPer familiar)
        {
            var personaEncontrada = (from f in _context.Personas.Where(p => p.IdPersona == familiar.IdPersona) select f).FirstOrDefault();
            if(personaEncontrada != null){
                personaEncontrada.Telefono = familiar.Telefono;
                _context.Update(personaEncontrada);
                _context.SaveChanges();
            }
        }
        public void ActualizarPaciente(PacientesPer paciente)
        {
            var personaEncontrada = (from f in _context.Personas.Where(p => p.IdPersona == paciente.IdPersona) select f).FirstOrDefault();
            if(personaEncontrada != null){
                personaEncontrada.Telefono = paciente.Telefono;
                personaEncontrada.Nombres = paciente.Nombres;
                personaEncontrada.Apellidos = paciente.Apellidos;
                _context.Update(personaEncontrada);
                _context.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            var personaEncontrada = _context.Personas.FirstOrDefault(p => p.IdPersona == id);
            if(personaEncontrada != null){
                _context.Personas.Remove(personaEncontrada);
                _context.SaveChanges();
            }
        }
        public Persona ObtenerPorId(int id)
        {
            return _context.Personas.FirstOrDefault(p => p.IdPersona == id);
        }
    }
}

