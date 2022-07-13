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
        public Persona Actualizar(Persona persona)
        {
            var personaEncontrada = _context.Personas.FirstOrDefault(p => p.IdPersona == persona.IdPersona);
            if(personaEncontrada != null){
                personaEncontrada.Id = persona.Id;
                persona.Nombres = personaEncontrada.Nombres;
                persona.Apellidos = personaEncontrada.Apellidos;
                persona.Telefono = personaEncontrada.Telefono;
                persona.Genero = personaEncontrada.Genero;
            }
            _context.Personas.Update(personaEncontrada);
            _context.SaveChanges();
            return persona;
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