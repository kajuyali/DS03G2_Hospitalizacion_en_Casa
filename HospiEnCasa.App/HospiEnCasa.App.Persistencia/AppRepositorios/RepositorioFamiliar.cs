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
   }
}