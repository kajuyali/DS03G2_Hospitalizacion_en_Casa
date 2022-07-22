using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioAsignado : IRepositorioAsignado
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioAsignado(HospiEnCasaContext context)
        {
            _context = context;
        }
        public Asignado CrearAsignado(Asignado asignado)
        {
            _context.Asignados.Add(asignado);
            _context.SaveChanges();
            return asignado;
        }
    }
}