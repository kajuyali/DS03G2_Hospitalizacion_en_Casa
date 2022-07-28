using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioHistorium : IRepositorioHistorium
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioHistorium(HospiEnCasaContext context)
        {
            _context = context;
        }
        public IEnumerable<Historium> ObtenerHistoriaPaciente(int IdPaciente)
        {
            var historiaPaciente = from p1 in _context.Historia
                            where p1.IdPaciente == IdPaciente
                            select p1;
            IEnumerable<Historium> Historia = historiaPaciente;
            return Historia;
        }
    }
}