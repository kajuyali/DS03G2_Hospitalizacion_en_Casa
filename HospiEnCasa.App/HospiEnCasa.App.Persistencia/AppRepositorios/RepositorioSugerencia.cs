using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioSugerencia : IRepositorioSugerencia
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioSugerencia(HospiEnCasaContext context)
        {
            _context = context;
        }
        public Sugerencia CrearSugerencia(Sugerencia sugerencia)
        {
            _context.Sugerencias.Add(sugerencia);
            _context.SaveChanges();
            return sugerencia;
        }
        public IEnumerable<Sugerencia> ObtenerSugerencias(int IdPaciente)
        {
            return _context.Sugerencias.Where(s => s.IdPaciente == IdPaciente);
        }
    }
}