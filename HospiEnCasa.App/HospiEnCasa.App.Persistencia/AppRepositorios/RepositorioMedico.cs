using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioMedico(HospiEnCasaContext context)
        {
            _context = context;
        }
        public IEnumerable<MedicosPer> ObtenerMedicos()
        {
            var medicos =   from p in _context.Medicos
                            from p1 in _context.Personas
                            where p.IdPersona == p1.IdPersona
                            select new MedicosPer()
                            {
                                IdMedico = p.IdMedico,
                                IdPersona = p1.IdPersona,
                                Id = p1.Id,
                                Nombres = p1.Nombres,
                                Apellidos = p1.Apellidos,
                                Genero = p1.Genero,
                                Telefono = p1.Telefono,
                                Especialidad = p.Especialidad,
                                Registro = p.Registro
                            };
            IEnumerable<MedicosPer> medicosPer = medicos;
            return medicosPer;
        }
        public MedicosPer ObtenerMedico(int id)
        {
            var medico = from p in _context.Medicos
                         from p1 in _context.Personas
                         where p.IdMedico == id
                         where p.IdPersona == p1.IdPersona
                         select new MedicosPer()
                         {
                            IdMedico = p.IdMedico,
                            IdPersona = p1.IdPersona,
                            Id = p1.Id,
                            Nombres = p1.Nombres,
                            Apellidos = p1.Apellidos,
                            Genero = p1.Genero,
                            Telefono = p1.Telefono,
                            Especialidad = p.Especialidad,
                            Registro = p.Registro
                         };
            MedicosPer medicoPer = medico.FirstOrDefault();
            return medicoPer;
        }
        public Medico Crear(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return medico;
        }
        public Medico Actualizar(Medico medico)
        {
            var medicoEncontrado = _context.Medicos.FirstOrDefault(m => m.IdMedico == medico.IdMedico);
            if(medicoEncontrado != null){
                medicoEncontrado.Especialidad = medico.Especialidad;
                medicoEncontrado.Registro = medico.Registro;
            }
            _context.Medicos.Update(medicoEncontrado);
            _context.SaveChanges();
            return medico;
        }
        public void Eliminar(int id)
        {
            var medicoEncontrado = _context.Medicos.FirstOrDefault(m => m.IdMedico == id);
            if(medicoEncontrado != null){
                _context.Medicos.Remove(medicoEncontrado);
                _context.SaveChanges();
            }
        }
        public int Contar()
        {
            int countval = _context.Medicos.Count();
            return countval;
        }
    }
}