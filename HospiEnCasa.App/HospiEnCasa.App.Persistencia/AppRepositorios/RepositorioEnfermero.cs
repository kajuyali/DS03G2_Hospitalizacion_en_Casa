using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioEnfermero : IRepositorioEnfermero
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioEnfermero(HospiEnCasaContext context)
        {
            _context = context;
        }
        
        
        public Enfermero Crear(Enfermero enfermero)
        {
            _context.Enfermeros.Add(enfermero);
            _context.SaveChanges();
            return enfermero;
        }
        public int Contar()
        {
            int countval = _context.Enfermeros.Count();
            return countval;
        }
    }
}