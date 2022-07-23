using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioFamiliar(HospiEnCasaContext context)
        {
            _context = context;
        }
        public Familiar Crear(Familiar familiar)
        {
            _context.Familiars.Add(familiar);
            _context.SaveChanges();
            return familiar;
        }
        public FamiliaresPer ObtenerFamiliar(int IdPaciente)
        {
            var familiares = from p in _context.Familiars
                            from p1 in _context.Personas
                            where p.IdPaciente == IdPaciente
                            where p.IdPersona == p1.IdPersona
                            select new FamiliaresPer()
                            {
                                IdFamiliar = p.IdFamiliar,
                                IdPaciente = p.IdPaciente,
                                IdPersona = p1.IdPersona,
                                Id = p1.Id,
                                Nombres = p1.Nombres,
                                Apellidos = p1.Apellidos,
                                Genero = p1.Genero,
                                Telefono = p1.Telefono,
                                Parentesco = p.Parentesco,
                                Correo = p.Correo,
                            };
            FamiliaresPer familiaresPer = familiares.FirstOrDefault();
            return familiaresPer; 
        }
        public void Actualizar(FamiliaresPer familiar)
        {
            var familiarActualizar = _context.Familiars.FirstOrDefault(f => f.IdFamiliar == familiar.IdFamiliar);
            if (familiarActualizar != null)
            {
                _context.Familiars.Attach(familiarActualizar);
                _context.Entry(familiarActualizar).Property(f => f.Correo).IsModified = true; 
                _context.SaveChanges();
            }
            var personaActualizar = _context.Personas.FirstOrDefault(f => f.IdPersona == familiar.IdPersona);
            if (personaActualizar != null)
            {
                _context.Personas.Attach(personaActualizar);
                _context.Entry(personaActualizar).Property(f => f.Telefono).IsModified = true; 
                _context.SaveChanges();
            }
            
        }
   }
}