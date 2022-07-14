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
        public IEnumerable<Medico> ObtenerTodos()
        {
            return _context.Medicos;
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
        public Medico ObtenerPorId(int id)
        {
            return _context.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }
    }
}