using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Persistencia.Models;

namespace HospiEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSugerencia
    {
        Sugerencia CrearSugerencia(Sugerencia sugerencia);
        IEnumerable<Sugerencia> ObtenerSugerencias(int IdPaciente);
    }
}