using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioSigno : IRepositorioSigno
    {
        private readonly HospiEnCasaContext _context;
        public RepositorioSigno(HospiEnCasaContext context)
        {
            _context = context;
        }
        public SignosPaciente CrearSignoPaciente(SignosPaciente signoPaciente)
        {
            _context.SignosPacientes.Add(signoPaciente);
            _context.SaveChanges();
            return signoPaciente;
        }
        public SignosVitale ObtenerSigno(int idSigno)
        {
            var signo = from p in _context.SignosVitales
                        where p.IdSigno == idSigno
                        select p;
            SignosVitale signoVital = signo.FirstOrDefault();
            return signoVital;
        }
        public ListaSignosPaciente ObtenerSignosPaciente(int idPaciente)
        {
            var oximetria = from p in _context.SignosPacientes
                            where p.IdPaciente == idPaciente
                            where p.IdSigno == 1
                            select p.Valor;
            var freCardiaca = from p in _context.SignosPacientes
                              where p.IdPaciente == idPaciente
                              where p.IdSigno == 3
                              select p.Valor;
            var freRespiratoria = from p in _context.SignosPacientes
                                  where p.IdPaciente == idPaciente
                                  where p.IdSigno == 2
                                  select p.Valor;
            var temperatura = from p in _context.SignosPacientes
                                where p.IdPaciente == idPaciente
                                where p.IdSigno == 4
                                select p.Valor;
            var presion = from p in _context.SignosPacientes
                          where p.IdPaciente == idPaciente
                          where p.IdSigno == 5
                          select p.Valor;
            var signos = new ListaSignosPaciente()
            {
                IdPaciente = idPaciente,
                Oximetria = oximetria.FirstOrDefault(),
                FreCardiaca = freCardiaca.FirstOrDefault(),
                FreRespiratoria = freRespiratoria.FirstOrDefault(),
                Temperatura = temperatura.FirstOrDefault(),
                Presion = presion.FirstOrDefault()
            };
            return signos;
        }
    }
}